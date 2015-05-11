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
        [OperationContract]
        void addNewTipoRelacionInBD(SQL_TipoRelacion ti);
        [OperationContract]
        void updateTipoRelacionInBD(SQL_TipoRelacion ti);
        [OperationContract]
        void deleteTipoRelacionInDB(SQL_TipoRelacion ti);
    }
}
