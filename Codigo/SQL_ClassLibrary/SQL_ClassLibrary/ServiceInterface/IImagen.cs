using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SQL_ClassLibrary.ServiceInterface
{
    [ServiceContract]
    public interface IImagen
    {
        [OperationContract]
        List<SQL_Imagen> getImagenFromIndividio(int ind_id);
        [OperationContract]
        int createNewImageInDB(SQL_Imagen ima);
        [OperationContract]
        void updateImagenInDB(SQL_Imagen ima);
        [OperationContract]
        void deleteImagenInDB(SQL_Imagen ima);
    }
}
