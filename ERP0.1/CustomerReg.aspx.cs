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

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                IsValidData();
                ErpDataContext db = new ErpDataContext();
                string strcountry = DropDownListCountry.SelectedItem.Text;
                db.SpAccountdetail(strDisplayName, TextBoxCusName.Text, DropDownListGender.SelectedValue.ToString(), TextBoxCusAddress.Text, TextBoxCity.Text, TextBoxState.Text, TextBoxZipCode.Text, DropDownListCountry.SelectedItem.ToString(), TextBoxCusPhno.Text, TextBoxEmail.Text, TextBoxGSTNo.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Saved Successfully" + "');", true);
                //Response.Write("Saved Successfully");
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
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('frm_ViewCustomerReg.aspx','mywindow','menubar=1,resizable=1,width=900,height=600,position=center');", true);
            //window.open('Popup.aspx', 'pagename', 'resizable=no,width=200,height=400');
        }
    }
}