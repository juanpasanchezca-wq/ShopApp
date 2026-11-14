using ShopApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Services
{
    public class DatabaseRutaService : IDatabaseRutaService
    {
        public string get(string nombreArchivo)
        {
            var rutaDirectorio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(rutaDirectorio, nombreArchivo);
        }
    }
}
