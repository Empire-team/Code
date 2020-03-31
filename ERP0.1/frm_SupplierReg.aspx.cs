﻿using ErpContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class frm_SupplierReg : System.Web.UI.Page
    {
        public static string strDisplayName = "Supplier Registration";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ErpDataContext db = new ErpDataContext();
                    DataTable dtCountry = new DataTable();
                    var result = db.SpCountry();
                    dtCountry = Globals.ObtainDataTableFromIEnumerable(result);
                    DropDownListCountry.DataSource = dtCountry;
                    DropDownListCountry.DataValueField = "CountryName";
                    DropDownListCountry.DataTextField = "CountryName";
                    DropDownListCountry.DataBind();
                    DropDownListCountry.Items.Insert(0, new ListItem("Select Country", ""));

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region ButtonRegister_Click
        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ErpDataContext db = new ErpDataContext();
                db.SpAccountdetail(strDisplayName, TextBoxSupName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedValue.ToString(), TextBoxSupPhno.Text, TextBoxEmail.Text, TextBoxGSTNo.Text);
                ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + "Saved Successfully" + "');", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}