using Plugin.Media;
using Proyecto.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyecto.ViewModel
{
    class SeguimientoViewModel : INotifyPropertyChanged
    {

        #region Singleton
        private static SeguimientoViewModel instance = null;

        private SeguimientoViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static SeguimientoViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new SeguimientoViewModel();
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


        #region Seccion1
        private string _NumBoleta { get; set; }

        public string NumBoleta
        {
            get
            {
                return _NumBoleta;
            }
            set
            {
                _NumBoleta = value;
            }

        }

        private string _Analista { get; set; }

        public string Analista
        {
            get
            {
                return _Analista;
            }
            set
            {
                _Analista = value;
            }

        }

        private TimeSpan _HoraInicio;

        public TimeSpan HoraInicio
        {
            get
            {
                return _HoraInicio;
            }
            set
            {
                _HoraInicio = value;
            }
        }

        private TimeSpan _HoraFin;

        public TimeSpan HoraFin
        {
            get
            {
                return _HoraFin;
            }
            set
            {
                _HoraFin = value;
            }
        }

        private int _LugarAsistencia;
        public int LugarAsistencia
        {
            get
            {
                return _LugarAsistencia;
            }
            set
            {
                if (_LugarAsistencia != value)
                {
                    _LugarAsistencia = value;

                }
            }
        }

        private int _EstadoOrden;
        public int EstadoOrden
        {
            get
            {
                return _EstadoOrden;
            }
            set
            {
                if (_EstadoOrden != value)
                {
                    _EstadoOrden = value;

                }
            }
        }

        private string _Version { get; set; }

        public string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }

        }

        private DateTime _Fecha { get; set; }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }
            set
            {
                _Fecha = value;
            }

        }

        private string _OrdenTransferida { get; set; }

        public string OrdenTransferida
        {
            get
            {
                return _OrdenTransferida;
            }
            set
            {
                _OrdenTransferida = value;
            }

        }

        #endregion Seccion1

        #region Seccion2

        private string _CarpetaTrabajo { get; set; }

        public string CarpetaTrabajo
        {
            get
            {
                return _CarpetaTrabajo;
            }
            set
            {
                _CarpetaTrabajo = value;
            }

        }

        private string _ArchivosModificados { get; set; }

        public string ArchivosModificados
        {
            get
            {
                return _ArchivosModificados;
            }
            set
            {
                _ArchivosModificados = value;
            }

        }

        private string _CamposModificados { get; set; }

        public string CamposModificados
        {
            get
            {
                return _CamposModificados;
            }
            set
            {
                _CamposModificados = value;
            }
        }

        private string _Observaciones { get; set; }

        public string Observaciones
        {
            get
            {
                return _Observaciones;
            }
            set
            {
                _Observaciones = value;
            }
        }


        public ICommand AdjuntarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }

        #endregion Seccion2




        #endregion Instances

        #region Methods

        private async void GuardarSeguimiento()
        {

            DateTime dateInicio =  Convert.ToDateTime(Ayuda.Left(Convert.ToString(DateTime.Now),10) + Convert.ToString(HoraInicio));
            DateTime dateFin = Convert.ToDateTime(Ayuda.Left(Convert.ToString(DateTime.Now), 10) + Convert.ToString(HoraFin));

            if (SeguimientoModel.GuardarSeguimiento(NumBoleta, Analista, Convert.ToString(LugarAsistencia), Observaciones, CarpetaTrabajo,
                ArchivosModificados, CamposModificados, Version, Convert.ToString(EstadoOrden), OrdenTransferida,
                Convert.ToDateTime(Fecha), dateInicio, dateFin))
            {
                await App.Current.MainPage.DisplayAlert("Orden almacenada", "El registro de la orden fue almacenado correctamente", "Ok");

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error al almacenar", "El registro de la orden posee un error.", "Ok");
            }
        }

        public async void adjuntar()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Photos Not Supported", "Permission not granted to photos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });


            if (file == null)
                return;

            var stream = file.GetStream();
            file.GetStream();

            var a = file.Path;
        }

        private async Task InitClass()
        {

            

        }

        private void InitCommands()
        {
            Fecha = DateTime.Now;
            GuardarCommand = new Command(GuardarSeguimiento);
            AdjuntarCommand = new Command(adjuntar);
        }

        #endregion Methods

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
