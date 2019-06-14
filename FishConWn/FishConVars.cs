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
      
    }
}

