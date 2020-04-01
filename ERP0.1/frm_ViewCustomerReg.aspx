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
        <asp:GridView ID="GridViewRegistrationDetails" runat="server" AutoGenerateColumns="False">
            <Columns>
                 <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkSelect" runat="server" Text="Select" CommandName="Select"
                            OnClientClick="return GetSelectedRow(this)" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CusId" HeaderText="Cust Id" />
                <asp:BoundField DataField="Name" HeaderText="Customer Name" />
                <asp:BoundField DataField="PhNo" HeaderText="Phone Number" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="State" HeaderText="State" />
                <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" />
                <asp:BoundField DataField="CountryName" HeaderText="Country" />
                <asp:BoundField DataField="GSTNo" HeaderText="GST Number" />
            </Columns>
        </asp:GridView>
        <br />
    <script type="text/javascript">
            function GetSelectedRow(lnk) {
                if (window.opener != null && !window.opener.closed) {
                    var row = lnk.parentNode.parentNode;
                    var rowIndex = row.rowIndex - 1;
                    var id = row.cells[1].innerHTML;
                    var name = row.cells[2].innerHTML;
                    var phno = row.cells[3].innerHTML;
                    var gender = row.cells[4].innerHTML;
                    var email = row.cells[5].innerHTML;
                    var address = row.cells[6].innerHTML;
                    var city = row.cells[7].innerHTML;
                    var state = row.cells[8].innerHTML;
                    var zipcode = row.cells[9].innerHTML;
                    var country = row.cells[10].innerHTML;
                    var gst = row.cells[11].innerHTML;
                    window.opener.document.getElementById("TextBoxCusId").value = id;
                    window.opener.document.getElementById("TextBoxCusName").value = name;
                    window.opener.document.getElementById("TextBoxCusPhno").value = phno;
                    window.opener.document.getElementById("DropDownListGender").value = gender;
                    window.opener.document.getElementById("TextBoxEmail").value = email;
                    window.opener.document.getElementById("TextBoxCusAddress").value = address;
                    window.opener.document.getElementById("TextBoxCity").value = city;
                    window.opener.document.getElementById("TextBoxState").value = state;
                    window.opener.document.getElementById("TextBoxZipCode").value = zipcode;
                    window.opener.document.getElementById("DropDownListCountry").value = country;
                    window.opener.document.getElementById("TextBoxGSTNo").value = gst;
                    window.opener.document.getElementById("ButtonRegister").value = "Update";
                    window.close();
                    return false;
                }
                self.close();
            }
        </script>
    </div>
    </form>
</body>
</html>
