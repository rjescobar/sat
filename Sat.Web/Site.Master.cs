using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sat.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            /*Eliminar todas las variables de sesion.*/
            Session.Clear();
            Session.Abandon();
            /*Eliminar el cookie de autenticacion*/
            FormsAuthentication.SignOut();
            /*Redirecciona a la pagina de login de usuario*/
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}