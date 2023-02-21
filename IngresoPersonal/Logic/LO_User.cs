using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Sql;
using System.Data;
using IngresoPersonal.Models;
using System.Data.SqlClient;

namespace IngresoPersonal.Logic
{
    public class LO_User
    {

        public UsersInd FindUser(string userName, string password)
        {
            UsersInd obj = new UsersInd();

            using (SqlConnection connection = new SqlConnection("data source=10.207.114.24;initial catalog=ASISTENCIA_TISUR;persist security info=True;user id=ufoto;password=Foto2023*"))
            {
                string query = "SELECT name,lastname,DNI,username,password,email,idRol from Users where username = @puserName and password = @ppassword";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@puserName", userName);
                cmd.Parameters.AddWithValue("@ppassword", password);
                cmd.CommandType = CommandType.Text;

                connection.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        obj = new UsersInd()
                        {                            
                            name = dr["name"].ToString(),
                            lastName = dr["lastname"].ToString(),
                            DNI = dr["DNI"].ToString(),
                            username = dr["username"].ToString(),
                            password = dr["password"].ToString(),
                            email= dr["email"].ToString(),
                            idRol = (RolesInd)dr["idRol"],
                        };
                    }
                }
            }
            return obj;
        }

    }
}