using Proyecto.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;
using Proyecto.View;
using System.Linq;

namespace Proyecto.ViewModel
{
    public class OrdenViewModel : INotifyPropertyChanged
    {


        #region Singleton
        private static OrdenViewModel instance = null;

        private OrdenViewModel()
        {
            InitClass();
            InitCommands();
        }

        public static OrdenViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new OrdenViewModel();
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


        #region Asunto
        private string _NumeroOrden { get; set; }

        public string NumeroOrden
        {
            get
            {
                return _NumeroOrden;
            }
            set
            {
                _NumeroOrden = value;
                OnPropertyChanged("NumeroOrden");
            }

        }

        private DateTime _Fecha;

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

        private string _NumOrdCliente { get; set; }

        public string NumOrdCliente
        {
            get
            {
                return _NumOrdCliente;
            }
            set
            {
                _NumOrdCliente = value;
                OnPropertyChanged("NumOrdCliente");
            }

        }

        private string _Cliente { get; set; }

        public string Cliente
        {
            get
            {
                return _Cliente;
            }
            set
            {
                _Cliente = value;
                OnPropertyChanged("Cliente");
            }

        }

        private string _Asunto { get; set; }

        public string Asunto
        {
            get
            {
                return _Asunto;
            }
            set
            {
                _Asunto = value;
                OnPropertyChanged("Asunto");
            }

        }

        #endregion Asunto

        #region Sistema


        private int _TipoDocumento;
        public int TipoDocumento
        {
            get
            {
                return _TipoDocumento;
            }
            set
            {
                if (_TipoDocumento != value)
                {
                    _TipoDocumento = value;
                    OnPropertyChanged("TipoDocumento");
                }
            }
        }

        private int _TipoOrden;
        public int TipoOrden
        {
            get
            {
                return _TipoOrden;
            }
            set
            {
                if (_TipoOrden != value)
                {
                    _TipoOrden = value;
                    OnPropertyChanged("TipoOrden");
                }
            }
        }

        private int _TipoRecepcion;
        public int TipoRecepcion
        {
            get
            {
                return _TipoRecepcion;
            }
            set
            {
                if (_TipoRecepcion != value)
                {
                    _TipoRecepcion = value;
                    OnPropertyChanged("TipoRecepcion");
                }
            }
        }

        private int _TipoServicio;
        public int TipoServicio
        {
            get
            {
                return _TipoServicio;
            }
            set
            {
                if (_TipoServicio != value)
                {
                    _TipoServicio = value;
                    OnPropertyChanged("TipoServicio");
                }
            }
        }

        private int _TipoAjuste;
        public int TipoAjuste
        {
            get
            {
                return _TipoAjuste;
            }
            set
            {
                if (_TipoAjuste != value)
                {
                    _TipoAjuste = value;
                    OnPropertyChanged("TipoAjuste");
                }
            }
        }

        private int _TipoSistema;
        public int TipoSistema
        {
            get
            {
                return _TipoSistema;
            }
            set
            {
                if (_TipoSistema != value)
                {
                    _TipoSistema = value;
                    OnPropertyChanged("TipoSistema");
                }
            }
        }

        #endregion Sistema

        #region Archivo

        private ArchivoModel _PersonaActual { get; set; }
        public ArchivoModel PersonaActual
        {
            get
            {
                return _PersonaActual;
            }
            set
            {
                _PersonaActual = value;
                OnPropertyChanged("PersonaActual");
            }
        }

        private List<ArchivoModel> lstOriginal = new List<ArchivoModel>();

        private ObservableCollection<ArchivoModel> _lstArchivo = new ObservableCollection<ArchivoModel>();

        public ObservableCollection<ArchivoModel> lstArchivo
        {
            get
            {
                return _lstArchivo;
            }
            set
            {
                _lstArchivo = value;
                OnPropertyChanged("lstArchivo");
            }
        }

        public ICommand AgregarCommand { get; set; }
        public ICommand EliminarCommand { get; set; }
        public ICommand GuardarCommand { get; set; }
        public ICommand EliminaOrdenCommand { get; set; }
        public ICommand BuscaImagenCommand { get; set; }
         

