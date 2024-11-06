<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Application.AdminDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="StyleSheet.css" rel="stylesheet" />
    <title>Admin Dashboard</title>
 
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <h1>Admin Dashboard</h1>

      
                      <!-- View Stock Section -->
                 <div class="section">
                     <h3>View Stock</h3>
                     <asp:GridView ID="GridViewStock" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                             <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                             <asp:BoundField DataField="Description" HeaderText="Description" />
                             <asp:BoundField DataField="Price" HeaderText="Price" />
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                         </Columns>
                     </asp:GridView>
                     <asp:Button ID="btnRefreshStock" runat="server" Text="Refresh Stock" OnClick="btnRefreshStock_Click" />
                 </div>

            <!-- Create Quotation Section -->
            <div class="section">
                <h3>Create Quotation</h3>
                <asp:TextBox ID="txtQuotationProductID" runat="server" Placeholder="Product ID"></asp:TextBox><br />
                <asp:TextBox ID="txtQuotationAmount" runat="server" Placeholder="Amount"></asp:TextBox><br />
                <asp:Button ID="btnCreateQuotation" runat="server" Text="Create Quotation" OnClick="btnCreateQuotation_Click" CssClass="button" />
            </div>

            <!-- View Created Quotations Section -->
            <div class="section">
                <h3>View Created Quotations</h3>
                <asp:GridView ID="GridViewQuotations" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="QuotationID" HeaderText="Quotation ID" />
                        <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnRefreshQuotations" runat="server" Text="Refresh Quotations" OnClick="btnRefreshQuotations_Click" CssClass="button" />
            </div>

            <!-- Update Quotation Section -->
            <div class="section">
                <h3>Update Quotation</h3>
                <asp:TextBox ID="txtUpdateQuotationID" runat="server" Placeholder="Quotation ID"></asp:TextBox><br />
                <asp:TextBox ID="txtUpdateAmount" runat="server" Placeholder="New Amount"></asp:TextBox><br />
                <asp:Button ID="btnUpdateQuotation" runat="server" Text="Update Quotation" OnClick="btnUpdateQuotation_Click" CssClass="button" />
            </div>

            <!-- Delete Quotation Section -->
            <div class="section">
                <h3>Delete Quotation</h3>
                <asp:TextBox ID="txtDeleteQuotationID" runat="server" Placeholder="Quotation ID"></asp:TextBox><br />
                <asp:Button ID="btnDeleteQuotation" runat="server" Text="Delete Quotation" OnClick="btnDeleteQuotation_Click" CssClass="button" />
            </div>

        </div>
    </form>
</body>
</html>