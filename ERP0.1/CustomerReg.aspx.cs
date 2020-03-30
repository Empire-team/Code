using ErpContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Devart.Data.Linq;
using System.Reflection;

namespace ERP
{
    public partial class CustomerReg : System.Web.UI.Page
    {
        public string strDisplayName = "Customer Registration";
      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ErpDataContext db = new ErpDataContext();
                    DataTable dtCountry = new DataTable();
                    var result = db.SpCountry();
                    dtCountry = ObtainDataTableFromIEnumerable(result);

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


        public DataTable ObtainDataTableFromIEnumerable(System.Collections.IEnumerable ien)
        {
            try
            {
                DataTable dt = new DataTable();

                foreach (object obj in ien)
                {


                    Type t = obj.GetType();

                    PropertyInfo[] pis = t.GetProperties();

                    if (dt.Columns.Count == 0)

                    {

                        foreach (PropertyInfo pi in pis)
                        {
                            dt.Columns.Add(pi.Name, pi.PropertyType);
                        }
                    }

                    DataRow dr = dt.NewRow();

                    foreach (PropertyInfo pi in pis)
                    {
                        object value = pi.GetValue(obj, null);

                        dr[pi.Name] = value;
                    }

                    dt.Rows.Add(dr);

                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Load Values to TextBox
        public void LoadValues(CustomerReg parent, string strCusId, string strCusName, string strGender, string strAddress, string strCity, string strState, string strZipCode, string strCountry, string strPhno, string strEmail, string strGstNo)
        {
            try
            {
                TextBoxCusId = new TextBox();
                TextBoxCusId.Text = strCusId;
                TextBoxCusName = new TextBox();
                TextBoxCusName.Text = strCusName;
                DropDownListGender = new DropDownList();
                DropDownListGender.SelectedValue = strGender;
                TextBoxCusAddress = new TextBox();
                TextBoxCusAddress.Text = strAddress;
                TextBoxCity = new TextBox();
                TextBoxCity.Text = strCity;
                TextBoxState = new TextBox();
                TextBoxState.Text = strState;
                TextBoxZipCode = new TextBox();
                TextBoxZipCode.Text = strZipCode;
                DropDownListCountry = new DropDownList();
                DropDownListCountry.SelectedValue = strCountry;
                TextBoxCusPhno = new TextBox();
                TextBoxCusPhno.Text = strPhno;
                TextBoxEmail = new TextBox();
                TextBoxEmail.Text = strEmail;
                TextBoxGSTNo = new TextBox();
                TextBoxGSTNo.Text = strGstNo; 
                //Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                IsValidData();
                ErpDataContext db = new ErpDataContext();
                string strcountry = DropDownListCountry.SelectedItem.Text;
                db.SpAccountdetail(strDisplayName, TextBoxCusName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxCusAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedItem.ToString(), TextBoxCusPhno.Text, TextBoxEmail.Text, TextBoxGSTNo.Text);
                ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + "Saved Successfully" + "');", true);
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

        protected void ButtonViewRegistration_Click(object sender, EventArgs e)
        {
          ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('frm_ViewCustomerReg.aspx','mywindow','menubar=1,resizable=1,width=900,height=600,position:absolute');", true);
            
        }
    }
}