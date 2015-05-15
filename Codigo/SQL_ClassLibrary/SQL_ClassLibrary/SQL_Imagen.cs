using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQL_ClassLibrary.ServiceInterface;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace SQL_ClassLibrary
{
    public class SQL_Imagen:IImagen
    {
        public int ima_id;
        public byte[] ima_dat;
        public int ind_id;

        public List<SQL_Imagen> getImagenFromIndividio(int ind_id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"Select * from imagen where ind_id=@ind_id";
            command.Parameters.AddWithValue("@ind_id", ind_id);
            return load(SQL_manager.readTable(command));
        }

        public static List<SQL_Imagen> load(DataTable table)
        {
            List<SQL_Imagen> temp = new List<SQL_Imagen>();
            foreach (DataRow row in table.Rows)
            {
                temp.Add(load(row)); 
            }
            return temp;
        }

        public static SQL_Imagen load(DataRow row)
        {
            SQL_Imagen temp = new SQL_Imagen();
            temp.ima_id = row.Field<int>("ima_id");
            temp.ima_dat = row.Field<byte[]>("ima_dat");
            temp.ind_id = row.Field<int>("ind_id");
            return temp;
        }

        public int createNewImageInDB(SQL_Imagen ima)
        {
            SqlCommand command = new SqlCommand();
            if (ima.ima_dat != null)
            {
                command.CommandText = @"Insert into imagen(ima_dat,ind_id) values(@ima_dat,@ind_id)
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
                command.Parameters.AddWithValue("@ind_id", ima.ind_id);
                command.Parameters.AddWithValue("@ima_dat", ima.ima_dat);
            }
            else
            {
                command.CommandText = @"Insert into imagen(ind_id) values(@ind_id)
                                    Select CAST(SCOPE_IDENTITY() AS int) as ID";
                command.Parameters.AddWithValue("@ind_id", ima.ind_id);
            }

            return SQL_manager.readTable(command).Rows[0].Field<int>("ID");
        }

        public void updateImagenInDB(SQL_Imagen ima)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"update imagen set ima_dat=@ima_dat, ind_id=@ind_id where ima_id=@ima_id";
            command.Parameters.AddWithValue("@ima_dat", ima.ima_dat);
            command.Parameters.AddWithValue("@ind_id", ima.ind_id);
            command.Parameters.AddWithValue("@ima_id", ima.ima_id);
            SQL_manager.executeCommand(command);
        }

        public void deleteImagenInDB(SQL_Imagen ima)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = @"delete imagen where ima_id=@ima_id";
            command.Parameters.AddWithValue("@ima_id", ima.ima_id);
            SQL_manager.executeCommand(command);
        }


    }
}
