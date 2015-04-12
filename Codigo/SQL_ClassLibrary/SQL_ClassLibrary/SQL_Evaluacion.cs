using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SQL_ClassLibrary
{

    public class SQL_Evaluacion : SQL_Object
    {
        public object eva_id;
        public object ind_idExaminer;
        public object ind_idExamined;
        public object rel_id;
        public object atr_id;
        public object eva_value;
        public object opc_id;
        public object eva_date;

        SqlCommand comando = new SqlCommand();

        public void searchEvaluacionByIndividuo(SQL_Individuo individuo)
        {
            comando.CommandText = "select *"+
                                  " from evaluacion" +
                                  " where ind_idExamined=@id";

            comando.Parameters.AddWithValue("@id", individuo.id);
            SQL_manager.executeCommand(comando);
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
    }
}
