using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL_ClassLibrary
{
    public class SQL_TipoRelacion : SQL_Object
    {
        public object id;
        public object type;
        public object Description;

        SqlCommand comando = new SqlCommand();

        public void SQL_TipoRelacion()
        {
        }
        public List<SQL_TipoRelacion> getRelationsType()
        {
            comando.CommandText = "select *" +
                               " From tipoRelacion";

            DataTable dato_T = SQL_manager.readTable(comando);

            List<SQL_TipoRelacion> lista_T = new List<SQL_TipoRelacion>();
            foreach (DataRow x in dato_T.Rows)
            {
                lista_T.Add(Load(x));
            }
            return lista_T;

        }
        public static SQL_TipoRelacion Load(DataRow dato)
        {
            SQL_TipoRelacion Sql_T = new SQL_TipoRelacion();
            Sql_T.id = dato.Field<int>("tipRe_id");
            Sql_T.type = dato.Field<string>("tipRe_type");
            Sql_T.Description = dato.Field<string>("tipRe_Description");

            return Sql_T;
        }

        public SQL_TipoRelacion Load(DataTable data)
        {
            comando.CommandText = "select *" +
                              " From tipoRelacion";

            DataTable dato_I = SQL_manager.readTable(comando);
            return Load(dato_I);
        }

    }
}