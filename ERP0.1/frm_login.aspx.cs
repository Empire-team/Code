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
            password = txt_password.Text;
            username = txt_username.Text;


        }

        protected void txt_username_TextChanged(object sender, EventArgs e)
        {

        }



    }
}