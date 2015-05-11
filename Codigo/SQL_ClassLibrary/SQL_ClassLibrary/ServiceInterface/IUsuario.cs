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
        int createNewUsuarioInDB(SQL_Usuario user);
        [OperationContract]
        void deleteUsuarioInDB(SQL_Usuario user);
        [OperationContract]
        void updateUsuarioInDB(SQL_Usuario user);
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
