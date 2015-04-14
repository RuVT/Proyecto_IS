using System;
using System.Collections.Generic;
using System.Data;
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
            List<SQL_Atributo> lista = new List<SQL_Atributo>();
            foreach (DataRow row in table.Rows)
            {
                SQL_Atributo nuevo = new SQL_Atributo();
                nuevo.atr_drescription = row.Field<string>("atr_drescription");
                //....
                lista.Add(nuevo);
            }
            return lista;
        }
    }
}