        #endregion Archivo
        private List<OrdenModel> lstOrdenOriginal = new List<OrdenModel>();


        #endregion Instances

        #region Methods

        private async void GuardarOrden()
        {

            //Conexion.insertOrden(NumeroOrden,Fecha,Cliente, Convert.ToString(TipoDocumento),Asunto
            //    , Convert.ToString(TipoRecepcion), Convert.ToString(TipoServicio), Convert.ToString(TipoOrden), Convert.ToString(TipoSistema),
            //    Convert.ToString(TipoAjuste), "000011","","", "N");

            if (OrdenModel.GuardarOrden(NumeroOrden, Convert.ToDateTime(Fecha), Cliente, Convert.ToString(TipoDocumento), Asunto
                , Convert.ToString(TipoRecepcion), Convert.ToString(TipoServicio), Convert.ToString(TipoOrden), Convert.ToString(TipoSistema),
                Convert.ToString(TipoAjuste)))
            {
                await App.Current.MainPage.DisplayAlert("Orden almacenada", "El registro de la orden fue almacenado correctamente", "Ok");
                
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error al almacenar", "El registro de la orden posee un error.", "Ok");
            }
        }



        private void EliminaImagen()
        {
            //lstOriginal.RemoveAll(x => x.Archivo == id);
        }


        private async void AgregaImagen()
        {
            string strLocation = string.Empty;
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("Error de imagen", "No posee permisos de imagen en el dispositivo.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                strLocation = file.Path;

                lstArchivo.Add(new ArchivoModel { Archivo = strLocation });
                lstOriginal.Add(new ArchivoModel { Archivo = strLocation });
            }
            catch (Exception)
            {

                throw;
            }



        }


        public void cargaOrden()
        {
            lstOrdenOriginal = OrdenModel.ObtenerOrdenes(NumeroOrden);

            if (lstOrdenOriginal != null)
            {
                foreach (var item in lstOrdenOriginal)
                {
                    if (item.NumOrden.Trim() == NumeroOrden)
                    {

                        Fecha = item.FechaOrden;
                        NumOrdCliente = item.NoOrdCliente;
                        Cliente = item.CodCliente;
                        Asunto = item.Asunto;
                        TipoDocumento = Convert.ToInt32(item.TipoDocum) ;
                        TipoOrden = Convert.ToInt32(item.TipoOrden);
                        TipoRecepcion = Convert.ToInt32(item.TipoRecep);
                        TipoServicio = Convert.ToInt32(item.TipoServicio);
                        TipoAjuste = Convert.ToInt32(item.TipoAjuste);
                        TipoSistema = Convert.ToInt32(item.Sistema);
                    }
                }
            }
        }

        public void BuscaImagen(int id)
        {
            PersonaActual = lstOriginal.Where(x => x.Id == id).FirstOrDefault();

            ((MasterDetailPage)App.Current.MainPage).Navigation.PushModalAsync(new ImagenView());

        }

        private async void EliminaOrden()
        {
            if (NumeroOrden != string.Empty)
            {
                if (OrdenModel.borrarOrden(NumeroOrden))
                {
                    await App.Current.MainPage.DisplayAlert("Orden almacenada", "La orden fue eliminada correctamente", "Ok");

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error al almacenar", "La orden no pudo ser eliminada.", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error al almacenar", "Debe de digitar un numero de orden.", "Ok");
            }
        }

        private async Task InitClass()
        {

            lstArchivo = await ArchivoModel.obtenerArchivos();

           

        }
        private void InitCommands()
        {
            GuardarCommand = new Command(GuardarOrden);
            EliminarCommand = new Command(EliminaImagen);
            AgregarCommand = new Command(AgregaImagen);
            EliminaOrdenCommand = new Command(EliminaOrden);
            BuscaImagenCommand = new Command<int>(BuscaImagen);

            Fecha = DateTime.Now;
            TipoAjuste = 1;
            Asunto = "a";
            
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
