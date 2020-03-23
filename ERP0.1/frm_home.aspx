<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_home.aspx.cs" Inherits="ERP.frm_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome Home
            <asp:DropDownList ID="DropDownListGender" runat="server">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
