using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FishConWn
{
    internal static class RawPrintHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct DOCINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;

            public DOCINFO(string documentName) :this()
            {
                if(string.IsNullOrEmpty(documentName))
                {
                    documentName = "RAW Document";
                }

                pDocName = documentName;
                pDataType = "RAW";
            }
        }

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPWStr)] string szPrinter, out SafePrinterHandle hPrinter, IntPtr pd);

        [DllImport("winspool.drv", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartDocPrinter(SafePrinterHandle hPrinter, int level, ref DOCINFO di);

        [DllImport("winspool.drv", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndDocPrinter(SafePrinterHandle hPrinter);

        [DllImport("winspool.drv", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartPagePrinter(SafePrinterHandle hPrinter);

        [DllImport("winspool.drv", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndPagePrinter(SafePrinterHandle hPrinter);

        [DllImport("winspool.drv", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool WritePrinter(SafePrinterHandle hPrinter, [MarshalAs(UnmanagedType.LPStr)] string data, int dwCount, out int dwWritten);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr vaListArguments);

        private static string GetErrorMessage(int errorCode)
        {
            var lpBuffer = new StringBuilder(0x200);
            if (FormatMessage(0x3200, IntPtr.Zero, errorCode, 0, lpBuffer, lpBuffer.Capacity, IntPtr.Zero) != 0)
            {
                return lpBuffer.ToString();
            }

            return $"Unknown error: {errorCode}";
        }

        private static void ThrowLastWin32Error(string path = null)
        {
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode != 0)
            {
                int hr = Marshal.GetHRForLastWin32Error();
                if (0 <= hr) throw new Win32Exception(errorCode);

                switch (errorCode)
                {
                    case 2: // File not found
                        {
                            if (string.IsNullOrEmpty(path)) throw new FileNotFoundException();
                            throw new FileNotFoundException(null, path);
                        }
                    case 3: // Directory not found
                        {
                            if (string.IsNullOrEmpty(path)) throw new DirectoryNotFoundException();
                            throw new DirectoryNotFoundException($"The directory '{path}' was not found.");
                        }
                    case 5: // Access denied
                        {
                            if (string.IsNullOrEmpty(path)) throw new UnauthorizedAccessException();
                            throw new UnauthorizedAccessException($"Access to the path '{path}' was denied.");
                        }
                    case 15: // Drive not found
                        {
                            if (string.IsNullOrEmpty(path)) throw new DriveNotFoundException();
                            throw new DriveNotFoundException($"Could not find the drive '{path}'. The drive might not be ready or might not be mapped.");
                        }
                    case 32: // Sharing violation
                        {
                            if (string.IsNullOrEmpty(path)) throw new IOException(GetErrorMessage(errorCode), hr);
                            throw new IOException($"The process cannot access the file '{path}' because it is being used by another process.", hr);
                        }
                    case 80: // File already exists
                        {
                            if (!string.IsNullOrEmpty(path))
                            {
                                throw new IOException($"The file '{path}' already exists.", hr);
                            }
                            break;
                        }
                    case 87: // Invalid parameter
                        {
                            throw new IOException(GetErrorMessage(errorCode), hr);
                        }
                    case 183: // File or directory already exists
                        {
                            if (!string.IsNullOrEmpty(path))
                            {
                                throw new IOException($"The file or directory '{path}' already exists.", hr);
                            }
                            break;
                        }
                    case 206: // Path too long
                        {
                            throw new PathTooLongException();
                        }
                    case 995: // Operation cancelled
                        {
                            throw new OperationCanceledException();
                        }
                    case 1801: // Invalid printer name
                        {
                            throw new ArgumentException($"The printer '{path}' was not found.", "printerName");
                        }
                    default:
                        {
                            Marshal.ThrowExceptionForHR(hr);
                            break;
                        }
                }
            }
        }

        private sealed class SafePrinterHandle : SafeHandle
        {
            private SafePrinterHandle() : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                return ClosePrinter(handle);
            }

            public static SafePrinterHandle Open(string printerName)
            {
                SafePrinterHandle result;
                if (!OpenPrinter(printerName, out result, IntPtr.Zero))
                {
                    ThrowLastWin32Error(printerName);
                }

                return result;
            }

            public IDisposable StartDocument(string name)
            {
                if (IsInvalid || IsClosed) return null;

                var di = new DOCINFO(name);
                if (!StartDocPrinter(this, 1, ref di))
                {
                    ThrowLastWin32Error();
                }

                return new PrinterDocument(this);
            }

            public IDisposable StartPage()
            {
                if (IsInvalid || IsClosed) return null;

                if (!StartPagePrinter(this))
                {
                    ThrowLastWin32Error();
                }

                return new PrinterPage(this);
            }

            public void Write(string data)
            {
                if (IsInvalid) throw new InvalidOperationException();
                if (IsClosed) throw new ObjectDisposedException(nameof(SafePrinterHandle));

                int bytesWritten;
                if (!WritePrinter(this, data, data.Length, out bytesWritten))
                {
                    ThrowLastWin32Error();
                }
            }
        }

        private sealed class PrinterDocument : IDisposable
        {
            private SafePrinterHandle _printer;

            public PrinterDocument(SafePrinterHandle printer)
            {
                _printer = printer;
            }

            public void Dispose()
            {
                var printer = Interlocked.Exchange(ref _printer, null);
                if (printer != null) EndDocPrinter(printer);
            }
        }

        private sealed class PrinterPage : IDisposable
        {
            private SafePrinterHandle _printer;

            public PrinterPage(SafePrinterHandle printer)
            {
                _printer = printer;
            }

            public void Dispose()
            {
                var printer = Interlocked.Exchange(ref _printer, null);
                if (printer != null) EndPagePrinter(printer);
            }
        }

        /// <summary>
        /// Sends the specified raw string to the printer.
        /// </summary>
        /// <param name="printerName">
        /// The name of the printer which receives the string.
        /// </param>
        /// <param name="valueToSend">
        /// The string to send.
        /// </param>
        /// <param name="documentName">
        /// The document name to use, if any.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <para><paramref name="printerName"/> is <see langword="null"/> or <see cref="string.Empty"/>.</para>
        /// <para>-or-</para>
        /// <para><paramref name="valueToSend"/> is <see langword="null"/> or <see cref="string.Empty"/>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <para>The specified printer was not found.</para>
        /// </exception>
        /// <exception cref="Win32Exception">
        /// There was an error sending the data to the printer.
        /// </exception>
        public static void SendStringToPrinter(string printerName, string valueToSend, string documentName)
        {
            if (string.IsNullOrWhiteSpace(printerName)) throw new ArgumentNullException(nameof(printerName));
            if (string.IsNullOrEmpty(valueToSend)) throw new ArgumentNullException(nameof(valueToSend));

            using (var printer = SafePrinterHandle.Open(printerName))
            using (printer.StartDocument(documentName))
            using (printer.StartPage())
            {
                printer.Write(valueToSend);
            }
        }
    }
}
