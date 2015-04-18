using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IComentario
    {
        [OperationContract]
        SQL_Comentario getComentarioFromIndoviduo(SQL_Individuo person);
        [OperationContract]
        void getComentarioToIndoviduo(SQL_Individuo person);
        [OperationContract]
        void createNewComentarioInB();
        [OperationContract]
        void updateComentarioInDB();
        [OperationContract]
        void deleteComentarioInDB();
    }
}
