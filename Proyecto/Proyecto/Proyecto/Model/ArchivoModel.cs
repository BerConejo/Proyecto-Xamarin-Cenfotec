using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Model
{
    public class ArchivoModel
    {

        public int Id { get; set; }
        public string Archivo { get; set; }

        public ArchivoModel()
        {
        }

        public static async Task<ObservableCollection<ArchivoModel>> obtenerArchivos()
        {

            ObservableCollection<ArchivoModel> lstArchivo = new ObservableCollection<ArchivoModel>();

            for (int i = 0; i < 10; i++)
            {
                lstArchivo.Add(new ArchivoModel { Id = i + 1, Archivo = "Archivo Vacio" + Convert.ToString(i + 1) });
            }




            return lstArchivo;

        }
    }
}
