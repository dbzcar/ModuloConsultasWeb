using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModuloConsultasWeb.App_Code.Dal;
using System.Web.Security;

namespace ModuloConsultasWeb.WebForm.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Autenticacion.Autenticar(txtUsername.Value, txtPassword.Value))
            {
                
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Value,true);

                
            }

            
        }
    }
}