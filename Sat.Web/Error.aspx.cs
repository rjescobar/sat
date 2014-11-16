using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sat.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            if (exception != null)
            {
                var type = exception.GetType().Name;

                //enviar un mensaje, email.

                String mensajePersonalizado;

                if (exception is ArgumentOutOfRangeException)
                {

                }
                else if (exception is HttpException)
                {

                }
                else if (exception is SqlException)
                {

                }
                else if (exception is NullReferenceException)
                {

                }



                switch (type)
                {
                    case "HttpException":
                        mensajePersonalizado = "Ha ocurrido un error en la página";
                        break;
                    case "ArgumentOutOfRangeException":
                        mensajePersonalizado = "El argumento esta fuera de los parametros";
                        break;
                    default:
                        mensajePersonalizado = exception.Message;
                        break;
                }

                var sesion = Session;

                var trace = exception.StackTrace;
                lblMessage.Text = mensajePersonalizado;
                Server.ClearError();
            }



        }
    }
}