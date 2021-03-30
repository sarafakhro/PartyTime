using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PartyTime.Database
{
    public class connectionString
    {
        public static string con = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}