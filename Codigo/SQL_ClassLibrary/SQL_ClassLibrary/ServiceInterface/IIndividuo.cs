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
        public void SQL_Idividuo();
        [OperationContract]
        public void createNewIndividuoInDB();
        [OperationContract]
        public void updateIndividuoInDB();
        [OperationContract]
        public void deleteIndiviuoInDB();
        [OperationContract]
        public void searchIndividuoByName(string _name);
        [OperationContract]
        public SQL_Individuo getIndividuoFromDBbyID(int _id);
        [OperationContract]
        public static List<SQL_Individuo> Load(DataTable data);
        [OperationContract]
        public static SQL_Individuo Load(DataRow dato);
    }
}
