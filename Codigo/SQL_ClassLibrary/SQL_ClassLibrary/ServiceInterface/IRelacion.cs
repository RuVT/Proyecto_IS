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
        SQL_Relacion load(DataTable data);
        [OperationContract]
        SQL_Relacion load(DataRow data);
        [OperationContract]
        void createNewRelacionInDB();
        [OperationContract]
        void deleteRelacionInDB();
        [OperationContract]
        void updateRelacionInDB();
    }
}
