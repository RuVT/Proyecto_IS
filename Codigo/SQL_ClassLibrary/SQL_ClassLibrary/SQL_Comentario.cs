using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary.ServiceInterface;

namespace SQL_ClassLibrary
{
    public class SQL_Comentario : SQL_Object, IComentario
    {
        public int com_id;
        public string com_text;
        public int ind_idSender;
        public int ind_idResiver;
        public SQL_Comentario getComentarioFromIndoviduo(SQL_Individuo person)
        {
        }
        public SQL_Comentario getComentarioToIndoviduo(SQL_Individuo person)
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