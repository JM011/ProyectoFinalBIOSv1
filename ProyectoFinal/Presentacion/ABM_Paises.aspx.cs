using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        //btnBuscar.Enabled = false;
    }

    private void activoBotones()
    {
        btnAlta.Enabled = true;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        //btnBuscar.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {

    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {

    }
}