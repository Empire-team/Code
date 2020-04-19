using ErpContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERP
{
    public partial class frm_Category : System.Web.UI.Page
    {
        public static string BRAND = "Brand";
        public static string COLOR = "Color";
        public static string SIZE = "Size";

        protected void Page_Load(object sender, EventArgs e)
        {
            string strCat = Convert.ToString(Request.QueryString["Value"]);
            LabelHeading.Text = strCat + " Details";
            if(strCat == BRAND)
            {
                ErpDataContext db = new ErpDataContext();
                GridViewCategory.DataSource = db.GetBrand();
                GridViewCategory.DataBind();
            }
            if (strCat == COLOR)
            {
                ErpDataContext db = new ErpDataContext();
                GridViewCategory.DataSource = db.GetColor();
                GridViewCategory.DataBind();
            }
            if (strCat == SIZE)
            {
                ErpDataContext db = new ErpDataContext();
                GridViewCategory.DataSource = db.GetSize();
                GridViewCategory.DataBind();
            }

        }

        #region ButtonGridViewEdit_Click
        protected void ButtonGridViewEdit_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
                TextBoxCode.Text = grdrow.Cells[2].Text;
                TextBoxName.Text = grdrow.Cells[3].Text;
                TextBoxDesc.Text = grdrow.Cells[4].Text;
                ButtonAddCategory.Text = "Edit";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ButtonGridViewDelete_Click
        protected void ButtonGridViewDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
                TextBoxCode.Text = grdrow.Cells[2].Text;
                TextBoxName.Text = grdrow.Cells[3].Text;
                TextBoxDesc.Text = grdrow.Cells[4].Text;
                ButtonAddCategory.Text = "Delete";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ButtonAddCategory_Click
        protected void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    ErpDataContext db = new ErpDataContext();
                    if (ButtonAddCategory.Text == "Add")
                    {
                        db.AddCategory(LabelHeading.Text, TextBoxName.Text, TextBoxDesc.Text);
                        Globals.MessageBoxShow(this, "Saved Successfully");
                        Clear();
                    }
                    else if (ButtonAddCategory.Text == "Edit")
                    {
                        Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                        Match result = re.Match(TextBoxCode.Text);

                        string strCode = result.Groups[2].Value;
                        db.UpdateCategory(TextBoxName.Text, TextBoxDesc.Text, System.Convert.ToInt32(strCode));
                        Globals.MessageBoxShow(this, "Updated Successfully");
                        Clear();
                    }
                    else if (ButtonAddCategory.Text == "Delete")
                    {
                        Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                        Match result = re.Match(TextBoxCode.Text);

                        string strCode = result.Groups[2].Value;
                        db.DeleteCategory(LabelHeading.Text, System.Convert.ToInt32(strCode));
                        Globals.MessageBoxShow(this, "Deleted Successfully");
                        Clear();
                    }
                }
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

            if (string.IsNullOrEmpty(TextBoxName.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Name");
                TextBoxName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(TextBoxDesc.Text))
            {
                Globals.MessageBoxShow(this, "Please Enter Description");
                TextBoxDesc.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Clear
        private void Clear()
        {
            try
            {
                TextBoxCode.Text = "";
                TextBoxName.Text = "";
                TextBoxDesc.Text = "";
                ButtonAddCategory.Text = "Add";               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}