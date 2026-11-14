using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly ShopOutDbContext _outDbContext;

    [ObservableProperty]
    private int clienteId;

    [ObservableProperty]
    private ObservableCollection<Compra> compras = new ObservableCollection<Compra>();

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product productoSeleccionado;

    [ObservableProperty]
    private int cantidad;

    public ICommand AddCommand { get; set; }

    public HelpSupportDetailViewModel(
        ShopOutDbContext outDbContext)
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        AddCommand = new MiComando(() =>
        {
            var compra = new Compra(
                ClienteId, 
                ProductoSeleccionado.Id, 
                Cantidad,
                ProductoSeleccionado.Nombre,
                ProductoSeleccionado.Precio,
                productoSeleccionado.Precio * Cantidad
                );
            Compras.Add(compra);
        },
        () => true);

        _outDbContext = outDbContext;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClienteId = clientId;
    }
    private async Task EnviarCompra()
    {
        _outDbContext.Database.EnsureCreated();

        foreach (var item in Compras)
        {
            _outDbContext.Compras.Add(new CompraItem(
                item.ClienteId, item.ProductId, item.Cantidad, item.ProductoPrecio));
        }

        await _outDbContext.SaveChangesAsync();

        await Shell.Current.DisplayAlert("Éxito", "Compra guardada localmente en la base de datos SQLite", "OK");
    }



}