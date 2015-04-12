using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_Object
    {
        public static void load(DataTable data)
        {
        }
        public void creteNewInDB()
        {
        }
        public void removeFromDB()
        {
        }
        public void updateInDB()
        {
        }

        public static void loadData(DataRow row, string columnName, int variable)
        {
            if (row[columnName] != null)
                variable = row.Field<int>(columnName);
            else
                variable = -1;
        }      
    }
}
