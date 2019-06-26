using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using Microsoft.VisualBasic;

namespace FishConWn
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            FishConVars.sLog = "";
            this.Text += " : V1.0 Beta";
            FishConVars.SmallVertOffset = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void LogintoFishBowl()
        {
            String loginCommand = CreateLoginJson("admin", "Atg-3058sn");
            FishConVars.sLog += "Json Login sent\n\r" + loginCommand + "\n\r";
            String sResponse = FishConVars.fbCon.sendCommand(loginCommand);
            pullStatus(sResponse);
            FishConVars.Key = PullJsonKey(sResponse);

            if (FishConVars.Key == "null")
            {
                MessageBox.Show("Please accept the connection attempt on the fisbowl server and try again", "NOT AUTHERIZED", MessageBoxButtons.OK);
                FishConVars.Key = PullJsonKey(FishConVars.fbCon.sendCommand(loginCommand));
            }
            else
            {
                FishConVars.sLog += "Connection Successfull with key:" + FishConVars.Key + "\n\r" + sResponse;
                sslResultCode.BackColor = Color.LimeGreen;
            }
        }

//----------------------Json login---------------------------******************************************************
        private void button4_Click(object sender, EventArgs e)
        {
            LogintoFishBowl();
        }
       //******************************************************************************************************************
        private static String CreateLoginJson(string username, string password)
        {
            System.Text.StringBuilder buffer = new System.Text.StringBuilder("{\"FbiJson\" :{\"Ticket\": {\"Key\": \"\"},\"FbiMsgsRq\": {\"LoginRq\": {\"IAID\": 222, \"IAName\": \"FIshCon\", \"IADescription\": \"QMark Fishbowl Connection\",\"UserName\": \"");
            buffer.Append(username);
            buffer.Append("\",\"UserPassword\" :\"");

            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] encoded = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
            string encrypted = Convert.ToBase64String(encoded, 0, 16);
            buffer.Append(encrypted);
            buffer.Append("\"}}}}");

            return buffer.ToString();
        }
        //*****************************************************************************************************************
        private static String PullJsonKey(String connection)
        {   //"statusCode":(.*?),
            Match m = Regex.Match(connection, "\"Key\":\"(.*?)\"");

            if (m.Value == null)
            {
                return null;
            }
            else {
                String key = m.Groups[1].Value;
                return key;
            }   
        }
        //*****************************************************************************************************************

        //*****************************************************************************************************************
        //Json Request
        private void button2_Click(object sender, EventArgs e)
        {
          
        }
        //*****************************************************************************************************************
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            String logOutRequest = "{\"FbiJson\": {\"Ticket\": {\"Key\":\"" + FishConVars.Key + "\"},\"FbiMsgsRq\": {\"LogoutRq\": \"\"}}}";
                                   //"{\"FbiJson\": {\"Ticket\": {\"Key\":\"" + FishConVars.Key + "\"},\"FbiMsgsRq\": {\"LogoutRq\": \"\"}}}";
            String sResponse = FishConVars.fbCon.sendCommand(logOutRequest);
            e.Cancel = false;

        }

        public string pullStatus(string sResponse)
        {
            Match m = Regex.Match(sResponse, "\"statusCode\":*\\s*(\\d*)");
            String responseCode = m.Groups[1].ToString();
            try
            {
                if (Int32.Parse(responseCode) != 1000)
                {
                    sslResultCode.BackColor = Color.Yellow;
                }
                else
                {
                    sslResultCode.BackColor = Color.LimeGreen;
                }
            }
            catch( Exception e)
            {
                MessageBox.Show(e.Message + "\n\rPlease close application and try again.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sslResultCode.Text = responseCode;
            sslResultCode.ToolTipText = FBConErrors.GetError(responseCode);
            return (responseCode);
        }

        private void ParseResults(string dataSet)
        {
            //,"\\(.*?)\\""


            return;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {   //Make sure form isn't already open
            if (!Application.OpenForms.OfType<LogForm>().Any())
            {
                var fLogForm = new LogForm();
                fLogForm.Show();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LogintoFishBowl();

            if (!File.Exists("Q:\\Label Data\\QMarkQB.qql"))
            {
                MessageBox.Show("Inititaliazation file can not be found.", " Init Error", MessageBoxButtons.OK);
            }
            else
            {
                string[] initFile = File.ReadAllLines("Q:\\Label Data\\QMarkQB.qql");
                for (int i = 0; i < initFile.Length; i++)
                {
                    int iLoc = initFile[i].IndexOf("LL-");
                    if (initFile[i].IndexOf("LL-") > -1)
                    {
                        sslLargePrinter.Text = initFile[i].Substring(initFile[i].IndexOf("LL") + 3, initFile[i].Length - initFile[i].IndexOf("LL") - 3);
                        if (ValidatePrinter(sslLargePrinter.Text) != "")
                        {
                            sslLargePrinter.BackColor = Color.LimeGreen;
                            sslLargePrinter.Tag = 1;
                            PD.PrinterSettings.PrinterName = ValidatePrinter(sslLargePrinter.Text.ToString());
                        }
                    }
                    else if (initFile[i].IndexOf("SL-") > -1)
                    {
                        sslSmallPrinter.Text = initFile[i].Substring(initFile[i].IndexOf("SL") + 3, initFile[i].Length - initFile[i].IndexOf("SL") - 3);
                        if (ValidatePrinter(sslSmallPrinter.Text) != "")
                        {
                            sslSmallPrinter.BackColor = Color.LimeGreen;
                            sslSmallPrinter.Tag = 1;
                            PD2.PrinterSettings.PrinterName = ValidatePrinter(sslSmallPrinter.Text.ToString());
                        }
                    }
                    else if (initFile[i].IndexOf("SVO=") > -1)
                    {
                        FishConVars.SmallVertOffset = Int32.Parse(initFile[i].Substring(initFile[i].IndexOf("SVO") + 4, initFile[i].Length - initFile[i].IndexOf("SVO") - 4));
            
            }
                }
            }
           
        }
        private string ValidatePrinter(string sPrinter)
        {
            foreach(string printer in PrinterSettings.InstalledPrinters)
            {
               if( printer.ToString().IndexOf(sPrinter) > -1)
                {
                    return (printer.ToString());
                }
            }
            return "";
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.Rows.Clear();
            String returnString = "";
            returnString = FishConVars.FBTicketHeader;
            returnString += FishConVars.Key; //add key to string
            returnString += FishConVars.FBRequestHeader;
            returnString += FishConVars.SOQuery;
            returnString += tbSalesOrder.Text;
            returnString += "'" + FishConVars.FBTicketTail;

            String soResult = FishConVars.fbCon.sendCommand(returnString);
            FishConVars.sLog += "\n\r<<<<<<<<<<<<<Requst>>>>>>>>>>>>>\n\r";
            FishConVars.sLog += returnString + "\n\r";            
            FishConVars.sLog += "*************Response**************\n\r";
            FishConVars.sLog += soResult;
            FishConVars.sLog += FBConErrors.GetError(pullStatus(soResult)) + "\n\r";
            if(Int32.Parse(pullStatus(soResult))<=1000)
            {
                loadDatagrid(soResult);
            }

            if (Application.OpenForms.OfType<LogForm>().Any())
            {
                Application.OpenForms.OfType<LogForm>().First().UpdateLog();
            }
            Cursor.Current = Cursors.Default;
            //Get Response code
        }

        private void loadDatagrid(string response)
        {   //(?<=\",\")(.*?)(?=\",\")//Pull each item
            //{(?<=\\")([^,].*?)\\}  //parse to values after pulling item
            
            foreach (Match item in Regex.Matches(response, "(?<=\",\")(.*?)(?=\",\")|(?<=\",\")(.*?)(?=\"\")"))
            {
                //string dItem =item.Groups[1].Value;

               string caps = item.Captures[0].Value;

                var iDetails = Regex.Matches(item.Captures[0].Value, "(?<=\\\")([^,].*?)\\\\");//item.Groups[1].Value
                int iDetailCount = iDetails.Count;

                String sItemLabel = "";

                if(iDetailCount > 4)
                {   
                    lblCustomer.Text = iDetails[4].Groups[1].Value;
                    sItemLabel = iDetails[3].Groups[1].Value;
                }
                try
                {
                    //dataGridView1.Rows.Add(false, iDetails[1].Groups[1].Value, Int32.Parse(iDetails[2].Groups[1].Value), sItemLabel);
                    dataGridView1.Rows.Add(false, iDetails[1].Groups[1].Value, iDetails[2].Groups[1].Value, sItemLabel);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message, "Error processing data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }         

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //-----------Print Labels----------------------
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(!CheckPrinter())
            {
                MessageBox.Show("Printer must be selected before labels can be printed",  "No Printer Selected");
                return;
            }
            else
            {                
                if(dataGridView1.Rows.Count > 0)
                {//build labels
                    String sLargeLabels = "";
                    String sSmallLabels = "";
                    String sLabels = "";
                    int iLength = 0;
                    

                    for(int r = 0; r < dataGridView1.Rows.Count; r++)
                    {   
                        if(Convert.ToBoolean(dataGridView1.Rows[r].Cells[0].Value) == false)//Check if we are skipping item.
                        {   //*********  Large Labels ******************
                            sLabels = "";
                            int iXPos = 290;
                            String sItem = dataGridView1.Rows[r].Cells[1].Value.ToString();
                            iXPos = iXPos - (sItem.Length / 2) * 22;

                            if (dataGridView1.Rows[r].Cells[3].Value.ToString()=="" || dataGridView1.Rows[r].Cells[3].Value.ToString() == "Large")
                            {                                
                                sLabels += "^XA^A@N,25,25,E:ARI001.FNT^FO70,30^A@N,26,31^FDQ-Mark Manufacturing, Inc.^FS^FO207,60^A@N,20,20^FDwww.cmms.com^FS";
                                sLabels += "^FO195,220^A@N,30,30^FDMade in USA^FS^A@N,25,25,E:ARI001.FNT^FO" + iXPos + ",135^A@N,35,35^FD" + sItem;// 'iItem.Text
                                sLabels += "^FS^FO10,75^AOR,15,15^FD" + tbSalesOrder.Text;
                                sLabels += "^FS\r\n^XZ\r\n";

                                double iLabelCount = Convert.ToDouble(dataGridView1.Rows[r].Cells[2].Value);
                                for (int l = 0; l < iLabelCount; l++)
                                {
                                    sLargeLabels += sLabels;
                                }
                            }
                            //**************   Samll Labels  ********************
                            if (dataGridView1.Rows[r].Cells[3].Value.ToString() == "Small")
                            {
                                sLabels += "^XA^A@N,25,25,E:ARI002.FNT^FO83," + 12 + FishConVars.SmallVertOffset + "^A@N,26,31^FDQ-Mark Manufacturing, Inc.^FS^FO100," + 95 + FishConVars.SmallVertOffset + "^A@N,20,20^FDwww.cmms.com^FS";
                                sLabels += "^FO340," + 95 + FishConVars.SmallVertOffset + "^A@N,20,20^FDMade in USA^FS^A@N,25,25,E:ARI002.FNT^FO" + iXPos + "," + 50 + FishConVars.SmallVertOffset + "^A@N,35,35^FD" + sItem; //iItem.Text
                                sLabels += "^FS^FO10,10^AOR,10,10^FD" + tbSalesOrder.Text;
                                sLabels += "^FS\r\n^XZ\r\n";

                                for (int l = 0; l < Convert.ToDouble(dataGridView1.Rows[r].Cells[2].Value.ToString()); l++)
                                {
                                    sSmallLabels += sLabels;
                                }
                            }
                        }                       
                    }
                    if (sLargeLabels != "")
                    {
                        //FishConVars.sLog += sLargeLabels;
                        sLargeLabels += "^XA^A@N,25,25,E:ARI001.FNT^FO250,135^A@N,35,35^FD" + tbSalesOrder.Text + "^FS^FO25,50^A@N,25,25^FD" + lblCustomer.Text + "^ FS^XZ";
                        RawPrintHelper.SendStringToPrinter(PD.PrinterSettings.PrinterName, "^XA~SD15^XZ", "FishConWn LL AdHoc"); // SETS DARKNESS of print.
                        RawPrintHelper.SendStringToPrinter(PD.PrinterSettings.PrinterName, sLargeLabels, "FishConWn LL AdHoc");
                    }
                    if (sSmallLabels != "")
                    {
                        //FishConVars.sLog += sSmallLabels;
                        sSmallLabels += "^XA^A@N,25,25,E:ARI002.FNT^FO450,50^A@N,25,25^FD" + tbSalesOrder.Text + "^FS^FO20,50^A@N,25,25^FD" + lblCustomer.Text + "^FS^XZ";
                        RawPrintHelper.SendStringToPrinter(PD2.PrinterSettings.PrinterName, "^XA~SD15^XZ", "FishConWn LL AdHoc"); // SETS DARKNESS of print.
                        RawPrintHelper.SendStringToPrinter(PD2.PrinterSettings.PrinterName, sSmallLabels , "FishConWn LL AdHoc");
                    }
                }
            }
        }

        private bool CheckPrinter()
        {
            if (Convert.ToInt32(sslLargePrinter.Tag) == 0 && Convert.ToInt32(sslSmallPrinter.Tag) == 0)
            {
                if (PD.ShowDialog() == DialogResult.OK)
                {
                    if (PD.PrinterSettings.PrinterName.IndexOf("ZM400") > -1)
                    {
                        sslLargePrinter.Text = PD.PrinterSettings.PrinterName;
                        sslLargePrinter.BackColor = Color.LimeGreen;
                        sslLargePrinter.Tag = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Printer must be selected before labels can be printed", "No Printer Selected");
                    return false;
                }

            }
            return true;
        }

        private void btnPrint_MouseUp(object sender, MouseEventArgs e)
        {
            CheckPrinter();

            if (e.Button == MouseButtons.Right)
            {
                var fAdHoc = new AdHoc(this);
                fAdHoc.Show();
            }

        }

        private void customRequest_Click(object sender, EventArgs e)
        {   //Make sure form isn't already open
            if (!Application.OpenForms.OfType<RequestForm>().Any())
            {
                var fCustomRequest = new RequestForm(this);
                fCustomRequest.Show();
            }
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void sslLargePrinter_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                String sOffset = Interaction.InputBox("Input vertical alignment offset", "Small Label Vertical offset", Convert.ToString(FishConVars.SmallVertOffset));
                if (sOffset != "")
                {
                    try
                    {
                        FishConVars.SmallVertOffset = Convert.ToInt32(sOffset);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n\r Input could not be converted", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string[] initFile = File.ReadAllLines("Q:\\Label Data\\QMarkQB.qql");
                    
                    for (int i = 0; i < initFile.Length; i++)
                    {
                        if (initFile[i].IndexOf("SVO=") > -1)
                        {
                            initFile[i]= "SVO=" + FishConVars.SmallVertOffset;
                        }
                    
                    }

                    File.WriteAllLines("Q:\\Label Data\\QMarkQB.qql", initFile);
                }

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && tbSalesOrder.Text !="")
            {
                btnSalesOrder_Click(this, MouseEventArgs.Empty);
            }
        }
    }
}
