using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_ClassLibrary
{
    public class SQL_TipoRelacion : SQL_Object
    {

        public class SQL_ParticipacionEquipo : SQL_Object
        {
            public int par_id;
            public int ind_id;
            public int equ_id;
            public DateTime par_dateOfJoin;
            public List<SQL_Individuos> getIndividuosFromEquipo(SQL_Equipo team)
            {
            }
            public List<SQL_ParticipacionEquipo> getParticipacionesFromEquipo(SQL_Equipo team)
            {
            }
            public void getAllParticipaciones()
            {
            }
            public List<SQL_ParticipacionEquipo> getParticipacionFromIndividuo(SQL_Individuo person)
            {
            }
            public void createNewParticipacionInDB()
            {
            }
            public void updateNewParticipacionInDB()
            {
            }
            public void deleteParticipacionInDB()
            {
            }
        }

    }
}