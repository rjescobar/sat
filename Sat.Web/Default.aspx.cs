using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sat.Web
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Session["XValor"] = "Valor";
            Session.Abandon();

            Application["xValor"] = "valor";

            var x = LoginID;
        }



        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //var bol = Page.IsValid;
            Trace.Warn("Personalizado", "Warning de usuario");
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (Page.IsValid)
                {
                    lblResultado.Text = txtNombre.Text + ' ' + txtApellido.Text;
                    //mas validaciones
                    if (!string.IsNullOrEmpty(txtNombre.Text))
                    {
                        //guradar.
                    }
                }
                else
                {
                    lblResultado.Text = string.Empty;
                }
            }

        }
    }
}