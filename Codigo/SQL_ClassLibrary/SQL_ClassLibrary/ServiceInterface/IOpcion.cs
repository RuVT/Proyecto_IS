using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    interface IOpcion
    {
        [OperationContract]
        List<SQL_Opcion> getAllOptions();
        [OperationContract]
        List<SQL_Opcion> getOpcionByGroup(string group);
        [OperationContract]
        SQL_Opcion Load(DataTable data);
        [OperationContract]
        static SQL_Opcion Load(DataRow dato);
        [OperationContract]
        public void createNewOpcionInDB();
        [OperationContract]
        public void updateOpcionInDB();
        [OperationContract]
        public void deleteOpcionInDB();
    }
}
