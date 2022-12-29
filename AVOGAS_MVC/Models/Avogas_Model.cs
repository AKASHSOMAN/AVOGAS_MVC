using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.NetworkInformation;


namespace AVOGAS_MVC.Models
{
    public class Avogas_Model

    {
        // Insert customer record into DB    

        public int InsertCustomer(string strCustomerFirstName, string strCustomerLastName, string strAadhaar, string strMobile, string strPassword)
        {
            string strConString = @"Data Source=ADMIN;Initial Catalog=AVOGAS;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into avocustomer (first_name, last_name, aadhaar_no, mobile_no, pass_word) values(@firstname,@lastname, @aadhaar , @mobile, @password)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@firstname", strCustomerFirstName);
                cmd.Parameters.AddWithValue("@lastname", strCustomerLastName);
                cmd.Parameters.AddWithValue("@aadhaar", strAadhaar);
                cmd.Parameters.AddWithValue("@mobile", strMobile);
                cmd.Parameters.AddWithValue("@password", strPassword);
                return cmd.ExecuteNonQuery();
            }
        }


                /// Login
        /// 
        public DataTable UserLogin(string name, string passw)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=ADMIN;Initial Catalog=AVOGAS;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from avocustomer where first_name='" + name + "' and pass_word ='" + passw + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}