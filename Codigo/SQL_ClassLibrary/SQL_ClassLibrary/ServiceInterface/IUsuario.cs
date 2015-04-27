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
        void createNewUsuarioInDB();
        [OperationContract]
        void deleteUsuarioInDB();
        [OperationContract]
        SQL_Usuario load(DataTable data);
        [OperationContract]
        void updateUsuarioInDB();
        [OperationContract]
        bool userExist(string _name);
        [OperationContract]
        bool passwordIsCorrect(string _password);
        [OperationContract]
        SQL_Usuario getUsuarioByName(string _name);
        [OperationContract]
        bool login(string _name, string _password);
    }
}
