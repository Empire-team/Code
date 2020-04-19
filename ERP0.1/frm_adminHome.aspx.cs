using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class frm_adminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region ButtonCustomerRegister_Click
        protected void ButtonCustomerRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_CustomerReg.aspx");
        }
        #endregion

        #region ButtonSupplierRegister_Click
        protected void ButtonSupplierRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_SupplierReg.aspx");
        }
        #endregion

        #region ButtonCategory_Click
        protected void ButtonCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_Category.aspx");
        }
        #endregion
    }
}