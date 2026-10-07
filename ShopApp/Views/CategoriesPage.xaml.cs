using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class CategoriesPage : ContentPage
{
    public CategoriesPage()
    {
        InitializeComponent();

        var dbcontext = new ShopDbContext();

        foreach (var category in dbcontext.Categories)
        {
            container.Children.Add(new Label { Text = category.Nombre });

        }
    }
}