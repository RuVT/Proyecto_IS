using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IParticipacionEquipo
    {
        [OperationContract]
        List<SQL_Individuo> getIndividuosFromEquipo(int id);
        [OperationContract]
        List<SQL_ParticipacionEquipo> getParticipacionesFromEquipo(int id);
        [OperationContract]
        List<SQL_ParticipacionEquipo> getAllParticipaciones();
        [OperationContract]
        List<SQL_ParticipacionEquipo> getParticipacionFromIndividuo(int id);
        [OperationContract]
        int createNewParticipacionInDB(SQL_ParticipacionEquipo pa);
        [OperationContract]
        void updateNewParticipacionInDB(SQL_ParticipacionEquipo pa);
        [OperationContract]
        void deleteParticipacionInDB(SQL_ParticipacionEquipo pa);
    }
}
