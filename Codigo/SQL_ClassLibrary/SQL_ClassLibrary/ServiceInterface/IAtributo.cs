using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IAtributo
    {
        [OperationContract]
        List<SQL_Atributo> getAllAtributos();
        [OperationContract]
        SQL_Atributo getAtributoByID(int id);
        [OperationContract]
        List<SQL_Atributo> load(DataTable table);        
    }
}
