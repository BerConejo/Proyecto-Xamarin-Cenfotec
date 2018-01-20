using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Proyecto.Model;
using Proyecto.View;
using Android.Accounts;

namespace Proyecto.ViewModel
{
    class LoginViewModel  : INotifyPropertyChanged
    {
        #region Instances

        public ICommand LoginCommand { get; set; }
        public ICommand SelectCurrencyCommand { get; set; }
        LoginModel LoginModel = new LoginModel();

        private string _User { get; set; }

        public string User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
            }

        }

        private string _Password { get; set; }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }

        }

        private bool _Checked { get; set; }
        public bool Checked { get { return _Checked; } set { _Checked = value; OnPropertyChanged("Checked"); } }


        #endregion
        public LoginViewModel()
        {
            InitCommands();
        }

        #region Methods
        private void Login()
        {


            LoginModel miUsuario = LoginModel.ValidarUsuario(User, Password);
            if (miUsuario != null)
            {
                if (Checked == true)
                {
                    GuardarUsuario(miUsuario);
                }

                NavigationPage navigation = new NavigationPage(new HomePage());

                navigation.BarBackgroundColor = Color.FromHex("#3e91a3");

                App.Current.MainPage = new MasterDetailPage
                {
                    Master = new HomeMenu(),
                    Detail = navigation,

                };

                User = string.Empty;
                Password = string.Empty;
                Checked = false;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error de validacion", "Usuario o password incorrecto", "Ok");
            }
        }

        private void GuardarUsuario(LoginModel pUsuario)
        {
            LoginModel.GuardarUsuario(pUsuario);
        }
   

        private void SelectCurrency()
        {
            Checked = !Checked;
        }

        private void InitCommands()
        {
            LoginCommand = new Command(Login);
            SelectCurrencyCommand = new Command(SelectCurrency);
            if (string.IsNullOrEmpty(Proyecto.Helpers.Settings.RememberUserName))
            {
                
            }
            else
            {
                var a = Proyecto.Helpers.Settings.RememberUserName;
            }
        }


        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
