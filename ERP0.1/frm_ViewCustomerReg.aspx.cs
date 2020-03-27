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
    }
}