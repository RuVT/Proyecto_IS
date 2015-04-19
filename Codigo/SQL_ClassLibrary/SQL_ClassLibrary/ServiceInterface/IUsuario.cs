using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        public void createNewUsuarioInDB();
        [OperationContract]
        public void deleteUsuarioInDB();
        [OperationContract]
        public static SQL_Usuario load(DataTable data);
        [OperationContract]
        public void updateUsuarioInDB();
        [OperationContract]
        public static bool userExist(string _name);
        [OperationContract]
        private bool passwordIsCorrect(string _password);
        [OperationContract]
        private static SQL_Usuario getUsuarioByName(string _name);
        [OperationContract]
        public static bool login(string _name, string _password);
    }
}
