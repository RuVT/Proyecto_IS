using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClienteWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ReferenciaServicioWCF.ServicioWCFClient cliente = new ReferenciaServicioWCF.ServicioWCFClient("http");
            Console.WriteLine(cliente.State);
            Console.WriteLine("Probando...");
            Console.WriteLine(cliente.DoWork());
            Console.Read();
            cliente.Close();
        }
    }
}
