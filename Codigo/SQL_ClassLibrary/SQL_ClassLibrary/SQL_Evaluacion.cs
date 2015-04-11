using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void searchEvaluacionByIndividuo(SQL_Individuo individuo)
        {
        }
        public void createNewevaluacionInDB()
        {
        }
    }
}
