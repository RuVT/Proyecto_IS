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

        public List<SQL_Evaluacion> searchEvaluacionByIndividuo(int id)
        {
            comando.CommandText = "select *"+
                                  " from evaluacion" +
                                  " where ind_idExamined=@id";

            comando.Parameters.AddWithValue("@id", id);
            DataTable table=SQL_manager.readTable(comando);
            return load(table);
        }

        public SQL_Evaluacion searchEvaluacion(int examiner_id, int examined_id)
        {
            comando.CommandText = "select *" +
                                  " from evaluacion" +
                                  " where ind_idExaminer=@examiner_id and ind_idExamined=@examined_id";

            comando.Parameters.AddWithValue("@examiner_id", examiner_id);
            comando.Parameters.AddWithValue("@examined_id", examined_id);
            DataTable table = SQL_manager.readTable(comando);
            List<SQL_Evaluacion> result = load(table);
            if (result.Count > 0)
                return result.First();
            else return null;
        }

        public SQL_Evaluacion searchEvaluacionByIndividuoAtributo(int examiner_id, int examined_id, int atr_id)
        {
            comando.CommandText = "select *" +
                                  " from evaluacion" +
                                  " where ind_idExaminer=@examiner_id and ind_idExamined=@examined_id and atr_id=@atr_id";

            comando.Parameters.AddWithValue("@examiner_id", examiner_id);
            comando.Parameters.AddWithValue("@examined_id", examined_id);
            comando.Parameters.AddWithValue("@atr_id", atr_id);
            DataTable table = SQL_manager.readTable(comando);
            List<SQL_Evaluacion> result= load(table);
            if (result.Count > 0)
                return result.First();
            else return null;
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
            //temp.equ_id = row.Field<int>("equ_id");
            //temp.rel_id = row.Field<int>("rel_id");
            //temp.par_id = row.Field<int>("par_id");
            temp.atr_id = row.Field<int>("atr_id");
            temp.eva_value = row.Field<double>("eva_value");
            //temp.opc_id = row.Field<int>("opc_id");
            temp.eva_date = row.Field<DateTime>("eva_date");
            return temp;
        }
        public int createNewevaluacionInDB(SQL_Evaluacion ev)
        {
            comando.CommandText = "Insert into evaluacion(ind_idExaminer, ind_idExamined, atr_id, eva_value, eva_date)" +
                                                " Values (@ind_idExaminer, @ind_idExamined, @atr_id, @eva_value, @eva_date)"+
                                                " Select CAST(SCOPE_IDENTITY() AS int) as ID";
           
                       
            comando.Parameters.AddWithValue("@ind_idExaminer", ev.ind_idExaminer);
            comando.Parameters.AddWithValue("@ind_idExamined", ev.ind_idExamined);
            //comando.Parameters.AddWithValue("@rel_id", ev.rel_id);
            comando.Parameters.AddWithValue("@atr_id", ev.atr_id);
            comando.Parameters.AddWithValue("@eva_value", ev.eva_value);
            //comando.Parameters.AddWithValue("@opc_id", ev.opc_id);
            comando.Parameters.AddWithValue("@eva_date", ev.eva_date);
            return SQL_manager.readTable(comando).Rows[0].Field<int>("ID");            
        }

        public void updateEvaluacionInDB(SQL_Evaluacion ev)
        {
            comando.CommandText = @"UPDATE evaluacion SET ind_idExaminer=@ind_idExaminer, ind_idExamined=@ind_idExamined, atr_id=@atr_id, eva_value=@eva_value, eva_date=@eva_date where eva_id=@eva_id";
            comando.Parameters.AddWithValue("@eva_id", ev.eva_id);
            comando.Parameters.AddWithValue("@ind_idExaminer", ev.ind_idExaminer);
            comando.Parameters.AddWithValue("@ind_idExamined", ev.ind_idExamined);
            //comando.Parameters.AddWithValue("@rel_id", ev.rel_id);
            comando.Parameters.AddWithValue("@atr_id", ev.atr_id);
            comando.Parameters.AddWithValue("@eva_value", ev.eva_value);
            //comando.Parameters.AddWithValue("@opc_id", ev.opc_id);
            comando.Parameters.AddWithValue("@eva_date", ev.eva_date);
            SQL_manager.executeCommand(comando);
        }
        public void deleteEvaulacionInDB(SQL_Evaluacion ev)
        {
            comando.CommandText = @"DELETE FROM evaluacion  WHERE eva_id=@eva_id";
            comando.Parameters.AddWithValue("@eva_id", ev.eva_id);
            SQL_manager.executeCommand(comando);
        }
    }
}
