using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IRelacion
    {
        [OperationContract]
        List<SQL_Relacion> getRelations(SQL_Individuo person);
        [OperationContract]
        int createNewRelacionInDB(SQL_Relacion re);
        [OperationContract]
        void deleteRelacionInDB(SQL_Relacion re);
        [OperationContract]
        void updateRelacionInDB(SQL_Relacion re);
    }
}
