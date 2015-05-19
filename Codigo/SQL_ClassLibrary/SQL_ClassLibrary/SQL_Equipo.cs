using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary.ServiceInterface;

namespace SQL_ClassLibrary
{
    public class SQL_Equipo :  IEquipo
    {
        public int equ_id;
        public string equ_name;
        public DateTime equ_dateOfCreation;
        public SQL_Equipo()
        {
            equ_id = -1;
            equ_name = "";
            equ_dateOfCreation = DateTime.Today;
        }
        public List<SQL_Equipo> searchEquiposByName(string name)
        {
            DataTable table = SQL_manager.readTable("Select * from equipo where equ_name = " + name);
            return load(table);
        }
        public List<SQL_Equipo> getAllEquipos()
        {
            DataTable table = SQL_manager.readTable("Select * from equipo");
            return load(table);
        }
        public SQL_Equipo getEquipoByID(int id)
        {
            DataTable table = SQL_manager.readTable("Select * from equipo where equ_id = " + id);
            return load(table)[0];
        }

        public List<SQL_Equipo> load(DataTable data)
        {
            List<SQL_Equipo> teams = new List<SQL_Equipo>();
            foreach (DataRow row in data.Rows)
            {
                teams.Add(load(row));
            }
            return teams;
        }

        public SQL_Equipo load(DataRow row)
        {
            SQL_Equipo team = new SQL_Equipo();
            team.equ_id = row.Field<int>("equ_id");
            team.equ_name = row.Field<string>("equ_name");
            team.equ_dateOfCreation = row.Field<DateTime>("equ_dateOfCreation");
            return team;
        }

        public int createNewEquipoInDB(SQL_Equipo eq)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"Insert into equipo(equ_name,equ_dateOfCreation)
                                        values(@equ_name,@equ_dateOfCreation)
                                        Select CAST(SCOPE_IDENTITY() AS int) as ID";
            command.Parameters.AddWithValue("@equ_name", eq.equ_name);
            command.Parameters.AddWithValue("@equ_dateOfCreation", eq.equ_dateOfCreation);
            return SQL_manager.readTable(command).Rows[0].Field<int>("ID");
        }
        public void updateEquipoInDB(SQL_Equipo eq)
        {
                SqlCommand command = new SqlCommand();
                command.CommandText = @"update equipo set equ_name = @equ_name,equ_dateOfCreation = @equ_dateOfCreation
                                            where equ_id";
                command.Parameters.AddWithValue("@equ_name",eq.equ_name);
                command.Parameters.AddWithValue("@equ_dateOfCreation", eq.equ_dateOfCreation);
                SQL_manager.executeCommand(command);
        }
        public void deleteEquipoInDB(SQL_Equipo eq)
        {
            SQL_manager.executeCommand("delete from equipo where equ_id = " + eq.equ_id);
        }
    }
}