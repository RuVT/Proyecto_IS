using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_TipoRelacion : SQL_Object
    {
        public object id;
        public object type;
        public object Description;
        public void SQL_TipoRelacion()
        {
        }
        public List<SQL_TipoRelacion> getRelationsType()
        {
        }
        public SQL_TipoRelacion load(DataTable data)
        {

        }
    }
}