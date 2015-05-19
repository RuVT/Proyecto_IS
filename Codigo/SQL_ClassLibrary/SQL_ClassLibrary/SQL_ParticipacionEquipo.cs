using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary.ServiceInterface;
using System.Data.SqlClient;
using System.Data;
namespace SQL_ClassLibrary
{
    public class SQL_ParticipacionEquipo : IParticipacionEquipo
    {
        public int par_id;
        public int ind_id;
        public int equ_id;
        public DateTime par_dateOfJoin;
        SqlCommand comando = new SqlCommand();

        public static SQL_ParticipacionEquipo load(DataRow dato)
        {
            SQL_ParticipacionEquipo Sql_P = new SQL_ParticipacionEquipo();
            Sql_P.par_id = dato.Field<int>("par_id");
            Sql_P.ind_id = dato.Field<int>("ind_id");
            Sql_P.equ_id = dato.Field<int>("equ_id");
            Sql_P.par_dateOfJoin = dato.Field<DateTime>("par_dateOfJoin");

            return Sql_P;
        }

        public static List<SQL_ParticipacionEquipo> load(DataTable data)
        {
            List<SQL_ParticipacionEquipo> temp = new List<SQL_ParticipacionEquipo>();
            foreach (DataRow row in data.Rows)
            {
                temp.Add(load(row));
            }
            return temp;
        }

        public List<SQL_Individuo> getIndividuosFromEquipo(int id)
        {
            comando.CommandText = "select *" +
                             " From participacionEquipo" +
                             " where equ_id=@equ_id";

            comando.Parameters.AddWithValue("@equ_id", id);

            DataTable dato_I = SQL_manager.readTable(comando);

            List<SQL_Individuo> lista_I = new List<SQL_Individuo>();
            SQL_Individuo temp = new SQL_Individuo();
            foreach (DataRow x in dato_I.Rows)
            {
                lista_I.Add(temp.getIndividuoFromDBbyID((int)x["ind_id"]));
            }
            return lista_I;

        }
        public List<SQL_ParticipacionEquipo> getParticipacionesFromEquipo(int id)
        {
            comando.CommandText = "select *" +
                            " From participacionEquipo" +
                            " where equ_id=@equ_id";

            comando.Parameters.AddWithValue("@equ_id", id);

            DataTable dato_P = SQL_manager.readTable(comando);

            List<SQL_ParticipacionEquipo> lista_P = new List<SQL_ParticipacionEquipo>();
            foreach (DataRow x in dato_P.Rows)
            {
                lista_P.Add(load(x));
            }
            return lista_P;
        }
        public List<SQL_ParticipacionEquipo> getAllParticipaciones()
        {
            comando.CommandText = "select *" +
                                " From participacionEquipo";
            DataTable table=SQL_manager.readTable(comando);
            return load(table);
        }
        public List<SQL_ParticipacionEquipo> getParticipacionFromIndividuo(int id)
        {
            comando.CommandText = "select *" +
                            " From participacionEquipo" +
                            " where ind_id=@ind_id";

            comando.Parameters.AddWithValue("@ind_id", id);

            DataTable dato_P = SQL_manager.readTable(comando);

            List<SQL_ParticipacionEquipo> lista_P = new List<SQL_ParticipacionEquipo>();
            foreach (DataRow x in dato_P.Rows)
            {
                lista_P.Add(load(x));
            }
            return lista_P;


        }
        public int createNewParticipacionInDB(SQL_ParticipacionEquipo pa)
        {
            comando.CommandText = @"INSERT INTO participacionEquipo(ind_id,equ_id,par_dateOfJoin) 
                                    VALUES (@ind_id,@equ_id,@par_dateOfJoin) 
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
            
            comando.Parameters.AddWithValue("@ind_id", pa.ind_id);
            comando.Parameters.AddWithValue("@equ_id", pa.equ_id);
            comando.Parameters.AddWithValue("@par_dateOfJoin", pa.par_dateOfJoin);

            return SQL_manager.readTable(comando).Rows[0].Field<int>("ID");
        }
        public void updateNewParticipacionInDB(SQL_ParticipacionEquipo pa)
        {
            comando.CommandText = @"UPDATE participacionEquipo SET ind_id = @ind_id, equ_id = @equ_id, par_dateOfJoin=@par_dateOfJoin
                                                        WHERE par_id = @par_id ";
       
            comando.Parameters.AddWithValue("@ind_id", pa.ind_id);
            comando.Parameters.AddWithValue("@equ_id", pa.equ_id);
            comando.Parameters.AddWithValue("@par_dateOfJoin", pa.par_dateOfJoin);
            SQL_manager.executeCommand(comando);
        }
        public void deleteParticipacionInDB(SQL_ParticipacionEquipo pa)
        {
            comando.CommandText = @"DELETE FROM participacionEquipo  WHERE par_id = @par_id";
            comando.Parameters.AddWithValue("@par_id", pa.par_id);
            SQL_manager.executeCommand(comando);
        }
    }
}