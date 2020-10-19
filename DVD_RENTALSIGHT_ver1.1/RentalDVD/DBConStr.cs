using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RentalDVD
{
    public class DBConStr
    {
        
        
        public static string ConnectionString() {


            string connectStrings = string.Empty;

            connectStrings += "Addr         = 192.168.10.201;";
            connectStrings += "Initial Catalog     = DVDRentalDBA;";
            connectStrings += "Integrated Security = false;";
            connectStrings += "User ID              = sa;";
            connectStrings += "Password            = P@ssw0rd;";


            return connectStrings;
        
        
        
        }

     }
}