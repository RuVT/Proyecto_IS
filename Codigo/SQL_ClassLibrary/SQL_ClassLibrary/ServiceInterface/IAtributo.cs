using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAtributo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAtributo
    {
        [OperationContract]
        public List<SQL_Atributo> getAllAtributos();
        [OperationContract]
        public SQL_Atributo getAtributoByID(int id);
        [OperationContract]
        public List<SQL_Atributo> load(DataTable table);        
    }
}
