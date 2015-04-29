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
    public class SQL_Usuario : IUsuario
    {
        private int id;
        private string name;
        private string password;
        private string type;
        private int ind_id;
        private static SQL_Usuario user = null;
        private SQL_Usuario()
        {
            id = -1;
            name = "";
            password = "";
            type = "";

        }
        public static SQL_Usuario createUser()
        {
            if(user==null)
                user=new SQL_Usuario();
            return user;
        }
        public void createNewUsuarioInDB()
        {
            SqlCommand command=new SqlCommand();
            command.CommandText=@"Insert into usuario(usu_account,usu_password,usu_level) 
                                    values(@usu_account,@usu_password,@usu_level)";
            command.Parameters.AddWithValue("@usu_account", name);
            command.Parameters.AddWithValue("@usu_password", password);
            command.Parameters.AddWithValue("@usu_level", type);            
            SQL_manager.executeCommand(command);
        }
        public void deleteUsuarioInDB()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Delete from usuario where @usu_id and @usu_account";
            SQL_manager.executeCommand(command);
        }
        
        public static SQL_Usuario load(DataTable data)
        {
            DataRow row;
            if (data != null)
            {
                if (data.Rows.Count >= 0)
                {
                    row = data.Rows[0];
                    SQL_Usuario tempUser = createUser();
                    tempUser.id = row.Field<int>("usu_id");
                    tempUser.name = row.Field<string>("usu_account");
                    tempUser.password = row.Field<string>("usu_password");
                    tempUser.type = row.Field<string>("usu_level");
                    tempUser.ind_id=row.Field<int>("ind_id");
                    return tempUser;
                }
                else
                    return null;
            }
            else
                return null;
        }
        public void updateUsuarioInDB()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"update usuario set usu_account=@usu_account,
                                                       usu_password=@usu_password,
                                                       usu_level=@usu_level,
                                                       ind_id=@ind_id";
            command.Parameters.AddWithValue("@usu_account", name);
            command.Parameters.AddWithValue("@usu_password", password);
            command.Parameters.AddWithValue("@usu_level", type);
            command.Parameters.AddWithValue("@ind_id", ind_id);
            SQL_manager.executeCommand(command);
        }
        public bool userExist(string _name)
        {
            DataTable table = SQL_manager.readTable("Select usu_account from usuario where usu_account=" + _name);
            if (table.Rows.Count>=0)
                return false;
            else
                return true;
        }
        public bool passwordIsCorrect(string _password)
        {
            if (password == _password)
                return true;
            else
                return false;
        }
        public SQL_Usuario getUsuarioByName(string _name)
        {
            DataTable table = SQL_manager.readTable("Select * from usuario where usu_account=" + _name);
            SQL_Usuario tempUser = load(table);
            return tempUser;
        }
        public bool login(string _name, string _password)
        {
            if (userExist(_name))
            {
                return getUsuarioByName(_name).passwordIsCorrect(_password); 
            }
            return false;
        }
    }
}