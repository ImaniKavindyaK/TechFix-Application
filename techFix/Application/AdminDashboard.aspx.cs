using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Application
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        Admin.AdminServiceSoapClient obj = new Admin.AdminServiceSoapClient();

       


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRefreshStock_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of your web service

                AddProduct.SupplierServiceSoapClient obj = new AddProduct.SupplierServiceSoapClient();
                // Call the ViewItems method to get the updated product table
                DataTable productTable = obj.ViewItems();

                // Bind the retrieved data to the GridView
                GridViewStock.DataSource = productTable;
                GridViewStock.DataBind();
            }
            catch (Exception ex)
            {
                // Optionally handle the exception (e.g., display an error message)
                // You can log the error or display it to the user as needed
                Response.Write("<script>alert('Error retrieving stock: " + ex.Message + "');</script>");
            }
        }

        protected void btnCreateQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the input values from the text boxes
                int productId = int.Parse(txtQuotationProductID.Text);
                decimal amount = decimal.Parse(txtQuotationAmount.Text);

                // Call the web service method to create the quotation
                bool result = obj.CreateQuotation(productId, amount);

                if (result)
                {
                    // Optionally, display a success message
                    Response.Write("<script>alert('Quotation created successfully!');</script>");

                    // Optionally refresh the quotations view to show the new entry
                    btnRefreshQuotations_Click(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('Failed to create quotation.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnRefreshQuotations_Click(object sender, EventArgs e)
        {

            try
            {
                // Call the web service method to get the quotations
                DataTable quotationsTable = obj.ViewQuotations();

                // Bind the retrieved data to the GridView
                GridViewQuotations.DataSource = quotationsTable;
                GridViewQuotations.DataBind();
            }
            catch (Exception ex)
            {
                // Optionally handle the exception (e.g., display an error message)
                Response.Write("<script>alert('Error retrieving quotations: " + ex.Message + "');</script>");
            }
        }

        protected void btnUpdateQuotation_Click(object sender, EventArgs e)
        {

            try
            {
                // Get the input values from the text boxes
                int quotationId = int.Parse(txtUpdateQuotationID.Text);
                decimal newAmount = decimal.Parse(txtUpdateAmount.Text);

                // Call the web service method to update the quotation
                bool result = obj.UpdateQuotation(quotationId, newAmount);

                if (result)
                {
                    // Optionally, display a success message
                    Response.Write("<script>alert('Quotation updated successfully!');</script>");

                    // Optionally refresh the quotations view to reflect the changes
                    btnRefreshQuotations_Click(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('Failed to update quotation. Quotation ID not found.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }




        }

        protected void btnDeleteQuotation_Click(object sender, EventArgs e)
        {

            try
            {
                // Get the input value from the text box
                int quotationId = int.Parse(txtDeleteQuotationID.Text);

                // Call the web service method to delete the quotation
                bool result = obj.DeleteQuotation(quotationId);

                if (result)
                {
                    // Optionally, display a success message
                    Response.Write("<script>alert('Quotation deleted successfully!');</script>");

                    // Optionally refresh the quotations view to reflect the changes
                    btnRefreshQuotations_Click(sender, e);
                }
                else
                {
                    Response.Write("<script>alert('Failed to delete quotation. Quotation ID not found.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }

        }
    }
}