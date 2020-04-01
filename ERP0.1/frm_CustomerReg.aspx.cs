using ErpContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Devart.Data.Linq;

namespace ERP
{
    public partial class frm_CustomerReg : System.Web.UI.Page
    {
        public static string strDisplayName = "Customer Registration";
      
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
                if(IsValidData())
                {
                    ErpDataContext db = new ErpDataContext();
                    string strId = HiddenField1.Value.ToString();
                    Int32 Id;
                    if (!String.IsNullOrEmpty(strId))
                    {
                        var IdResult = db.GetAcountId(strId).ToList();
                        Id = System.Convert.ToInt32(IdResult[0].Id);
                        db.UpdateAccountDetail(TextBoxCusName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxCusAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedItem.ToString(), TextBoxCusPhno.Text, TextBoxEmail.Text, TextBoxGSTNo.Text, Id);
                        ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + "Updated Successfully" + "');", true);
                        ButtonRegister.Text = "Register";
                        Clear();
                    }
                    else
                    {
                        string strcountry = DropDownListCountry.SelectedItem.Text;
                        db.SpAccountdetail(strDisplayName, TextBoxCusName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxCusAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedItem.ToString(), TextBoxCusPhno.Text, TextBoxEmail.Text, TextBoxGSTNo.Text);
                        ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + "Saved Successfully" + "');", true);
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Clear
        private void Clear()
        {
            try
            {
                TextBoxCusId.Text = "";
                HiddenField1.Value = "";
                TextBoxCusName.Text = "";
                TextBoxCusPhno.Text = "";
                TextBoxEmail.Text = "";
                TextBoxZipCode.Text = "";
                TextBoxState.Text = "";
                TextBoxGSTNo.Text = "";
                TextBoxCity.Text = "";
                TextBoxCusAddress.Text = "";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        private bool IsValidData()
        {
            
            if (string.IsNullOrEmpty(TextBoxCusName.Text))
            {
                Globals.MessageBoxShow(this, "Please fill out this field");
                TextBoxCusName.Focus();
                return false;
            }
            return true;
        }

    }
}