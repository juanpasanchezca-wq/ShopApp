using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAcces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Views
{
    public partial class ResumenViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        private int visitas;

        [ObservableProperty]
        private decimal total;

        [ObservableProperty]
        private int clients;

        [ObservableProperty]
        private int totalProducts;

        public ResumenViewModel(ShopOutDbContext shopOutDbContext)
        {
            var db = new ShopDbContext();

            Visitas = shopOutDbContext.Compras
                .ToList()
                .DistinctBy(s => s.ClienteId)
                .ToList()
                .Count();

            Total = shopOutDbContext.Compras.ToList().Sum(s => s.Cantidad * s.Precio);
            TotalProducts = shopOutDbContext.Compras.Sum(s => s.Cantidad);
        }
    }
}
