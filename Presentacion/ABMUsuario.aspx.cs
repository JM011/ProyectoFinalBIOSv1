using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LimpioFormulario();
            this.DesactivoBotones();
        }
    }

    private void LimpioFormulario()
    {
        txtUsuario.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtContrasena.Text = "";
        ActivoTxt();
    }

    private void ActivoTxt()
    {
        txtUsuario.Enabled = true;
    }

    private void DesactivoBotones()
    {
        btnAlta.Enabled = false;
        BtnModificar.Enabled = false;
        btnBaja.Enabled = false;
        btnBuscar.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string pUser = txtUsuario.Text;
            Usuario usuario = LogicaUsuario.Buscar(pUser);

            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;

                Session["SUsuario"] = usuario;

                btnBaja.Enabled = true;
                BtnModificar.Enabled = true;
                btnAlta.Enabled = false;
            }
            else
            {
                btnAlta.Enabled = true;

                Session["SUsuario"] = null;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            Label1.Text = "Test";
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            string logId, nombre, apellido, contrasena;

            logId = txtUsuario.Text.Trim();
            nombre = txtNombre.Text.Trim();
            apellido = txtApellido.Text.Trim();
            contrasena = txtContrasena.Text.Trim();

            Usuario usuario = new Usuario(logId, contrasena, nombre, apellido);

            LogicaUsuario.Agregar(usuario);
            lblError.Text = "Alta con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            throw;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = (Usuario)Session["SUsuario"];
            usuario.Logid = txtUsuario.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Contrasena = txtContrasena.Text.Trim();

            LogicaUsuario.Modificar(usuario);
            lblError.Text = "Modificación Éxitosa";

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = (Usuario)Session["SUsuario"];

            LogicaUsuario.Eliminar(usuario);
            lblError.Text = "Eliminación Éxitosa";

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtUsuario.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtContrasena.Text = "";
    }
}