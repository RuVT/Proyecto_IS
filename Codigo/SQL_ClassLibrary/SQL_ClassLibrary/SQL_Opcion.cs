using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL_ClassLibrary
{
    public class SQL_Opcion : SQL_Object
    {
        public int opc_id;
        public int atr_id;
        public string atr_group;
        public string opc_value;

        SqlCommand comando = new SqlCommand();

        public List<SQL_Opcion> getAllOptions(SQL_Atributo atributo)
        {
            SQL_manager.executeCommand("select * from opcion");
        }
        public List<SQL_Opcion> getOpcionByGroup(string group)
        {

        }
        public SQL_Opcion load(DataTable data)
        {

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
