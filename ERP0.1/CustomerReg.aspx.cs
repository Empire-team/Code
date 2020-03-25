using ErpContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ERP
{
    public partial class CustomerReg : System.Web.UI.Page
    {
        public string strDisplayName = "Customer Registration";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                IsValidData();
                ErpDataContext db = new ErpDataContext();
                
                db.SpAccountdetail(strDisplayName, TextBoxCusName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxCusAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedValue.ToString(), TextBoxCusPhno.Text, TextBoxEmail.Text);
                Response.Write("Saved Successfully");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void IsValidData()
        {
            //if(string.IsNullOrEmpty(TextBoxCusName.Text))
            //{
                
            //}
        }
    }
}