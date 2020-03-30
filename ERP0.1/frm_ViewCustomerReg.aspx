<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_ViewCustomerReg.aspx.cs" Inherits="ERP.frm_ViewCustomerReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Registration Details
        <asp:GridView ID="GridViewRegistrationDetails" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewRegistrationDetails_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Select" />
                <asp:BoundField DataField="CusId" HeaderText="Cust Id" />
                <asp:BoundField DataField="CusName" HeaderText="Customer Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="State" HeaderText="State" />
                <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" />
                <asp:BoundField DataField="CountryName" HeaderText="Country" />
                <asp:BoundField DataField="PhNo" HeaderText="Phone Number" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="GSTNo" HeaderText="GST Number" />
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
