﻿using System;
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
        List<SQL_Equipo> getAllEquipos();
        [OperationContract]
        SQL_Equipo getEquipoByID(int id);
        [OperationContract]
        List<SQL_Equipo> load(DataTable data);
        [OperationContract]
        SQL_Equipo load(DataRow row);
        [OperationContract]
        void createNewEquipoInDB();
        [OperationContract]
        void updateEquipoInDB();
        [OperationContract]
        void deleteEquipoInDB();
    }
}
