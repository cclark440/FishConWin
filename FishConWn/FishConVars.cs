using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishConWn
{
    class FishConVars
    {
        public static String Key;
        public static ConnectionObject fbCon = new ConnectionObject();
        public static String[] Requests={ "ExecuteQueryRq \":{\"Query\": \"", "ImportRq", "ImportHeaderRq", "IssueSORq", "LoginRq", "	LogoutRq", "QuickShipRq", "VoidSORq", };
        public static String sLog;  //Used to record communication log between app and server.
        public static int SmallVertOffset;
        public static String SOQuery = "SELECT so.id, soi.productNum AS Part, soi.qtyOrdered AS QTY, cuset.info AS Label, so.ShipToName FROM so JOIN soitem AS soi ON so.id = soi.soid LEFT JOIN customset AS cuset ON cuset.recordid = soi.productid AND cuset.customfieldid = 89 where so.num='";
        public static String FBTicketHeader = "{\"FbiJson\": { \"Ticket\": { \"Key\": \"";
        public static String FBRequestHeader = "\"},\"FbiMsgsRq\": {\"ExecuteQueryRq\":{\"Query\": \"";
        public static String FBTicketTail = "\"}}}}";

    }
}

