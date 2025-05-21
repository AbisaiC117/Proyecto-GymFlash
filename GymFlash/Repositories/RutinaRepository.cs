using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GymFlash.Model;

namespace GymFlash.Repositories
{
    public class RutinaRepository : RepositoryBase
    {
  

        public List<RutinaModel> GetAllRutinas()
        {
            var rutinas = new List<RutinaModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Rutina";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rutinas.Add(new RutinaModel
                        {
                            ID_Rutina = reader.GetGuid(reader.GetOrdinal("ID_Rutina")),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            ImagenURL = reader.IsDBNull(reader.GetOrdinal("ImagenURL")) ? null : reader["ImagenURL"].ToString(),
                            ID_Entrenador = reader.GetGuid(reader.GetOrdinal("ID_Entrenador")),
                        });
                    }
                }
            }
            return rutinas;
        }

        public void AgregarRutina(RutinaModel rutina)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Rutina (ID_Rutina, Nombre, Descripcion, ID_Entrenador, ImagenURL) " +
                               "VALUES (@ID, @Nombre, @Descripcion, @ID_Entrenador, @ImagenURL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", rutina.ID_Rutina);
                cmd.Parameters.AddWithValue("@Nombre", rutina.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", rutina.Descripcion);
                cmd.Parameters.AddWithValue("@ID_Entrenador", rutina.ID_Entrenador);
                cmd.Parameters.AddWithValue("@ImagenURL", (object)rutina.ImagenURL ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }


        public void EliminarRutina(Guid idRutina)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Rutina WHERE ID_Rutina = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idRutina);
                cmd.ExecuteNonQuery();
            }
        }

        public EntrenadorModel GetEntrenadorInfo(Guid idEntrenador)
        {
            EntrenadorModel entrenador = null;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT e.ID_Entrenador, u.[Name], e.Especialidad, e.AñosExperiencia
            FROM Entrenador e
            INNER JOIN [User] u ON e.ID_Entrenador = u.ID
            WHERE e.ID_Entrenador = @ID_Entrenador";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_Entrenador", idEntrenador);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        entrenador = new EntrenadorModel
                        {
                            ID_Entrenador = reader.GetGuid(0),
                            nombreEntrenador = reader.GetString(1),
                            especialidad = reader.GetString(2),
                            aniosExperiencia = reader.GetInt32(3)
                        };
                    }
                }
            }
            return entrenador;
        }
    }
}
