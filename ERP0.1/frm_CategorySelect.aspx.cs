using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class frm_CategorySelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region ButtonBrand_Click
        protected void ButtonBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_Category.aspx?Value=" + ButtonBrand.Text);
        }
        #endregion

        #region ButtonSize_Click
        protected void ButtonSize_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_Category.aspx?Value=" + ButtonSize.Text);
        }
        #endregion

        #region ButtonColor_Click
        protected void ButtonColor_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_Category.aspx?Value=" + ButtonColor.Text);
        }
        #endregion
    }
}