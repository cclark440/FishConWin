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

namespace FishConWn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text = "AddedText\n\r";
            //String key = "";
            String loginCommand = createLoginXml("admin", "Atg-3058sn");
            richTextBox1.Text += "Login sent\n\r";
            //
            FishConVars.Key = "cbdaca4a-700d-4d01-9c84-82ed8eec66ad";// pullKey(FishConVars.fbCon.sendCommand(loginCommand));
            if (FishConVars.Key == "null")
            {
                richTextBox1.Text += "Please accept the connection attempt on the fisbowl server and press return\n\r";
                FishConVars.Key = pullKey(FishConVars.fbCon.sendCommand(loginCommand));
            }
            else
            {
                richTextBox1.Text += "Connection Successfull with key:" + FishConVars.Key + "\n\r";
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private static String createLoginXml(string username, string password)
        {
            System.Text.StringBuilder buffer = new System.Text.StringBuilder("<FbiXml><Ticket/><FbiMsgsRq><LoginRq><IAID>");
            buffer.Append("222");
            buffer.Append("</IAID><IAName>");
            buffer.Append("FIshCon");
            buffer.Append("</IAName><IADescription>");
            buffer.Append("QMark Fishbowl Connection");
            buffer.Append("</IADescription><UserName>");
            buffer.Append(username);
            buffer.Append("</UserName><UserPassword>");

            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] encoded = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
            string encrypted = Convert.ToBase64String(encoded, 0, 16);
            buffer.Append(encrypted);
            buffer.Append("</UserPassword></LoginRq></FbiMsgsRq></FbiXml>");

            return buffer.ToString();
        }

        //Pull the session Key out of the server response string
        private static String pullKey(String connection)
        {
            String key = "";
            using (XmlReader reader = XmlReader.Create(new StringReader(connection)))
            {
                while (reader.Read())
                {
                    //if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("Key"))
                    if (reader.Name.Equals("Key") && reader.Read())
                    {
                        return reader.Value.ToString();
                    }
                }
            }
            return key;
        }


        // The following generates different querries 
        private static string listCustomerName(string key)
        {   
            return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><CustomerNameListRq></CustomerNameListRq></FbiMsgsRq></FbiXml>\r\n";
        }

        private static string listVenderName(string key)
        {
            return "<FbiXml><Ticket><Key>" + key + "</Key></Ticket><FbiMsgsRq><VenderNameListRq></VenderNameListRq></FbiMsgsRq></FbiXml>\r\n";
        }

        private  string queryParts()
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

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "\n\r<<<<<<<<<<<<<Requst>>>>>>>>>>>>>\n\r";
            richTextBox1.Text += queryParts() + "\n\r";

            String customerNameList = FishConVars.fbCon.sendCommand(queryParts());
            richTextBox1.Text += "*************Response**************\n\r";
            richTextBox1.Text += customerNameList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "<<<<<<<<<<<<<Requst>>>>>>>>>>>>>\n\r";
            richTextBox1.Text += listCustomerName(FishConVars.Key) + "\n\r";
            String customerNameList = FishConVars.fbCon.sendCommand(listCustomerName(FishConVars.Key));
            
            richTextBox1.Text += "*************Response**************\n\r";
            richTextBox1.Text += customerNameList;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
