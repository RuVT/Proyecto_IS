using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SQL_ClassLibrary.ServiceInterface;

namespace SQL_ClassLibrary
{
    public class SQL_TipoRelacion : SQL_Object, ITipoRelacion
    {
        public int tipRe_id;
        public string tipRe_type;
        public string tipRe_Description;

        SqlCommand comando = new SqlCommand();

        public SQL_TipoRelacion()
        {
        }

        public List<SQL_TipoRelacion> getRelationsType()
        {
            comando.CommandText = "select *" +
                               " From tipoRelacion";

            DataTable dato_T = SQL_manager.readTable(comando);

            List<SQL_TipoRelacion> lista_T = new List<SQL_TipoRelacion>();
            return Load(dato_T);
        }

        public static SQL_TipoRelacion Load(DataRow dato)
        {
            SQL_TipoRelacion Sql_T = new SQL_TipoRelacion();
            Sql_T.tipRe_id = dato.Field<int>("tipRe_id");
            Sql_T.tipRe_type = dato.Field<string>("tipRe_type");
            Sql_T.tipRe_Description = dato.Field<string>("tipRe_Description");

            return Sql_T;
        }

        public List<SQL_TipoRelacion> Load(DataTable data)
        {
            List<SQL_TipoRelacion> lista_T = new List<SQL_TipoRelacion>();
            foreach (DataRow x in data.Rows)
            {
                lista_T.Add(Load(x));
            }
            return lista_T;
        }

        public void addNewTipoRelacionInBD()
        {
            comando.CommandText = @"INSERT INTO tipoRelacion(tipRe_type,tipRe_Description) 
                                                    VALUES (@tipRe_type, @tipRe_Description)";
            comando.Parameters.AddWithValue("@tipRe_type", tipRe_id);
            comando.Parameters.AddWithValue("@tipRe_Description", tipRe_id);
            SQL_manager.executeCommand(comando);
        }

        public void updateTipoRelacionInBD()
        {
            comando.CommandText = @"UPDATE tipoRelacion SET tipRe_type = @tipRe_type, tipRe_Description = @tipRe_Description 
                                                        WHERE tipRe_id = @tipRe_id ";
            comando.Parameters.AddWithValue("@tipRe_id", tipRe_id);
            comando.Parameters.AddWithValue("@tipRe_type", tipRe_id);
            comando.Parameters.AddWithValue("@tipRe_Description", tipRe_id);
            SQL_manager.executeCommand(comando);
        }

        public void deleteTipoRelacionInDB()
        {
            comando.CommandText = @"DELETE FROM tipoRelacion  WHERE tipRe_id = @tipRe_id";
            comando.Parameters.AddWithValue("@tipRe_id", tipRe_id);
            SQL_manager.executeCommand(comando);
        }

    }
}