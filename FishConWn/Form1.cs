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
//*************************************************************************************************
/*
private string FBRequest(string requestString, int requestType)
{
    StringBuilder builtRequest = new StringBuilder("{\"FbiJson\": { \"Ticket\": { \"Key\": \"");
    builtRequest.Append("{\"FbiJson\": { \"Ticket\": { \"Key\": \"");
    builtRequest.Append(FishConVars.Key); //add key to string
    builtRequest.Append("\"},\"FbiMsgsRq\": {\"");
    builtRequest.Append(FishConVars.Requests[requestType]);            
    builtRequest.Append(requestString);
    builtRequest.Append("\"}}}}");
    ///DataGridViewCellContextMenuStripNeededEventArgs to figure out if this on function is going to work for all requests.
    ///should I create function to just process response strip out ke and result code then pass actual response data?
    ///
    String sResponse = FishConVars.fbCon.sendCommand(builtRequest.ToString());
    FishConVars.Key = PullJsonKey(sResponse);
    //FishConVars.Key = "cbdaca4a-700d-4d01-9c84-82ed8eec66ad";
    if (FishConVars.Key == "null")
    {
        FishConVars.sLog += "Please accept the connection attempt on the fisbowl server and press return\n\r";
        FishConVars.Key = PullJsonKey(FishConVars.fbCon.sendCommand(builtRequest.ToString()));
    }
    else
    {

        FishConVars.sLog += "Connection Successfull with key:" + FishConVars.Key + "\n\r" + sResponse;
    }

    return builtRequest.ToString();
}
*/
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
        private string queryParts()
        {   //Start Json request string
            String returnString = "";
            if (cbFormat.Checked)
            {
                returnString = "{\"FbiJson\": { \"Ticket\": { \"Key\": \"";
                returnString += FishConVars.Key; //add key to string
                returnString += "\"},\"FbiMsgsRq\": {\"ExecuteQueryRq\":{\"Query\": \"";
                returnString += textBox1.Text;
                returnString += "\"}}}}";
            }

            else
            {
                returnString = textBox1.Text;
            }

            return returnString;
                //"<Query>SELECT product.num, customvarchar.info FROM product JOIN customvarchar ON product.id = customvarchar.recordid JOIN customfield on customvarchar.customfieldid = customfield.id WHERE customfield.name = 'Db' AND customvarchar.info = '2.0 mm'";
        }
        //*****************************************************************************************************************
        //Json Request
        private void button2_Click(object sender, EventArgs e)
        {
            FishConVars.sLog += "\n\r<<<<<<<<<<<<<Requst>>>>>>>>>>>>>\n\r";
            FishConVars.sLog += queryParts() + "\n\r";

            String customerNameList = FishConVars.fbCon.sendCommand(queryParts());
            FishConVars.sLog += "*************Response**************\n\r";
            FishConVars.sLog += customerNameList;
            //Get Response code

            FishConVars.sLog += FBConErrors.GetError(pullStatus(customerNameList)) +"\n\r";

        }
        //*****************************************************************************************************************
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            String logOutRequest = "{\"FbiJson\": {\"Ticket\": {\"Key\":\"" + FishConVars.Key + "\"},\"FbiMsgsRq\": {\"LogoutRq\": \"\"}}}";
                                   //"{\"FbiJson\": {\"Ticket\": {\"Key\":\"" + FishConVars.Key + "\"},\"FbiMsgsRq\": {\"LogoutRq\": \"\"}}}";
            String sResponse = FishConVars.fbCon.sendCommand(logOutRequest);
            e.Cancel = false;

        }

        private string pullStatus(string sResponse)
        {
            Match m = Regex.Match(sResponse, "\"statusCode\":*\\s*(\\d*)");
            String responseCode = m.Groups[1].ToString();

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
        {
            var fLogForm = new LogForm();
            fLogForm.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if(!File.Exists("Q:\\Label Data\\QMarkQB.qql"))
            {
                MessageBox.Show("Inititaliazation file can not be found.", " Init Error", MessageBoxButtons.OK);
            }
            else
            {
                string[] initFile = File.ReadAllLines("Q:\\Label Data\\QMarkQB.qql");
                for (int i = 0; i <initFile.Length;i++)
                {
                   int iLoc = initFile[i].IndexOf("LL-");
                   if (initFile[i].IndexOf("LL-")> -1)
                    {
                        sslLargePrinter.Text = initFile[i].Substring(initFile[i].IndexOf("LL") + 3, initFile[i].Length - initFile[i].IndexOf("LL") - 3);
                        if(ValidatePrinter(sslLargePrinter.Text) != "")
                        {
                            sslLargePrinter.BackColor = Color.LimeGreen;
                            sslLargePrinter.Tag = 1;
                            PD.PrinterSettings.PrinterName = ValidatePrinter(sslLargePrinter.Text.ToString());
                        }
                    }
                   else if(initFile[i].IndexOf("SL-")>-1)
                   {
                        sslSmallPrinter.Text= initFile[i].Substring(initFile[i].IndexOf("SL") + 3, initFile[i].Length - initFile[i].IndexOf("SL") - 3);
                        if(ValidatePrinter(sslSmallPrinter.Text) != "")
                        {
                            sslSmallPrinter.BackColor = Color.LimeGreen;
                            sslSmallPrinter.Tag = 1;
                            PD2.PrinterSettings.PrinterName = ValidatePrinter(sslSmallPrinter.Text.ToString());
                        }
                    }
                   else if (initFile[i].IndexOf("SVO=") > -1)
                    {

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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(!CheckPrinter())
            {
                MessageBox.Show("Printer must be selected before labels can be printed",  "No Printer Selected");
                return;
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
                var fAdHoc = new AdHoc();
                fAdHoc.Show();
            }

        }
    }
}
