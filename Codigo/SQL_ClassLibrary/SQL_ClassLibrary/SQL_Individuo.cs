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
        public string name;
        public string last_name1;
        public string last_name2;
        public DateTime years;
        public string direction;
        public int telephone;
        public string email;

        

        public int createNewIndividuoInDB(SQL_Individuo ind)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Insert into individuo(ind_name, ind_lastName1, ind_lastName2, ind_years, ind_direction, ind_telephone, ind_email)" +
                                                " Values (@ind_name, @ind_lastName1, @ind_lastName2, @ind_years, @ind_direction, @ind_telephone, @ind_email)"+
                                                " Select CAST(SCOPE_IDENTITY() AS int) as ID";
            if (ind.name == null)
                ind.name = "";
            if (ind.last_name1 == null)
                ind.last_name1 = "";
            if (ind.last_name2 == null)
                ind.last_name2 = "";
            if (ind.direction == null)
                ind.direction = "";
            if (ind.email == null)
                ind.email = "";
            comando.Parameters.AddWithValue("@ind_name", ind.name);
            comando.Parameters.AddWithValue("@ind_lastName1", ind.last_name1);
            comando.Parameters.AddWithValue("@ind_lastName2", ind.last_name2);
            comando.Parameters.AddWithValue("@ind_years", ind.years);
            comando.Parameters.AddWithValue("@ind_direction", ind.direction);
            comando.Parameters.AddWithValue("@ind_telephone", ind.telephone);
            comando.Parameters.AddWithValue("@ind_email", ind.email);
            DataTable table = SQL_manager.readTable(comando);
            int id=table.Rows[0].Field<int>("ID");
            return id;
        }
        public void updateIndividuoInDB(SQL_Individuo ind)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Update individuo Set" + 
                                    " ind_name=@ind_name,"+
                                    " ind_lastName1=@ind_lastName1,"+
                                    " ind_lastName2=@ind_lastName2,"+ 
                                    " ind_years=@ind_years, "+
                                    " ind_direction=@ind_direction,"+
                                    " ind_telephone=@ind_telephone,"+
                                    " ind_email=@ind_email"+
                                    " where ind_id=@ind_id";
            
            comando.Parameters.AddWithValue("@ind_id", ind.id);
            comando.Parameters.AddWithValue("@ind_name", ind.name);
            comando.Parameters.AddWithValue("@ind_lastName1", ind.last_name1);
            comando.Parameters.AddWithValue("@ind_lastName2", ind.last_name2);
            comando.Parameters.AddWithValue("@ind_years", ind.years);
            comando.Parameters.AddWithValue("@ind_direction", ind.direction);
            comando.Parameters.AddWithValue("@ind_telephone", ind.telephone);
            comando.Parameters.AddWithValue("@ind_email", ind.email);

            SQL_manager.executeCommand(comando);
        }
        public void deleteIndiviuoInDB(SQL_Individuo ind)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "Delete From individuo Where ind_id = @ind_id ";
            comando.Parameters.AddWithValue("@ind_id", ind.id);

            SQL_manager.executeCommand(comando);
        }
        public List<SQL_Individuo> searchIndividuoByName(string _name)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "select *"+
                                  " From individuo"+
                                  " Where ind_name like  '%"+_name+"%' ";

            //comando.Parameters.AddWithValue("@ind_name", _name);

            DataTable table =SQL_manager.readTable(comando);
            return Load(table);
        }
        public SQL_Individuo getIndividuoFromDBbyID(int _id)
        {
            SqlCommand comando = new SqlCommand();
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
            Sql_I.years = dato.Field<DateTime>("ind_years");
            Sql_I.direction = dato.Field<string>("ind_direction");
            Sql_I.telephone = dato.Field<int>("ind_telephone");
            Sql_I.email = dato.Field<string>("ind_email");
            return Sql_I;
        }
    }
}