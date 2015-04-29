using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SQL_ClassLibrary.ServiceInterface;
using System.Data;
namespace SQL_ClassLibrary
{

    public class SQL_Evaluacion : IEvaluacion
    {
        public int eva_id;
        public int ind_idExaminer;
        public int ind_idExamined;
        public int rel_id;
        public int atr_id;
        public double eva_value;
        public int opc_id;
        public DateTime eva_date;
        public int equ_id;
        public int par_id;

        SqlCommand comando = new SqlCommand();

        public List<SQL_Evaluacion> searchEvaluacionByIndividuo(SQL_Individuo individuo)
        {
            comando.CommandText = "select *"+
                                  " from evaluacion" +
                                  " where ind_idExamined=@id";

            comando.Parameters.AddWithValue("@id", individuo.id);
            DataTable table=SQL_manager.readTable(comando);
            return load(table);
        }

        public static List<SQL_Evaluacion> load(DataTable table)
        {
            List<SQL_Evaluacion> temp = new List<SQL_Evaluacion>();
            foreach (DataRow row in table.Rows)
            {
                temp.Add(load(row)); 
            }
            return temp;
        }

        public static SQL_Evaluacion load(DataRow row)
        {
            SQL_Evaluacion temp=new SQL_Evaluacion();
            temp.eva_id = row.Field<int>("eva_id");
            temp.ind_idExaminer = row.Field<int>("ind_idExaminer");
            temp.ind_idExamined = row.Field<int>("ind_idExamined");
            temp.equ_id = row.Field<int>("equ_id");
            temp.rel_id = row.Field<int>("rel_id");
            temp.par_id = row.Field<int>("par_id");
            temp.atr_id = row.Field<int>("atr_id");
            temp.eva_value = row.Field<double>("eva_value");
            temp.opc_id = row.Field<int>("opc_id");
            temp.eva_date = row.Field<DateTime>("eva_date");
            return temp;
        }
        public void createNewevaluacionInDB()
        {
            comando.CommandText = "Insert into evaluacion(eva_id, ind_idExaminer, ind_idExamined, rel_id, atr_id, eva_value, opc_id, eva_date)" +
                                                " Values (@eva_id, @ind_idExaminer, @ind_idExamined, @rel_id, @atr_id, @eva_value, @opc_id, @eva_date)";

            comando.Parameters.AddWithValue("@eva_id", eva_id);
            comando.Parameters.AddWithValue("@ind_idExaminer", ind_idExaminer);
            comando.Parameters.AddWithValue("@ind_idExamined", ind_idExamined);
            comando.Parameters.AddWithValue("@rel_id", rel_id);
            comando.Parameters.AddWithValue("@atr_id", atr_id);
            comando.Parameters.AddWithValue("@eva_value", eva_value);
            comando.Parameters.AddWithValue("@opc_id", opc_id);
            comando.Parameters.AddWithValue("@eva_date", eva_date);
            SQL_manager.executeCommand(comando);
        }

        public void updateEvaluacionInDB()
        {
            comando.CommandText = @"UPDATE evaluacion SET ind_idExaminer=@ind_idExaminer, ind_idExamined=@ind_idExamined, ";
        }
        public void deleteEvaulacionInDB()
        { }
    }
}
