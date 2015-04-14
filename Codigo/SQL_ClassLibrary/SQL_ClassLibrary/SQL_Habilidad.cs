using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL_ClassLibrary
{
    public class SQL_Habilidad : SQL_Object
    {
        public int hab_id;
        public int ind_id;
        public int atr_id;
        public float hab_FinalValue;

        public List<SQL_Habilidad> getHabilidadByIndividuo(SQL_Individuo individuo)
        {
            DataTable table = SQL_manager.readTable("Select * from habilidad where ind_id =" + individuo);
            return load(table);
        }
        public List<SQL_Habilidad> load(DataTable table)
        {
            List<SQL_Habilidad> lista = new List<SQL_Habilidad>();
            foreach (DataRow row in table.Rows)
            {

                SQL_Habilidad nuevo = new SQL_Habilidad();
                nuevo.atr_id = row.Field<int>("atr_id");
                nuevo.hab_id = row.Field<int>("hab_id");
                nuevo.ind_id = row.Field<int>("ind_id");
                nuevo.hab_FinalValue = row.Field<float>("hab_FinalValue");
                lista.Add(nuevo);
            }
            return lista;
        }
        public SQL_Opcion getOpcion()
        {
        }
    }
}