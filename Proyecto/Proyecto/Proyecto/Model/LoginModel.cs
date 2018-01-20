//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;

namespace Proyecto.Model
{

    public class LoginModel : RealmObject
    {

        public string Usuario { get; set; }
        public string Clave { get; set; }

        public LoginModel()
        {
            
        }


        private bool _Checked { get; set; }
        public bool Checked { get { return _Checked; } set { _Checked = value; OnPropertyChanged("Checked"); } }

        public string User { get; set; }
        public string Password { get; set; }

        public bool Acceso { get; set; }


        public static LoginModel ValidarUsuario(string user, string password)
        {
            //EndpointAddress endPoint = new EndpointAddress("http://192.168.0.161/wcfCorrespondencia/Service1.svc");
            //BasicHttpBinding binding = CreateBasicHttp();
            //Service1Client Conexion = new Service1Client(binding, endPoint);


            Service1Client conexion = Conexion.Cliente();

            string strUsuario = string.Empty;
            LoginModel miUsuario = new LoginModel();

            //user = "jaltami";
            //password = "123456";

            strUsuario = conexion.validarUsuario(user, password);

            if (!string.IsNullOrEmpty(strUsuario) || strUsuario == "[]")
            {
                JArray jArray = JArray.Parse(strUsuario);
                miUsuario.Usuario = jArray[0]["Usuario"].ToString();
                miUsuario.Clave = jArray[0]["Password"].ToString();

                return miUsuario;
            }
            else
            {
                return null;
            }

        }

        public static void GuardarUsuario(LoginModel pUsuario)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(new LoginModel
                {
                    Usuario = pUsuario.Usuario,
                    Clave = pUsuario.Clave,
                });
            });
        }

        public static bool RecordarUsuario()
        {
            var realm = Realm.GetInstance();
            var miUsuario = realm.All<LoginModel>();
            if (miUsuario.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void OlvidarUsuario()
        {
            var realm = Realm.GetInstance();
            var miUsuario = realm.All<LoginModel>();
            if (miUsuario.Count() > 0)
            {
                using (var trans = realm.BeginWrite())
                {
                    realm.Remove(miUsuario.First());
                    trans.Commit();
                }
            }
        }

    }
}
