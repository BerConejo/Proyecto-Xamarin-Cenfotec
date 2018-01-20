using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Proyecto
{
    public class Conexion
    {
        public Conexion()
        {

        }

        public static Service1Client Cliente()
        {
            try
            {
                EndpointAddress endPoint = new EndpointAddress("http://192.168.1.14/wcfCorrespondencia/Service1.svc");
                BasicHttpBinding binding = CreateBasicHttp();
                return new Service1Client(binding, endPoint);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static BasicHttpBinding CreateBasicHttp()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "BasicHttpBinding_IService1",
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = long.MaxValue
            };
            TimeSpan timeout = new TimeSpan(0, 0, 120);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            binding.Security.Mode = BasicHttpSecurityMode.None;

            return binding;
        }

    }
}
