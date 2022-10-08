using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABM_Paises : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.limpioFormulario();
            this.desactivoBotones();
        }
    }

    private void limpioFormulario()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
    }

    private void desactivoBotones()
    {
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
    }

    private void activoBotones()
    {
        btnAlta.Enabled = true;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        btnBuscar.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string pPais = txtCodigo.Text;
            Pais pais = LogicaPais.Buscar(pPais);
            if (pais != null)
            {
                txtCodigo.Text = pais.CoPais;
                txtNombre.Text = pais.Nombre;

                Session["SPais"] = pais;

                btnAlta.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnAlta.Enabled = true;

                Session["SPais"] = null;
                Response.Write("No existe el pais en el sistema");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            string codigo, nombre;

            codigo = txtCodigo.Text.Trim();
            nombre = txtNombre.Text.Trim();

            Pais pais = new Pais(codigo, nombre);

            LogicaPais.Agregar(pais);
            Response.Write("Alta con Exito");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            throw;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pais = (Pais)Session["SPais"];
            pais.CoPais = txtCodigo.Text;
            pais.Nombre = txtNombre.Text;

            LogicaPais.Modificar(pais);
            Response.Write("Modificacion Exitosa");

            this.limpioFormulario();
            this.desactivoBotones();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pais = (Pais)Session["SPais"];

            LogicaPais.Eliminar(pais);
            Response.Write("Eliminacion exitosa");

            this.limpioFormulario();
            this.desactivoBotones();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
    }
}