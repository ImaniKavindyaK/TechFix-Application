using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Techfix
{
    /// <summary>
    /// Summary description for AdminService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminService : System.Web.Services.WebService
    {
        SqlConnection SQLCon;

        public SqlConnection GetConnection()
        {
            try
            {
                SQLCon = new SqlConnection("data source=IMANI\\SQLEXPRESS;initial catalog=TechFix;Integrated Security=True");
                SQLCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Connecting to DB:" + ex);
            }
            return SQLCon;
        }

        //View Items

        [WebMethod]
        public DataTable ViewItems()
        {
            DataTable productTable = new DataTable("ProductTable");

            try
            {
                GetConnection();

                
                using (SqlCommand cmd = new SqlCommand("SELECT ProductId, ProductName, Description, Price, Quantity FROM Products", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(productTable);
                }

                return productTable;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error retrieving products: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();
            }
        }

        //Create Quotation
        [WebMethod]
        public bool CreateQuotation(int productId, decimal amount)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Quotations (ProductID, Amount, CreatedAt) VALUES (@ProductID, @Amount, @CreatedAt)", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now); 

                    cmd.ExecuteNonQuery();
                }

                return true; 
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error creating quotation: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();
            }
        }


        //view Quotations

        [WebMethod]
        public DataTable ViewQuotations()
        {
            DataTable quotationsTable = new DataTable("QuotationsTable");

            try
            {
                GetConnection();

                
                using (SqlCommand cmd = new SqlCommand("SELECT QuotationID, ProductID, Amount, CreatedAt FROM Quotations", SQLCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(quotationsTable);
                }

                return quotationsTable;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error retrieving quotations: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();
            }
        }


        //Update Quotation

        [WebMethod]
        public bool UpdateQuotation(int quotationId, decimal newAmount)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("UPDATE Quotations SET Amount = @NewAmount WHERE QuotationID = @QuotationID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@NewAmount", newAmount);
                    cmd.Parameters.AddWithValue("@QuotationID", quotationId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error updating quotation: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();
            }
        }

        //Delete Quotation

        [WebMethod]
        public bool DeleteQuotation(int quotationId)
        {
            try
            {
                GetConnection();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Quotations WHERE QuotationID = @QuotationID", SQLCon))
                {
                    cmd.Parameters.AddWithValue("@QuotationID", quotationId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error deleting quotation: " + ex.Message);
            }
            finally
            {
                SQLCon.Close();
            }
        }








    }
}
