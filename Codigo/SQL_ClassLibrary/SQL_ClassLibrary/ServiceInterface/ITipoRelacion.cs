using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface ITipoRelacion
    {
        [OperationContract]
        List<SQL_TipoRelacion> getRelationsType();
        //[OperationContract]
        //SQL_TipoRelacion Load(DataRow data);
        //[OperationContract]
        //SQL_TipoRelacion Load(DataTable data);
        [OperationContract]
        void addNewTipoRelacionInBD();
        [OperationContract]
        void updateTipoRelacionInBD();
        [OperationContract]
        void deleteTipoRelacionInDB();
    }
}
