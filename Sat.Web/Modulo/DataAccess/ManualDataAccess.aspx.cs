using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Sat.Data;

namespace Sat.Web.Modulo.DataAccess
{
    public partial class ManualDataAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var dbContext = new AsistenciaTecnicaEntities())
            {
                var lista = (from s in dbContext.Solicitud
                    select s);

                var iqueryable = lista.AsQueryable();
                
                foreach (var solicitud in lista)
                {
                    CrearTabla(solicitud);
                }
            }
        }

        private void CrearTabla(Data.Solicitud solicitudes)
        {
            var fila = new HtmlTableRow();
            fila.Cells.Add(new HtmlTableCell() { InnerText = solicitudes.Cod_emp.ToString() });
            fila.Cells.Add(new HtmlTableCell() { InnerText = solicitudes.Solicitud1 });
            fila.Cells.Add(new HtmlTableCell() { InnerText = solicitudes.FechaCreacion.ToString()});

            tblSolicitudes.Rows.Add(fila);

        }
    }
}