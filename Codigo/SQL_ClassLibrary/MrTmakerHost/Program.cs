using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary;
using System.ServiceModel;
namespace MrTmakerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ServiceHost> Hosts = new List<ServiceHost>();
            Hosts.Add(new ServiceHost(typeof(SQL_ClassLibrary.SQL_Atributo)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Comentario)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Equipo)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Evaluacion)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Habilidad)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Individuo)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Opcion)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_ParticipacionEquipo)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Relacion)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_TipoRelacion)));
            Hosts.Add( new ServiceHost(typeof(SQL_ClassLibrary.SQL_Usuario)));

            foreach (ServiceHost host in Hosts)
                host.Open();
            Console.WriteLine("Servicio en ejecucion");
            Console.Read();
            foreach (ServiceHost host in Hosts)
                host.Close();

        } 
    }
}
