using ExamenPuleVictor.Models;

namespace ExamenPuleVictor;

public partial class Clientes : ContentPage
{
    private string ApiUrlCli = "https://utncloudcomputingapiclientes.azurewebsites.net/api/Clientes";
    public Clientes()
	{
		InitializeComponent();
	}

    private void cmdCreateClie_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
            string.IsNullOrWhiteSpace(txtApellidoCliente.Text) ||
            string.IsNullOrWhiteSpace(txtDireccion.Text) ||
            string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) ||
            string.IsNullOrWhiteSpace(txtTelefono.Text) ||
            string.IsNullOrWhiteSpace(txtTrabajoId.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        var cliente = APIConsumer.Crud<Cliente>.Create(ApiUrlCli, new Cliente
        {
            Id = 0,
            Nombre = txtNombreCliente.Text,
            Apellido = txtApellidoCliente.Text,
            Direccion = txtDireccion.Text,
            CorreoElectronico = txtCorreoElectronico.Text,
            Telefono = txtTelefono.Text,
            TrabajoId = int.Parse(txtTrabajoId.Text)
        });
        if (cliente != null)
        {
            DisplayAlert("Éxito", "Cliente Creado con exito", "OK");
            txtTrabajoId.Text = cliente.Id.ToString();
        }
    }

    private void cmdLeerClie_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del Cliente que desea buscar.", "OK");
            return;
        }
        var (prod, found) = APIConsumer.Crud<Cliente>.Read_ById(ApiUrlCli, int.Parse(txtIdCliente.Text));
        if (found)
        {
            txtTrabajoId.Text = prod.Id.ToString();
            txtNombreCliente.Text = prod.Nombre.ToString();
            txtApellidoCliente.Text = prod.Apellido.ToString();
            txtDireccion.Text = prod.Direccion.ToString();
            txtCorreoElectronico.Text = prod.CorreoElectronico.ToString();
            txtTelefono.Text = prod.Telefono.ToString();
            txtTrabajoId.Text = prod.TrabajoId.ToString();
        }
        else
        {
            DisplayAlert("Error", "No existe el Cliente", "OK");
        }
    }

    private void cmdUpdateClie_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) ||
            string.IsNullOrWhiteSpace(txtApellidoCliente.Text) ||
            string.IsNullOrWhiteSpace(txtDireccion.Text) ||
            string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) ||
            string.IsNullOrWhiteSpace(txtTelefono.Text) ||
            string.IsNullOrWhiteSpace(txtTrabajoId.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Cliente>.Update(ApiUrlCli, int.Parse(txtIdCliente.Text), new Cliente
        {
            Id = int.Parse(txtIdCliente.Text),
            Nombre = txtNombreCliente.Text,
            Apellido = txtApellidoCliente.Text,
            Direccion = txtDireccion.Text,
            CorreoElectronico = txtCorreoElectronico.Text,
            Telefono = txtTelefono.Text,
            TrabajoId = int.Parse(txtTrabajoId.Text)
        });
        if (!success)
        {
            DisplayAlert("Error", "Actualización fallida. El Cliente no existe.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Cliente actualizado correctamente.", "OK");
        }
    }

    private void cmdDeleteClie_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
        {
            DisplayAlert("Error", "Ingrese el ID del producto que desea eliminar.", "OK");
            return;
        }
        bool success = APIConsumer.Crud<Cliente>.Delete(ApiUrlCli, int.Parse(txtIdCliente.Text));
        if (!success)
        {
            DisplayAlert("Error", "Cliente no encontrado para eliminar.", "OK");
        }
        else
        {
            DisplayAlert("Éxito", "Cliente eliminado correctamente.", "OK");
            txtTrabajoId.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            txtDireccion.Text = "";
            txtCorreoElectronico.Text = "";
            txtTelefono.Text = "";
            txtTrabajoId.Text = "";

        }
    }

    private void cmdRegresar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Trabajos());
    }

    private void cmdMenu_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}