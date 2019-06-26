using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishConWn
{
    public partial class AdHoc : Form
    {
        public readonly Form1 _form1;
        public AdHoc(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String sPrintString = "";
            int iCounter = 0;
            int iXPos = 290; //used to calculate x position for centering of item name
            iXPos = iXPos - (tbPartNum.Text.Length / 2) * 22;

            if(rbtnLarge.Checked)
            { while(iCounter < tbQty.Value)
                {
                    sPrintString += "^XA^A@N,25,25,E:ARI001.FNT^FO70,30^A@N,26,31^FDQ-Mark Manufacturing, Inc.^FS^FO207,60^A@N,20,20^FDwww.cmms.com^FS";
                    sPrintString += "^FO195,220^A@N,30,30^FDMade in USA^FS^A@N,25,25,E:ARI001.FNT^FO" + iXPos + ",135^A@N,35,35^FD" + tbPartNum.Text;
                    sPrintString += "^FS\r\n^XZ\r\n";
                    iCounter += 1;
                 }

                RawPrintHelper.SendStringToPrinter(_form1.PD.PrinterSettings.PrinterName, "^XA~SD15^XZ", "FishConWn LL AdHoc"); // SETS DARKNESS of print.
                RawPrintHelper.SendStringToPrinter(_form1.PD.PrinterSettings.PrinterName, sPrintString, "FishConWn LL AdHoc");

            }
            else if(rbtnSmall.Checked)
            {
                while (iCounter < tbQty.Value)
                {
                    sPrintString += "^XA^A@N,25,25,E:ARI002.FNT^FO83," + 12 + FishConVars.SmallVertOffset + "^A@N,26,31^FDQ-Mark Manufacturing, Inc.^FS^FO100," + 95 + FishConVars.SmallVertOffset + "^A@N,20,20^FDwww.cmms.com^FS";
                    sPrintString += "^FO340," + 95 + FishConVars.SmallVertOffset + "^A@N,20,20^FDMade in USA^FS^A@N,25,25,E:ARI002.FNT^FO" + iXPos + "," + 50 + FishConVars.SmallVertOffset + "^A@N,35,35^FD" + tbPartNum.Text; // iItem.Text
                    sPrintString += "^FS\r\n^XZ\r\n";
                    iCounter += 1;
                }

                RawPrintHelper.SendStringToPrinter(_form1.PD2.PrinterSettings.PrinterName, "^XA~SD15^XZ", "FishConWn SS AdHoc");// ' SETS DARKNESS of print.
                RawPrintHelper.SendStringToPrinter(_form1.PD2.PrinterSettings.PrinterName, sPrintString, "FishConWn SS AdHoc");
        
            }
            else
            {
                MessageBox.Show("Please choose a printer before continuing.", "No Printer Sleceted", MessageBoxButtons.OK);
                
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
