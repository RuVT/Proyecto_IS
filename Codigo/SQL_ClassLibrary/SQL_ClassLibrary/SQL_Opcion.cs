using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_Opcion : SQL_Object
    {
        public int opc_id;
        public int atr_id;
        public string atr_group;
        public string opc_value;
        public List<SQL_Opcion> getAllOptions(SQL_Atributo atributo)
        {
        }
        public List<SQL_Opcion> getOpcionByGroup(string group)
        {
        }
        public SQL_Opcion load(DataTable data)
        {
        }
        public void createNewOpcionInDB()
        {
        }
        public void updateOpcionInDB()
        {
        }
        public void deleteOpcionInDB()
        {
        }
    }
}
