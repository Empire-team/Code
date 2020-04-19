<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Category.aspx.cs" Inherits="ERP.frm_Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Category</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style ="float: right;">
          <asp:HyperLink ID="HyperLink1" NavigateUrl="frm_CategorySelect.aspx" runat="server">&lt;&lt; Back </asp:HyperLink>
        </div>
    <div style="border: solid 1px black; height: 260px; width: 581px; vertical-align: middle; margin: 0 auto; text-align: center;">
    
        <br />
    
        <asp:Label ID="LabelHeading" runat="server" Height="32px" Text="Category Details" Width="201px" style="font-size:26px;font-weight:bold"></asp:Label>
        <br />
        <br />
        Code:&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxCode" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <br />
        Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <br />
        <br />
        Description:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxDesc" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ButtonAddCategory" runat="server" BackColor="#57b846" ForeColor="White" Height="28px" Text="Add" Width="107px" OnClick="ButtonAddCategory_Click" /> 
    </div>
        <br />
        <br />
    <div style="margin-left:auto; margin-right:auto;">
    
        <asp:GridView ID="GridViewCategory" runat="server" Width="821px" AutoGenerateColumns="False" Height="76px" style="margin-left: 246px">
            <Columns>
                <asp:TemplateField HeaderText="">
                  <ItemTemplate>
                     <asp:LinkButton ID="lnkEdit" runat="server" onclick="ButtonGridViewEdit_Click" Text="Edit" />
                </ItemTemplate>
               </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                  <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" onclick="ButtonGridViewDelete_Click" Text="Delete" />
                </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField DataField="Code" HeaderText="Code" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
