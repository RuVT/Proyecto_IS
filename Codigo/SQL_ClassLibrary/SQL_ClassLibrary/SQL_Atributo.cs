using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_Atributo : SQL_Object
    {
        public int atr_id;
        public string atr_name;
        public string atr_drescription;
        public int atr_group;
        public List<SQL_Atributo> getAllAtributos()
        {
        }
        public SQL_Atributo getAtributoByID(int id)
        {
        }
        public List<SQL_Atributo> load(DataTable table)
        {
        }
    }
}