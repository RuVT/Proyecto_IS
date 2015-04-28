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
    public class SQL_ParticipacionEquipo : SQL_Object, IParticipacionEquipo
    {
        public int par_id;
        public int ind_id;
        public int equ_id;
        public DateTime par_dateOfJoin;
        SqlCommand comando = new SqlCommand();

        public static SQL_ParticipacionEquipo Load1(DataRow dato)
        {
            SQL_ParticipacionEquipo Sql_P = new SQL_ParticipacionEquipo();
            Sql_P.par_id = dato.Field<int>("par_id");
            Sql_P.ind_id = dato.Field<int>("ind_id");
            Sql_P.equ_id = dato.Field<int>("equ_id");
            Sql_P.par_dateOfJoin = dato.Field<DateTime>("par_dateOfJoin");

            return Sql_P;
        }


        public List<SQL_Individuo> getIndividuosFromEquipo(SQL_Equipo team)
        {
            comando.CommandText = "select *" +
                             " From participacionEquipo" +
                             " where equ_id=@equ_id";

            comando.Parameters.AddWithValue("@equ_id", team.equ_id);

            DataTable dato_I = SQL_manager.readTable(comando);

            List<SQL_Individuo> lista_I = new List<SQL_Individuo>();

            foreach (DataRow x in dato_I.Rows)
            {
                lista_I.Add(SQL_Individuo.getIndividuoFromDBbyID((int)x["ind_id"]));
            }
            return lista_I;

        }
        public List<SQL_ParticipacionEquipo> getParticipacionesFromEquipo(SQL_Equipo team)
        {
            comando.CommandText = "select *" +
                            " From participacionEquipo" +
                            " where equ_id=@equ_id";

            comando.Parameters.AddWithValue("@equ_id", team.equ_id);

            DataTable dato_P = SQL_manager.readTable(comando);

            List<SQL_ParticipacionEquipo> lista_P = new List<SQL_ParticipacionEquipo>();
            foreach (DataRow x in dato_P.Rows)
            {
                lista_P.Add(Load1(x));
            }
            return lista_P;
        }
        public void getAllParticipaciones()
        {
            comando.CommandText = "select *" +
                                " From participacionEquipo";

        }
        public List<SQL_ParticipacionEquipo> getParticipacionFromIndividuo(SQL_Individuo person)
        {
            comando.CommandText = "select *" +
                            " From participacionEquipo" +
                            " where ind_id=@ind_id";

            comando.Parameters.AddWithValue("@equ_id", person.id);

            DataTable dato_P = SQL_manager.readTable(comando);

            List<SQL_ParticipacionEquipo> lista_P = new List<SQL_ParticipacionEquipo>();
            foreach (DataRow x in dato_P.Rows)
            {
                lista_P.Add(Load1(x));
            }
            return lista_P;


        }
        public void createNewParticipacionInDB()
        {
            comando.CommandText = @"INSERT INTO participacionEquipo(ind_id,equ_id,par_dateOfJoin) 
                                                    VALUES (@ind_id,@equ_id,@par_dateOfJoin)";
            
            comando.Parameters.AddWithValue("@ind_id", ind_id);
            comando.Parameters.AddWithValue("@equ_id", equ_id);
            comando.Parameters.AddWithValue("@par_dateOfJoin", par_dateOfJoin);

            SQL_manager.executeCommand(comando);
        }
        public void updateNewParticipacionInDB()
        {
            comando.CommandText = @"UPDATE participacionEquipo SET ind_id = @ind_id, equ_id = @equ_id, par_dateOfJoin=@par_dateOfJoin
                                                        WHERE par_id = @par_id ";
       
            comando.Parameters.AddWithValue("@ind_id", ind_id);
            comando.Parameters.AddWithValue("@equ_id", equ_id);
            comando.Parameters.AddWithValue("@par_dateOfJoin", par_dateOfJoin);
            SQL_manager.executeCommand(comando);
        }
        public void deleteParticipacionInDB()
        {
            comando.CommandText = @"DELETE FROM participacionEquipo  WHERE par_id = @par_id";
            comando.Parameters.AddWithValue("@par_id", par_id);
            SQL_manager.executeCommand(comando);
        }
    }
}