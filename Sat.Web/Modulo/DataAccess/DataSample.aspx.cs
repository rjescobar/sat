using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sat.Web.Modulo.DataAccess
{
    public partial class DataSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EntityDataSource2_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Editar":
                    //redireccionar
                    Response.Redirect(string.Format("~/Modulo/Empleados/Empleado.aspx?id={0}", e.CommandArgument));
                    break;

            }

        }
    }
}