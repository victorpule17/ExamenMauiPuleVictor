using ExamenPuleVictor.Models;

namespace ExamenPuleVictor;

public partial class Trabajos : ContentPage
{
    private string ApiUrlTra = "https://utncloudcomputingapiclientes.azurewebsites.net/api/Trabajos";
    public Trabajos()
	{
		InitializeComponent();
	}

    private void cmdCrearTra_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTrabajo.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        var resultado = APIConsumer.Crud<Trabajo>.Create(ApiUrlTra, new Trabajo
        {
            Id = 0,
            nombreTrabajo = txtTrabajo.Text
        });

        if (resultado != null)
        {
            DisplayAlert("Éxito", "Clasificación Creada con exito", "OK");
            txtIdTrabajo.Text = resultado.Id.ToString();
        }
    }

    private void cmdLeerTra_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdTrabajo.Text))
        {
            DisplayAlert("Error", "Ingrese el ID de la Trabajo que desea buscar.", "OK");
            return;
        }
        var (trabajo, found) = APIConsumer.Crud<Trabajo>.Read_ById(ApiUrlTra, int.Parse(txtIdTrabajo.Text));
        if (found)
        {
            txtIdTrabajo.Text = trabajo.Id.ToString();
            txtTrabajo.Text = trabajo.nombreTrabajo;
        }
        else
        {
            DisplayAlert("Error", "Trabajo no encontrado", "OK");
            txtIdTrabajo.Text = "";
            txtTrabajo.Text = "";
        }
    }

    private void cmdActualizarTra_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdTrabajo.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Trabajo>.Update(ApiUrlTra, int.Parse(txtIdTrabajo.Text), new Trabajo
        {
            Id = int.Parse(txtIdTrabajo.Text),
            nombreTrabajo = txtTrabajo.Text
        });
        if (!success)
        {
            DisplayAlert("Error", "Actualización fallida. El trabajo no existe o no pudo actualizarse.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Trabajo actualizado correctamente.", "OK");
        }
    }

    private void cmdEliminarTra_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdTrabajo.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del Trabajo que desea eliminar.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Trabajo>.Delete(ApiUrlTra, int.Parse(txtIdTrabajo.Text));
        if (!success)
        {
            DisplayAlert("Error", "Eliminar fallido. El trabajo no existe o no pudo eliminarse.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Trabajo eliminada correctamente.", "OK");
            txtIdTrabajo.Text = "";
            txtTrabajo.Text = "";
        }
    }

    private void cmdClientes_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clientes());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}