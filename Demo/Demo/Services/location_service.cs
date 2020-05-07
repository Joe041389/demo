using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Demo.Models;
using System.Data;
using System.Globalization;

namespace Demo.Services
{
    public class location_service
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["demo"].ToString());

        public bool add_value(string dt, List<dt_value> dt_values)
        {
            
            SqlCommand SqlCmd = new SqlCommand("add_dt", con);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.AddWithValue("@dt", dt);

            con.Open();
            SqlDataReader reader = SqlCmd.ExecuteReader();
            reader.Read();

            int dt_id = 0;
            if (!string.IsNullOrEmpty(reader[0].ToString()))
            {
                dt_id = Convert.ToInt32(reader[0].ToString());
            }
            
            reader.Close();
            SqlCmd.Dispose();

            if (dt_id >= 1)
            {
               
                bool add_result = false;
                foreach (dt_value item in dt_values)
                {
                    SqlCmd = new SqlCommand("add_dt_value", con);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.AddWithValue("@dt_id", dt_id);
                    SqlCmd.Parameters.AddWithValue("@location_code", item.location_code);
                    SqlCmd.Parameters.AddWithValue("@location_value", item.location_value);
                    SqlCmd.ExecuteNonQuery();
                    SqlCmd.Dispose();
                }

            }

            con.Close();

            return true;
        }
    }

    
}