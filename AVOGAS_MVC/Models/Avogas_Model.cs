using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AVOGAS_MVC.Models
{
    public class Avogas_Model

    {
        // Insert customer record into DB    

        public int InsertCustomer(string strCustomerFirstName, string strCustomerLastName, int intAadhaar, int intMobile)
        {
            string strConString = @"Data Source=ADMIN;Initial Catalog=Bank;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into Customers (first_name, last_name, aadhaar_no, mobile_no) values(@firstname,@lastname, @aadhaar , @mobile)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", strCustomerFirstName);
                cmd.Parameters.AddWithValue("@lastname", strCustomerLastName);
                cmd.Parameters.AddWithValue("@aadhaar", intAadhaar);
                cmd.Parameters.AddWithValue("@mobile", intMobile);
                return cmd.ExecuteNonQuery();
            }
        }


        // Get details by customer_id    

        public DataTable GetStudentByID(int intStudentID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=ADMIN;Initial Catalog=Bank;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblStudent where student_id=" + intStudentID, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

    }
}