using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary.ServiceInterface;

namespace SQL_ClassLibrary
{
    public class SQL_Relacion : SQL_Object, IRelacion
    {
        public object id;
        public object tipRe_id;
        public object ind_idIni;
        public object ind_idFin;
        public object rel_val;
        
        public SQL_Relacion()
        {
        }
        
        public List<SQL_Relacion> getRelations(SQL_Individuo person)
        {
        }
        
        public SQL_Relacion load(DataTable data)
        {
        }
        
        public SQL_Relacion load(DataRow data)
        {
        }
        
        public void createNewRelacionInDB()
        {
        }
        
        public void deleteRelacionInDB()
        {
        }
        
        public void updateRelacionInDB()
        {
        }
    }
}
