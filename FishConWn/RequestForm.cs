using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FishConWn
{
    public partial class RequestForm : Form
    {   
        private readonly Form1 _form1;
        public RequestForm(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

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

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            FishConVars.sLog += "\n\r<<<<<<<<<<<<<Requst>>>>>>>>>>>>>\n\r";
            FishConVars.sLog += queryParts() + "\n\r";

            String customerNameList = FishConVars.fbCon.sendCommand(queryParts());
            FishConVars.sLog += "*************Response**************\n\r";
            FishConVars.sLog += customerNameList;
            //Get Response code

            FishConVars.sLog += FBConErrors.GetError(_form1.pullStatus(customerNameList)) + "\n\r";
            if (Application.OpenForms.OfType<LogForm>().Any())
            {
                Application.OpenForms.OfType<LogForm>().First().UpdateLog();
            }

        }

   
    }
}
