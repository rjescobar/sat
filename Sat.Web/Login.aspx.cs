using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sat.Data;
using Sat.Library;

namespace Sat.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private String ReturnUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
                Response.Redirect("~/Default.aspx");

            if (Request.QueryString["ReturnUrl"] != null
               && !string.IsNullOrWhiteSpace(Request.QueryString["ReturnUrl"]))
            {
                ReturnUrl = Request.QueryString["ReturnUrl"];
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text.Trim())
                || string.IsNullOrWhiteSpace(txtClave.Text.Trim()))
            {
                var script = string.Format("toastr.error('{0}', 'Error' )", "Los valores no pueden ser vacios.");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorScript", script, true);
                //salir del metodo.
                return;
            }

            var nombreUsuario = txtUsuario.Text.Trim();
            var claveUsuario = txtClave.Text.Trim();

            using (var dbContext = new AsistenciaTecnicaEntities())
            {
                /*Validar el nombre del usuario si existe*/
                var usuario = (from u in dbContext.Usuario
                               where u.Usuario1.Equals(nombreUsuario)
                               select u).ToList().FirstOrDefault();

                //El usuario existe!
                if (usuario != null)
                {
                    var cripto = new PBKDF2();
                    Boolean verify = cripto.VerifyHashedPassword(usuario.Clave, claveUsuario);

                    if (verify)
                    {
                        /*Variables de sesion*/
                        Session["NOMBRE_USUARIO"] = usuario.Nombre;
                        //

                        /*Metodos para autenticar la sesion del usuario.*/
                        FormsAuthentication.SetAuthCookie("username", true);

                        if (!string.IsNullOrWhiteSpace(ReturnUrl))
                        {
                            Response.Redirect(ReturnUrl, false);
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }

                    }
                }
            }
        }
    }
}