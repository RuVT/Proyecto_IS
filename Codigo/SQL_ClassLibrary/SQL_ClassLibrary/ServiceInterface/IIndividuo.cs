using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IIndividuo
    {
        [OperationContract]
        void createNewIndividuoInDB();
        [OperationContract]
        void updateIndividuoInDB();
        [OperationContract]
        void deleteIndiviuoInDB();
        [OperationContract]
        List<SQL_Individuo> searchIndividuoByName(string _name);
        [OperationContract]
        SQL_Individuo getIndividuoFromDBbyID(int _id);
    }
}
