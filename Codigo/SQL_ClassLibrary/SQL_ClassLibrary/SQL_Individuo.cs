using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SQL_ClassLibrary.ServiceInterface;

namespace SQL_ClassLibrary
{
    public class SQL_Individuo : IIndividuo
    {
        public int id;
        private string name;
        private string last_name1;
        private string last_name2;
        public int years;
        public string direction;
        public int telephone;
        public string email;

        static SqlCommand comando = new SqlCommand();

        public void SQL_Idividuo()
        {
        }
        public void createNewIndividuoInDB()
        {
            comando.CommandText = "Insert into individuo(ind_id, ind_name, ind_lastName1, ind_lastName2, ind_years, ind_direction, ind_telephone, ind_email)" +
                                                " Values (@ind_id, @ind_name, @ind_lastName1, @ind_lastName2, @ind_years, @ind_direction, @ind_telephone, @ind_email)";

            comando.Parameters.AddWithValue("@ind_id", id);
            comando.Parameters.AddWithValue("@ind_name", name);
            comando.Parameters.AddWithValue("@ind_lastName1", last_name1);
            comando.Parameters.AddWithValue("@ind_lastName2", last_name2);
            comando.Parameters.AddWithValue("@ind_years", years);
            comando.Parameters.AddWithValue("@ind_direction", direction);
            comando.Parameters.AddWithValue("@ind_telephone", telephone);
            comando.Parameters.AddWithValue("@ind_email", email);

            SQL_manager.executeCommand(comando);
        }
        public void updateIndividuoInDB()
        {
            comando.CommandText = "Update individuo Set" + 
                                    " ind_id=@ind_id,"+
                                    " ind_name=@ind_name,"+
                                    " ind_lastName1=@ind_lastName1,"+
                                    " ind_lastName2=@ind_lastName2,"+ 
                                    " ind_years=@ind_years, "+
                                    " ind_direction=@ind_direction,"+
                                    " ind_telephone=@ind_telephone,"+
                                    " ind_email=@ind_email,"+
                                    " where ind_id=@ind_id";
            
            comando.Parameters.AddWithValue("@ind_id", id);
            comando.Parameters.AddWithValue("@ind_name", name);
            comando.Parameters.AddWithValue("@ind_lastName1", last_name1);
            comando.Parameters.AddWithValue("@ind_lastName2", last_name2);
            comando.Parameters.AddWithValue("@ind_years", years);
            comando.Parameters.AddWithValue("@ind_direction", direction);
            comando.Parameters.AddWithValue("@ind_telephone", telephone);
            comando.Parameters.AddWithValue("@ind_email", email);

            SQL_manager.executeCommand(comando);
        }
        public void deleteIndiviuoInDB()
        {
            comando.CommandText = "Delete From individuo Where ind_id = @ind_id ";
            comando.Parameters.AddWithValue("@ind_id", id);

            SQL_manager.executeCommand(comando);
        }
        public List<SQL_Individuo> searchIndividuoByName(string _name)
        {
            comando.CommandText = "select *"+
                                  " From individuo"+
                                  " Where ind_name = @ind_name ";

            comando.Parameters.AddWithValue("@ind_name", _name);

            DataTable table =SQL_manager.readTable(comando);
            return Load(table);
        }
        public SQL_Individuo getIndividuoFromDBbyID(int _id)
        {
            comando.CommandText = "select *" +
                                 " From individuo" +
                                 " Where ind_id = @ind_id ";

            comando.Parameters.AddWithValue("@ind_id", _id);

           DataTable dato_I=SQL_manager.readTable(comando);
           return Load(dato_I)[0];       
        }
       
        public List<SQL_Individuo> Load(DataTable data)
        {
            List<SQL_Individuo> lista_I = new List<SQL_Individuo>();
            foreach (DataRow x in data.Rows)
            {
                lista_I.Add(Load(x));
            }
            return lista_I;
            
        }
        public SQL_Individuo Load(DataRow dato)
        {
            SQL_Individuo Sql_I = new SQL_Individuo();
            Sql_I.id = dato.Field<int>("ind_id");
            Sql_I.name = dato.Field<string>("ind_name");
            Sql_I.last_name1 = dato.Field<string>("ind_lastName1");
            Sql_I.last_name2 = dato.Field<string>("ind_lastName2");
            Sql_I.years = dato.Field<int>("ind_years");
            Sql_I.direction = dato.Field<string>("ind_direction");
            Sql_I.telephone = dato.Field<int>("ind_telephone");
            Sql_I.email = dato.Field<string>("ind_email");
            return Sql_I;
        }
    }
}