using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Techfix
{

    public class LoginResult
    {
        public bool IsValid { get; set; }  
        public string UserType { get; set; }  
    }


    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    public class UserValidation : System.Web.Services.WebService
    {

        SqlConnection con;

       
        public SqlConnection GetConnection()
        {
            try
            {
                con = new SqlConnection("data source=IMANI\\SQLEXPRESS;initial catalog=TechFix;Integrated Security=True");
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Connecting to DB:" + ex);
            }
            return con;
        }

        [WebMethod]
        public LoginResult loginUser(string username, string password)
        {
            LoginResult result = new LoginResult();

            try
            {
                GetConnection(); 
                SqlCommand cmd = new SqlCommand("SELECT UserType FROM Users WHERE Username = @Username AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    result.IsValid = true;  
                    result.UserType = dr["UserType"].ToString();  
                }
                else
                {
                    result.IsValid = false;  
                }

                dr.Close();
            }
            catch (Exception)
            {
                result.IsValid = false;  
                
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();  
                }
            }

            return result;  
        }






    }
}
