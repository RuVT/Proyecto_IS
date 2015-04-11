using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_Usuario : SQL_Object
    {
        private int id;
        private string name;
        private string password;
        private string type;
        private SQL_Usuario user = null;
        private void SQL_Usuario()
        {
        }
        public SQL_Usuario createUser()
        {
        }
        public void createNewUsuarioInDB()
        {
        }
        public void deleteUsuarioInDB()
        {
        }
        public SQL_Usuario load(DataTable data)
        {
        }
        public void updateUsuarioInDB()
        {
        }
        public bool userExist(sting _name)
        {
        }
        private bool passwordIsCorrect(string _password)
        {
        }
        public void login(string _name, string _password)
        {
        }
    }
}