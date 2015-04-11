using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HostWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServicioWCF));
            host.Open();
            Console.WriteLine("Servicio en ejecucion");           
            Console.Read();
            host.Close();
        }
    }
}
