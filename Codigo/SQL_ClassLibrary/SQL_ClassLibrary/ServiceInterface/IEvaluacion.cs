using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SQL_ClassLibrary;
using System.Data;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IEvaluacion
    {
        [OperationContract]
        List<SQL_Evaluacion> searchEvaluacionByIndividuo(SQL_Individuo individuo);
        [OperationContract]
        int createNewevaluacionInDB(SQL_Evaluacion ev);
        [OperationContract]
        void updateEvaluacionInDB(SQL_Evaluacion ev);
        [OperationContract]
        void deleteEvaulacionInDB(SQL_Evaluacion ev);
    }
}
