using System;
using System.Data;
using System.Linq;
using Sat.Data;

namespace Sat.Web.Modulo.Empleados
{
    public partial class Empleado : System.Web.UI.Page
    {
        private Data.Empleados _empleado = new Data.Empleados();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["id"] == null)
            {
                Response.Redirect("~/Modulo/DataAccess/DataSample.aspx");
            }

            int id;
            if (int.TryParse(Request.Params["id"], out id))
            {
                using (var dbContext = new AsistenciaTecnicaEntities())
                {
                    _empleado = (from emp in dbContext.Empleados
                                 where emp.cod_emp == id
                                 select emp).FirstOrDefault();

                    if (_empleado == null)
                    {
                        Response.Redirect("~/Modulo/DataAccess/DataSample.aspx");
                    }

                }
            }


            if (!Page.IsPostBack)
            {
                CargarDatos(_empleado);
            }



        }

        private void CargarDatos(Data.Empleados empleado)
        {
            txtEmail.Text = empleado.e_mail;
            txtNombre.Text = empleado.nombres;
            txtApellido.Text = empleado.apellidos;
            txtCedula.Text = empleado.cedula;
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
                        //Validaciones en code behind.
                        _empleado.nombres = txtNombre.Text;
                        _empleado.apellidos = txtApellido.Text;
                        _empleado.e_mail = txtEmail.Text;
                        _empleado.cedula = txtCedula.Text;

                        using (var dbContext = new AsistenciaTecnicaEntities())
                        {
                            try
                            {
                                dbContext.Entry(_empleado).State = EntityState.Modified;
                                
                                dbContext.SaveChanges();

                                var script = "toastr.success('Registro guardado correctamente!', 'Ok')";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "OkScript", script, true);
                                
                                CargarDatos(_empleado);


                            }
                            catch (Exception)
                            {

                                throw;
                            }

                        }
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