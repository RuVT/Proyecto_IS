using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_TipoRelacion : SQL_Object
    {

        public class SQL_Comentario_ : SQL_Object
        {
            public int com_id;
            public string com_text;
            public int ind_idSender;
            public int ind_idResiver;
            public void getComentarioFromIndoviduo(SQL_Individuo person)
            {
            }
            public void getComentarioToIndoviduo(SQL_Individuo person)
            {
            }
            public void createNewComentarioInB()
            {
            }
            public void updateComentarioInDB()
            {
            }
            public void deleteComentarioInDB()
            {
            }
        }
    }
}