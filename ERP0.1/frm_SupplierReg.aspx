<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_SupplierReg.aspx.cs" Inherits="ERP.frm_SupplierReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!-- Required meta tags-->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">

    <!-- Title Page-->
    <title>Supplier Registration</title>

    <!-- Icons font CSS-->
    <link href="vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <!-- Font special for pages-->
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet">

    <!-- Vendor CSS-->
    <link href="vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="vendor/datepicker/daterangepicker.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="css/regmain.css" rel="stylesheet" media="all">
</head>

<body>
    <div class="page-wrapper bg-blue p-t-180 p-b-100 font-robo">
        <div class="wrapper wrapper--w960">
            <div class="card card-2">
                <div class="card-heading1"></div>
                <div class="card-body">
                    <h2 class="title">SUPPLIER REGISTRATION</h2>
                    <form id="form1" runat="server">
                        <div class="row" style ="float: right;">
                            
                            <asp:Button ID="ButtonViewRegistration" runat="server" BackColor="#FFCC00" ForeColor="Black" Height="41px" Text="View Customers" Width="133px" onClientClick="SelectDetails()" />  
                                                     
                        </div>
                        <div class="row row-space" style ="padding-top: 50px;"> 
                        <div class="input-group">
                            <asp:TextBox class="input--style-2" runat="server" placeholder="Supplier Id" name="supid" id="TextBoxSupId" Width="300px" Enabled="False"></asp:TextBox>                       
                        </div>
                        </div>
                        
                        <div class="input-group">
                           <asp:TextBox class="input--style-2" runat="server" type="text" placeholder="Name" name="name" id="TextBoxSupName"></asp:TextBox> 
                        </div>
                        
                        
                            

                        <div class="row row-space"> 
                            <div class="col-2">
                            <div class="input-group">
                            <asp:TextBox class="input--style-2" runat="server" placeholder="Phone No" name="phno" id="TextBoxSupPhno"></asp:TextBox>                      
                            </div>
                            </div>                              
                            <div class="col-2">
                                <div class="input-group">
                                    <div class="rs-select2 js-select-simple select--no-search">
                                        <asp:DropDownList ID="DropDownListGender" runat="server">
                                        <asp:ListItem>Gender</asp:ListItem>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="input-group">  
                            <asp:TextBox class="input--style-2" runat="server" placeholder="Email Id" name="email" id="TextBoxEmail"></asp:TextBox>                                                                        
                        </div>
                        <div class="input-group">  
                            <asp:TextBox class="input--style-2" runat="server" placeholder="Address" name="address" id="TextBoxAddress" Width="300px"></asp:TextBox>                                                                        
                        </div>

                        <div class="row row-space"> 
                            <div class="col-2">
                            <div class="input-group">
                            <asp:TextBox class="input--style-2" runat="server" placeholder="City" name="city" id="TextBoxCity"></asp:TextBox>                      
                            </div>
                            </div>                              
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:TextBox class="input--style-2" runat="server" placeholder="State" name="state" id="TextBoxState"></asp:TextBox>                      
                                </div>
                            </div>
                        </div>

                        
                        <div class="row row-space">
                            <div class="col-2">
                                <div class="input-group">
                                    <asp:TextBox class="input--style-2" runat="server" placeholder="Zip Code" name="zipcode" id="TextBoxZipCode"></asp:TextBox>   
                                </div>
                             </div>  
                            <div class="col-2"> 
                                <div class="input-group">
                                    <div class="rs-select2 js-select-simple select--no-search">
                                         <asp:DropDownList ID="DropDownListCountry" runat="server"></asp:DropDownList>
                                        <div class="select-dropdown"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row row-space"> 
                        <div class="input-group">
                            <asp:TextBox class="input--style-2" runat="server" placeholder="GST Number" name="gstno" id="TextBoxGSTNo"></asp:TextBox>
                        </div>
                        </div>

                        <div class="p-t-30">
                            <asp:Button ID="ButtonRegister" runat="server" BackColor="Red" ForeColor="White" Height="41px" Text="Register" Width="133px" OnClick="ButtonRegister_Click" />
                        </div>
                        <script lang="javascript" type="text/javascript">
                        var popup;
                        function SelectDetails() {
                        popup = window.open("frm_ViewSupplierReg.aspx", "Popup", "width=800,height=500");
                        popup.focus();
                        return false
                        }
                        </script>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <!-- Jquery JS-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <!-- Vendor JS-->
    <script src="vendor/select2/select2.min.js"></script>
    <script src="vendor/datepicker/moment.min.js"></script>
    <script src="vendor/datepicker/daterangepicker.js"></script>

    <!-- Main JS-->
    <script src="js/global.js"></script>

</body><!-- This templates was made by Colorlib (https://colorlib.com) -->
</html>
