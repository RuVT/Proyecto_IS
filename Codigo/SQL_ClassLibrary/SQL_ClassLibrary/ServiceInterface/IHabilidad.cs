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
        List<SQL_Habilidad> getHabilidadByIndividuo(SQL_Individuo individuo);
        [OperationContract]
        public List<SQL_Habilidad> load(DataTable table);
        [OperationContract]
        public SQL_Habilidad load(DataRow row);
        [OperationContract]
        void createNewHabilidadInDB();
        [OperationContract]
        void updateHanilidadInDB();
        [OperationContract]
        void deleteHabilidadInDB();
    }
}
