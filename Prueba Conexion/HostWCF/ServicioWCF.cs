using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HostWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioWCF" en el código y en el archivo de configuración a la vez.
    public class ServicioWCF : IServicioWCF
    {
        public string DoWork()
        {
            Console.WriteLine("Realizando prueba");
            return "Esto es un prueba: 2+3=" + (2 + 3).ToString();
        }
    }
}
