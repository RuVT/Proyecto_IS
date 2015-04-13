using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL_ClassLibrary
{
    public class SQL_Opcion : SQL_Object
    {
        public int opc_id;
        public int atr_id;
        public int atr_group;
        public string opc_value;

        SqlCommand comando = new SqlCommand();



        public List<SQL_Opcion> getAllOptions(/*SQL_Atributo atributo*/)
        {

            comando.CommandText = "select *" +
                             " From tipoRelacion";// +
            //                 " where atr_group=@atr_group";

            //comando.Parameters.AddWithValue("@atr_group", atributo);
            DataTable dato_O = SQL_manager.readTable(comando);

            List<SQL_Opcion> lista_O = new List<SQL_Opcion>();
            foreach (DataRow x in dato_O.Rows)
            {
                lista_O.Add(Load(x));
            }
            return lista_O;

        }

        public List<SQL_Opcion> getOpcionByGroup(string group)
        {
            comando.CommandText = "select *" +
                             " From tipoRelacion"+
                             " where atr_group=@atr_group";

            comando.Parameters.AddWithValue("@atr_group", group);
            DataTable dato_O = SQL_manager.readTable(comando);

            List<SQL_Opcion> lista_O = new List<SQL_Opcion>();
            foreach (DataRow x in dato_O.Rows)
            {
                lista_O.Add(Load(x));
            }
            return lista_O;

        }
        public SQL_Opcion Load(DataTable data)
        {
            comando.CommandText = "select *" +
                                  " From tipoRelacion";

            DataTable dato_O = SQL_manager.readTable(comando);
            return Load(dato_O);
        }
        public static SQL_Opcion Load(DataRow dato)
        {
            SQL_Opcion Sql_O = new SQL_Opcion();
            Sql_O.opc_id = dato.Field<int>("opc_id");
            Sql_O.atr_id = dato.Field<int>("atr_id");
            Sql_O.atr_group = dato.Field<int>("atr_group");
            Sql_O.opc_value = dato.Field<string>("opc_value");
           
            return Sql_O;
        }

        public void createNewOpcionInDB()
        {
            comando.CommandText = "Insert into opcion(opc_id, atr_id, atr_group, opc_value)" +
                                            " Values (@opc_id, @atr_id, @atr_group, @opc_value)";

            comando.Parameters.AddWithValue("@opc_id", opc_id);
            comando.Parameters.AddWithValue("@atr_id", atr_id);
            comando.Parameters.AddWithValue("@atr_group", atr_group);
            comando.Parameters.AddWithValue("@opc_value", opc_value);

                        SQL_manager.executeCommand(comando);
        }
        public void updateOpcionInDB()
        {
            comando.CommandText = "Update opcion Set" +
                                   " opc_id=@opc_id," +
                                   " atr_id=@atr_id," +
                                   " atr_group=@atr_group," +
                                   " opc_value=@opc_value," +
                                   " where opc_id=@opc_id";
            
            comando.Parameters.AddWithValue("@opc_id", opc_id);
            comando.Parameters.AddWithValue("@atr_id", atr_id);
            comando.Parameters.AddWithValue("@atr_group", atr_group);
            comando.Parameters.AddWithValue("@opc_value", opc_value);

            SQL_manager.executeCommand(comando);
        }
        public void deleteOpcionInDB()
        {
            comando.CommandText = "Delete From opcion Where opc_id = @opc_id ";
            comando.Parameters.AddWithValue("@opc_id", opc_id);

            SQL_manager.executeCommand(comando);
        }
    }
}
