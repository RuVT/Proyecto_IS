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
        List<SQL_Opcion> getAllOptions(SQL_Atributo atr);
        [OperationContract]
        List<SQL_Opcion> getOpcionByGroup(string group);       
        [OperationContract]
        int createNewOpcionInDB(SQL_Opcion op);
        [OperationContract]
        void updateOpcionInDB(SQL_Opcion op);
        [OperationContract]
        void deleteOpcionInDB(SQL_Opcion op);
    }
}
