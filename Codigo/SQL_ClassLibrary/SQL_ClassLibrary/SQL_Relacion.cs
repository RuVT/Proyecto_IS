using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_ClassLibrary.ServiceInterface;
using System.Data.SqlClient;

namespace SQL_ClassLibrary
{
    public class SQL_Relacion : IRelacion
    {
        public int rel_id;
        public int tipRe_id;
        public int ind_idIni;
        public int ind_idFin;
        public double rel_val;
        
        //public SQL_Relacion(int id=-1, int tip=-1, int ind1=-1, int ind2=-1, double val=-1)
        //{
        //    rel_id = id;
        //    tipRe_id = tip;
        //    ind_idIni = ind1;
        //    ind_idFin = ind2;
        //    rel_val = val;
        //}
        
        public List<SQL_Relacion> getRelations(SQL_Individuo person)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from relacion where tipRe_id = @tipRe_id";
            command.Parameters.AddWithValue("@tipRe_id", person.id);
            DataTable table = SQL_manager.readTable(command);
            return load(table);
        }
        
        public List<SQL_Relacion> load(DataTable data)
        {
            List<SQL_Relacion> relaciones = new List<SQL_Relacion>();
            foreach (DataRow row in data.Rows)
            {
                relaciones.Add(load(row));        
            }
            return relaciones;
        }
        
        public SQL_Relacion load(DataRow data)
        {
            SQL_Relacion temp= new SQL_Relacion();
            temp.rel_id=data.Field<int>("rel_id");
            temp.tipRe_id=data.Field<int>("tipRe_id");
            temp.ind_idIni=data.Field<int>("ind_idIni");
            temp.ind_idFin=data.Field<int>("ind_idFin");
            temp.rel_val=data.Field<float>("rel_val");
            return temp;
        }
        
        public int createNewRelacionInDB(SQL_Relacion re)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"INSERT INTO relacion(tipRe_id,ind_idIni,ind_idFin) 
                                    VALUES(@tipRe_id,@ind_idIni,@ind_idFin)
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
            command.Parameters.AddWithValue("@tipRe_id", re.tipRe_id);
            command.Parameters.AddWithValue("@ind_idIni", re.ind_idIni);
            command.Parameters.AddWithValue("@ind_idFin", re.ind_idFin);
            return SQL_manager.readTable(command).Rows[0].Field<int>("ID");
        }

        public void deleteRelacionInDB(SQL_Relacion re)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"DELETE FROM relacion WHERE rel_id = @rel_id";
            command.Parameters.AddWithValue("@rel_id", re.rel_id);
            SQL_manager.executeCommand(command);
        }

        public void updateRelacionInDB(SQL_Relacion re)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"UPDATE relacion SET tipRe_id = @tipRe_id ,ind_idIni = @ind_idIni ,
                                                        ind_idFin = @ind_idFin WHERE rel_id = @rel_id";
            command.Parameters.AddWithValue("@rel_id", re.rel_id);
            command.Parameters.AddWithValue("@tipRe_id", re.tipRe_id);
            command.Parameters.AddWithValue("@ind_idIni", re.ind_idIni);
            command.Parameters.AddWithValue("@ind_idFin", re.ind_idFin);
            SQL_manager.executeCommand(command);
        }
    }
}
