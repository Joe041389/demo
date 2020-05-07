using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Demo.Services
{
    public class locatio_service
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["demo"].ToString());
    }
}