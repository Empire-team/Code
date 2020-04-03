using ErpContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Devart.Data.Linq;
using System.Text.RegularExpressions;

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
                        Globals.MessageBoxShow(this, "Updated Successfully");
                        ButtonRegister.Text = "Register";
                        Clear();
                    }
                    else
                    {
                        db.SpAccountdetail(strDisplayName, TextBoxCusName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxCusAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedItem.ToString(), TextBoxCusPhno.Text, TextBoxEmail.Text, TextBoxGSTNo.Text);
                        Globals.MessageBoxShow(this, "Saved Successfully");
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Button Delete
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ErpDataContext db = new ErpDataContext();
                string strId = HiddenField1.Value.ToString();
                Int32 Id;
                if (!String.IsNullOrEmpty(strId))
                {
                    var IdResult = db.GetAcountId(strId).ToList();
                    Id = System.Convert.ToInt32(IdResult[0].Id);
                    db.DeleteAccountDetail(Id);
                    Globals.MessageBoxShow(this, "Deleted Successfully");
                    Clear();
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

        #region IsValidData
        private bool IsValidData()
        {
            if(ButtonRegister.Text=="Update")
            {
                if (string.IsNullOrEmpty(TextBoxCusId.Text))
                {
                    Globals.MessageBoxShow(this, "Please Choose a Customer to Edit");
                    TextBoxCusId.Focus();
                    return false;
                }
            }
            
            if (string.IsNullOrEmpty(TextBoxCusName.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Customer Name");
                TextBoxCusName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TextBoxZipCode.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Zip Code");
                TextBoxZipCode.Focus();
                return false;
            }
            else
            {
                string zipCodePattern = @"[0-9]{6}";
                bool isZipValid = true;
                isZipValid = Regex.IsMatch(TextBoxZipCode.Text, zipCodePattern);
                if(!isZipValid)
                {
                    Globals.MessageBoxShow(this, "Please Enter Valid Zip Code");
                    TextBoxZipCode.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(TextBoxCusPhno.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Phone Number");
                TextBoxCusPhno.Focus();
                return false;
            }
            else
            {
                string phnoPattern = @"[0-9]{10}";
                bool isphnoValid = true;
                isphnoValid = Regex.IsMatch(TextBoxCusPhno.Text, phnoPattern);
                if (!isphnoValid)
                {
                    Globals.MessageBoxShow(this, "Please Enter Valid Phone Number");
                    TextBoxCusPhno.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Email");
                TextBoxEmail.Focus();
                return false;
            }
            else
            {
                string emailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                bool isemailValid = true;
                isemailValid = Regex.IsMatch(TextBoxEmail.Text, emailPattern);
                if (!isemailValid)
                {
                    Globals.MessageBoxShow(this, "Please Enter Valid Email");
                    TextBoxEmail.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(TextBoxGSTNo.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter GST No");
                TextBoxGSTNo.Focus();
                return false;
            }
            else
            {
                string gstPattern = @"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$";
                bool isgstValid = true;
                isgstValid = Regex.IsMatch(TextBoxGSTNo.Text, gstPattern);
                if (!isgstValid)
                {
                    Globals.MessageBoxShow(this, "Please Enter Valid GST No");
                    TextBoxGSTNo.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(TextBoxState.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter State");
                TextBoxState.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TextBoxCity.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter City");
                TextBoxCity.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TextBoxCusAddress.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Address");
                TextBoxCusAddress.Focus();
                return false;
            }
            if (DropDownListCountry.SelectedItem.Text == "Select Country")
            {
                Globals.MessageBoxShow(this, "Please Select Country");
                DropDownListCountry.Focus();
                return false;
            }
            if (DropDownListGender.SelectedItem.Text == "Gender")
            {
                Globals.MessageBoxShow(this, "Please Select Gender");
                DropDownListGender.Focus();
                return false;
            }
            return true;
        }
        #endregion

    }
}