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
        ClsGoogleProfile profile = new ClsGoogleProfile();
        protected void Page_Load(object sender, EventArgs e)
        {
            GoogleConnect.ClientId = "779744404878-p98n0epspv3gpnq05k5s596am3og7ekq.apps.googleusercontent.com";
            GoogleConnect.ClientSecret = "nSVPZIW2NSRCn2FuMuV9GvsQ";

            GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];


            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {

                string code = Request.QueryString["code"];
                string json = GoogleConnect.Fetch("me", code);
                ClsGoogleProfile profile = new JavaScriptSerializer().Deserialize<ClsGoogleProfile>(json);
                //lblId.Text = profile.Id;
                //lblName.Text = profile.DisplayName;
                //lblEmail.Text = profile.Emails.Find(email => email.Type == "account").Value;
                //lblGender.Text = profile.Gender;
                //lblType.Text = profile.ObjectType;
                //ProfileImage.ImageUrl = profile.Image.Url;
                //pnlProfile.Visible = true;

                string Verificaemail = profile.Emails.Find(email => email.Type == "account").Value;
                
                if (Verificaemail.Contains("@miumg.edu.gt"))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "alert('Correcto')", true);
                    FormsAuthentication.RedirectFromLoginPage(profile.DisplayName, true);
                }

                else
                {
                    GoogleConnect.Clear(Request.QueryString["code"]);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alerta", "alert('Introduzca Correo Correcto')", true);
                }


            }
            if (Request.QueryString["error"] == "access_denied")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Accesso Denegado.')", true);
            }
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
        }

        protected void Clear(object sender, EventArgs e)
        {
            GoogleConnect.Clear(Request.QueryString["code"]);
        }
    }
}