﻿using System;
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
        List<SQL_Comentario> getComentarioFromIndoviduo(SQL_Individuo person);
        [OperationContract]
        List<SQL_Comentario> getComentarioToIndoviduo(SQL_Individuo person);
        [OperationContract]
        List<SQL_Comentario> getComentario(SQL_Individuo sender,SQL_Individuo resiver);
        [OperationContract]
        void createNewComentarioInB();
        [OperationContract]
        void updateComentarioInDB();
        [OperationContract]
        void deleteComentarioInDB();
    }
}
