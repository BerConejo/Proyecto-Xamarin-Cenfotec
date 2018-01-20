using Proyecto.Model;
using Proyecto.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Proyecto.ViewModel
{
    public class IngresoViewModel
    {
        #region Singleton

        private static IngresoViewModel instance = null;

        private IngresoViewModel()
        {
            InitClass();
        }

        public static IngresoViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new IngresoViewModel();
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

        #region Methods

        private void InitClass()
        {
            if (LoginModel.RecordarUsuario())
            {
                AbreMenuPrincipal();
            }
            else
            {
                App.Current.MainPage = new LoginPage();
            }
        }

        private void AbreMenuPrincipal()
        {
            NavigationPage navigation = new NavigationPage(new HomePage());

            navigation.BarBackgroundColor = Color.FromHex("#3e91a3");

            App.Current.MainPage = new MasterDetailPage
            {
                Master = new HomeMenu(),
                Detail = navigation,

            };
        }

        #endregion Methods
    }
}
