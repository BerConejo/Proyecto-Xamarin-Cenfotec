using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using System.Threading.Tasks;

namespace Proyecto.Model
{
    public class HomeMenuModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string IconBegin { get; set; }
        public string IconEnd { get; set; }

        public HomeMenuModel()
        {

        }


        public static async Task<ObservableCollection<HomeMenuModel>> MenuDesplegable()
        {

            ObservableCollection<HomeMenuModel> lstHomeMenu = new ObservableCollection<HomeMenuModel>();


            lstHomeMenu.Add(new HomeMenuModel { ID = 1, Title = "Ordenes", IconBegin = "Plus.png", IconEnd = "Direccion.png" });
            lstHomeMenu.Add(new HomeMenuModel { ID = 2, Title = "Seguimiento", IconBegin = "Message.png", IconEnd = "Direccion.png" });
            //lstHomeMenu.Add(new HomeMenuModel { ID = 3, Title = "Reporte de Actividades", IconBegin = "Report.png", IconEnd = "Direccion.png" });
            lstHomeMenu.Add(new HomeMenuModel { ID = 3, Title = "Logout", IconBegin = "Logout.png", IconEnd = "Direccion.png" });


            return lstHomeMenu;
        }


    }
}
