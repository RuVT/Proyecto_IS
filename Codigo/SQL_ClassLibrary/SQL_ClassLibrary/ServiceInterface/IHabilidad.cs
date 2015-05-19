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
    public interface IHabilidad
    {
        [OperationContract]
        List<SQL_Habilidad> getHabilidadByIndividuo(int id);
        [OperationContract]
        int createNewHabilidadInDB(SQL_Habilidad ha);
        [OperationContract]
        void updateHanilidadInDB(SQL_Habilidad ha);
        [OperationContract]
        void deleteHabilidadInDB(SQL_Habilidad ha);
        [OperationContract]
        bool IndividuoTieneAtributo(int id);
        [OperationContract]
        SQL_Habilidad getHabilidadByIndividuoAtributo(int indid, int atrid);
    }
}
