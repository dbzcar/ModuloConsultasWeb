using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModuloConsultasWeb.App_Code.Dal;
using System.Web.Security;
using System.Text;
using System.Net;
using System.IO;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using ModuloConsultasWeb.App_Code.Modelos;

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

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            GoogleConnect.Authorize("profile", "email");
            //your client id   
            string clientid = "779744404878-p98n0epspv3gpnq05k5s596am3og7ekq.apps.googleusercontent.com";
            //your client secret   
            string clientsecret = "nSVPZIW2NSRCn2FuMuV9GvsQ";
            //your redirection url   
            string redirection_url = "http://localhost:64248/WebForm/Clientes/WebCliente.aspx";
            string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=profile&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
            Response.Redirect(url);

        }
    }
}