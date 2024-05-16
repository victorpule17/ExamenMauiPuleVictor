namespace ExamenPuleVictor;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void cmdClientes_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Clientes());
    }

    private void cmdTrabajos_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Trabajos());
    }
}