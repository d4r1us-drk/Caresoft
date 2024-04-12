using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caresoft__web
{
    public partial class Cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(userbox.Value) || string.IsNullOrEmpty(passwordbox.Value))
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Redirect("/Cuenta");
            }
        }

        protected void registrarse_Click(object sender, EventArgs e)
        {

        }
    }
}