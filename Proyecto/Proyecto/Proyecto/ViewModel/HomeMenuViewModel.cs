using Proyecto.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Proyecto.View;
using System.Windows.Input;

namespace Proyecto.ViewModel
{
    class HomeMenuViewModel : INotifyPropertyChanged
    {
  

        #region Singleton

        private static HomeMenuViewModel instance = null;

        private HomeMenuViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static HomeMenuViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new HomeMenuViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        #endregion Singleton

        #region Instances

        private List<HomeMenuModel> lstOriginalMenuDesplegable = new List<HomeMenuModel>();


        private ObservableCollection<HomeMenuModel> _lstMenuDesplegable = new ObservableCollection<HomeMenuModel>();
        public ObservableCollection<HomeMenuModel> lstMenuDesplegable
        {
            get
            {
                return _lstMenuDesplegable;
            }
            set
            {
                _lstMenuDesplegable = value;
                OnPropertyChanged("lstMenuDesplegable");
            }
        }

        //Instancias de los comandos
        public ICommand SeleccionaPaginaCommand { get; set; }

        #endregion Instances

        #region methods

        private  void SeleccionaPagina(int id)
        {

            switch (id)
            {
                case 1:

                    ((MasterDetailPage)App.Current.MainPage).Navigation.PushModalAsync(new Orden());

                    break;
                case 2:

                    ((MasterDetailPage)App.Current.MainPage).Navigation.PushModalAsync(new Seguimiento());
                    break;
                case 3:

                //    ((MasterDetailPage)App.Current.MainPage).Navigation.PushModalAsync(new LoginPage());
                //    break;
                //case 4:

                    loguot();
                    break;
            }


        }

        private async void loguot()
        {
            bool resp = await App.Current.MainPage.DisplayAlert("", "Seguro que desea salir?", "Yes", "No");
            if (resp == true)
            {
                LoginModel.OlvidarUsuario();
                App.Current.MainPage = new LoginPage();
            }
        }

        private async Task InitClass()
        {
            lstMenuDesplegable = await HomeMenuModel.MenuDesplegable();
            lstOriginalMenuDesplegable = lstMenuDesplegable.ToList();
        }

        private void InitCommands()
        {
            SeleccionaPaginaCommand = new Command<int>(SeleccionaPagina);
        }

        #endregion methods

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}
