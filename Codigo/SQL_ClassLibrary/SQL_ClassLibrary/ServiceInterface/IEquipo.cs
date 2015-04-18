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
    public interface IEquipo
    {
        [OperationContract]
        List<SQL_Equipo> searchEquiposByName(string name);
        [OperationContract]
        public List<SQL_Equipo> getAllEquipos();
        [OperationContract]
        public SQL_Equipo getEquipoByID(int id);
        [OperationContract]
        public List<SQL_Equipo> load(DataTable data);
        [OperationContract]
        public SQL_Equipo load(DataRow row);
        [OperationContract]
        public void createNewEquipoInDB();
        [OperationContract]
        public void updateEquipoInDB();
        [OperationContract]
        public void deleteEquipoInDB();
    }
}
