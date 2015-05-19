using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SQL_ClassLibrary.ServiceInterface;
namespace SQL_ClassLibrary
{
    public class SQL_Habilidad :  IHabilidad
    {
        public int hab_id;
        public int ind_id;
        public int atr_id;
        public double hab_FinalValue;

        public List<SQL_Habilidad> getHabilidadByIndividuo(int id)
        {
            DataTable table = SQL_manager.readTable("Select * from habilidad where ind_id = " + id);
            return load(table);
        }

        public SQL_Habilidad getHabilidadByIndividuoAtributo(int indid, int atrid)
        {
            SqlCommand command= new SqlCommand();
            command.CommandText="Select * from habilidad where ind_id = @id";
            command.Parameters.AddWithValue("@ind_id", indid);
            command.Parameters.AddWithValue("@atr_id", atrid);
            DataTable table = SQL_manager.readTable(command);
            List<SQL_Habilidad> temp = load(table);
            if (temp.Count > 0)
                return temp[0];
            else
                return null;
        }

        public static List<SQL_Habilidad> load(DataTable table)
        {
            List<SQL_Habilidad> lista = new List<SQL_Habilidad>();
            foreach (DataRow row in table.Rows)
            {

                SQL_Habilidad nuevo = new SQL_Habilidad();
                nuevo.atr_id = row.Field<int>("atr_id");
                //nuevo.hab_id = row.Field<int>("hab_id");
                nuevo.ind_id = row.Field<int>("ind_id");
                nuevo.hab_FinalValue = row.Field<double>("hab_FinalValue");
                lista.Add(nuevo);
            }
            return lista;
        }

        public int createNewHabilidadInDB(SQL_Habilidad ha)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"Insert into habilidad(ind_id,atr_id) values(@ind_id,@atr_id)
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
            command.Parameters.AddWithValue("@ind_id", ha.ind_id);
            command.Parameters.AddWithValue("@atr_id", ha.atr_id);
            return SQL_manager.readTable(command).Rows[0].Field<int>("ID");
        }

        public void updateHanilidadInDB(SQL_Habilidad ha)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"update habilidad set hab_FinalValue=(Select * from evaluacion)(@ind_id,@atr_id)
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
            command.Parameters.AddWithValue("@ind_id", ha.ind_id);
            command.Parameters.AddWithValue("@atr_id", ha.atr_id);
        }

        public void deleteHabilidadInDB(SQL_Habilidad ha)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"delete from habilidad where hab_id=@hab_id";
            command.Parameters.AddWithValue("@hab_id", ha.hab_id);
            SQL_manager.executeCommand(command);
        }

        public bool IndividuoTieneAtributo(int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"Select * from habilidad where atr_id=@atr_id";
            command.Parameters.AddWithValue("@atr_id", id);
            if (SQL_manager.readTable(command).Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}