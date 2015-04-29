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
        void createNewOpcionInDB();
        [OperationContract]
        void updateOpcionInDB();
        [OperationContract]
        void deleteOpcionInDB();
    }
}
