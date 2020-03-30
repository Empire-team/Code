using ErpContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class frm_ViewCustomerReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ErpDataContext db = new ErpDataContext();
                GridViewRegistrationDetails.DataSource = db.GetAccountDetail();
                GridViewRegistrationDetails.DataBind();
            }
        }

        protected void GridViewRegistrationDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                string strCusId, strCusName, strGender, strAddress, strCity, strState, strZipCode, strCountry, strPhno, strEmail, strGstNo;
                strCusId = GridViewRegistrationDetails.SelectedRow.Cells[1].Text;
                strCusName = GridViewRegistrationDetails.SelectedRow.Cells[2].Text;
                strGender = GridViewRegistrationDetails.SelectedRow.Cells[3].Text;
                strAddress = GridViewRegistrationDetails.SelectedRow.Cells[4].Text;
                strCity = GridViewRegistrationDetails.SelectedRow.Cells[5].Text;
                strState = GridViewRegistrationDetails.SelectedRow.Cells[6].Text;
                strZipCode = GridViewRegistrationDetails.SelectedRow.Cells[7].Text;
                strCountry = GridViewRegistrationDetails.SelectedRow.Cells[8].Text;
                strPhno = GridViewRegistrationDetails.SelectedRow.Cells[9].Text;
                strEmail = GridViewRegistrationDetails.SelectedRow.Cells[10].Text;
                strGstNo = GridViewRegistrationDetails.SelectedRow.Cells[11].Text;
                CustomerReg parent = new CustomerReg();
               
                parent.LoadValues(parent,strCusId, strCusName, strGender, strAddress, strCity, strState, strZipCode, strCountry, strPhno, strEmail, strGstNo);
                ScriptManager.RegisterStartupScript(this, typeof(string), "key", "window.close('frm_ViewCustomerReg.aspx','_self', null);", true);
                //ScriptManager.RegisterStartupScript(parent, typeof(string), "somekey", "RefreshPage('CustomerReg.aspx')", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}