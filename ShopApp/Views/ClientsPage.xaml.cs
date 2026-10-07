using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();

        var dbcontext = new ShopDbContext();

        foreach (var client in dbcontext.Clients)
        {
            container.Children.Add(new Label { Text = client.Nombre });
        }
    }
}