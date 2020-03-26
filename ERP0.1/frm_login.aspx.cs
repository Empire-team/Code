using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Data;

namespace ERP
{

    public partial class frm_login : System.Web.UI.Page
    {

        public string
        password,
        username;
    

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                password = txt_password.Text;
                username = txt_username.Text;

                string connetionString = null;
                string strServerName = "", strDatabase = "", strUid = "", strPassword = "";
                MySqlConnection cnn;
                // You'll need to put the correct path to your xml file here
                XmlDocument xml = new XmlDocument();
                xml.Load("G://Empire Projects//ERP//Code//ERP0.1//Settings.xml");
                // Select a specific node
                XmlNode node = xml.SelectSingleNode("Settings/SERVER");
                // Get its value
                strServerName = node.InnerText;
                //fetching db name from xml
                node = xml.SelectSingleNode("Settings/DATABASE");
                strDatabase = node.InnerText;
                //fetching user id from xml
                node = xml.SelectSingleNode("Settings/USER");
                strUid = node.InnerText;
                //fetching user id from xml
                node = xml.SelectSingleNode("Settings/PASSWORD");
                strPassword = node.InnerText;

                connetionString = "Server ="+ strServerName + "; Database ="+ strDatabase+"; Uid = "+strUid+"; Pwd = "+strPassword;
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                String query = "";
                query = "sp_login";   //stored procedure Name
                MySqlCommand com = new MySqlCommand(query, cnn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@p_username", username);   //for username 
                com.Parameters.AddWithValue("@p_password", password);  //for password
                Int32 usercount = 0;
                usercount = System.Convert.ToInt32(com.ExecuteScalar());// for taking single value
                if (usercount == 1)  // comparing users from table 
                {
                    query = "select user_type from login where UserName = '" + username +"';";
                    com = new MySqlCommand(query, cnn);
                    string strUserType = com.ExecuteScalar().ToString();
                    if(strUserType == "admin") 
                    {
                        Response.Redirect("frm_adminHome.aspx");  //for successful admin login
                    }
                    else
                    {
                        Response.Redirect("frm_home.aspx"); //for successful end-user login
                    }
                }
                else
                {
                    Label1.Text = "Invalid User Name or Password";  //for invalid login
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}