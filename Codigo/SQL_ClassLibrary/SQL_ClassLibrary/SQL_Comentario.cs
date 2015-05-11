using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary.ServiceInterface;
using System.Data;
using System.Data.SqlClient;

namespace SQL_ClassLibrary
{
    public class SQL_Comentario : IComentario
    {
        public int com_id;
        public string com_text;
        public int ind_idSender;
        public int ind_idResiver;
        public List<SQL_Comentario> getComentarioFromIndoviduo(SQL_Individuo person)
        {
            DataTable table= SQL_manager.readTable("Select * from comentario where ind_idSender = " + person.id);
            return load(table);
        }
        public static List<SQL_Comentario> load(DataTable data)
        {
            List<SQL_Comentario> list = new List<SQL_Comentario>();
            foreach (DataRow row in data.Rows)
                list.Add(load(row));
            return list;
        }
        
        public static SQL_Comentario load(DataRow data)
        {
            SQL_Comentario tempCom = new SQL_Comentario();
            tempCom.com_id = data.Field<int>("com_id");
            tempCom.com_text = data.Field<string>("com_text");
            tempCom.ind_idResiver = data.Field<int>("ind_idResiver");
            tempCom.ind_idSender = data.Field<int>("ind_idSender");
            return tempCom;
        }

        public List<SQL_Comentario> getComentarioToIndoviduo(SQL_Individuo person)
        {
            DataTable table = SQL_manager.readTable("Select * from comentario where ind_idResiver = " + person.id);
            return load(table);
        }

        public List<SQL_Comentario> getComentario(SQL_Individuo sender, SQL_Individuo resiver)
        {
            DataTable table = SQL_manager.readTable("Select * from comentario where ind_idSender = " + sender.id + " and ind_idResiver = "+resiver.id);
            return load(table);
        }

        public int createNewComentarioInB(SQL_Comentario co)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"insert into comentario(com_text,ind_idSender,ind_idResiver)
                                    values (@com_text,@ind_idSender,@ind_idResiver)
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
            command.Parameters.AddWithValue("@com_text", co.com_text);
            command.Parameters.AddWithValue("@ind_idSender", co.ind_idSender);
            command.Parameters.AddWithValue("@ind_idResiver", co.ind_idResiver);
            return SQL_manager.readTable(command).Rows[0].Field<int>("ID");
        }
        public void updateComentarioInDB(SQL_Comentario co)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"update comentario set com_text=@com_text,ind_idSender=@ind_idSender,ind_idResiver=@ind_idResiver
                                    where com_id = @com_id";
            command.Parameters.AddWithValue("@com_text", co.com_text);
            command.Parameters.AddWithValue("@ind_idSender", co.ind_idSender);

            command.Parameters.AddWithValue("@ind_idResiver", co.ind_idResiver);
            SQL_manager.executeCommand(command);
        }
        public void deleteComentarioInDB(SQL_Comentario co)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"delete from comentario where com_id = @com_id";            
            command.Parameters.AddWithValue("@com_id", co.com_id);
            SQL_manager.executeCommand(command);
        }
    }
}