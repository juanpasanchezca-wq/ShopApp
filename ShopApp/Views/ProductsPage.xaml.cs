using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var dbcontext = new ShopDbContext();

		foreach (var product in dbcontext.Products)
		{
            var boton = new Button { Text = product.Nombre };
            boton.Clicked += async (s, e) =>
            {
                var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
                await Shell.Current.GoToAsync(uri);
            };

            container.Children.Add(boton);
        }
	}
}