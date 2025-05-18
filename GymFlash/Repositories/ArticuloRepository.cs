using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GymFlash.Model;

namespace GymFlash.Repositories
{
    public class ArticuloRepository : RepositoryBase
    {
        public List<ArticuloModel> ObtenerArticulos()
        {
            List<ArticuloModel> articulos = new List<ArticuloModel>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Articulos";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    articulos.Add(new ArticuloModel
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Precio = reader["Precio"] != DBNull.Value ? Convert.ToDouble(reader["Precio"]) : 0.0,
                        Cantidad = (int)reader["Cantidad"],
                        Imagen = reader["Imagen"].ToString()
                    });
                }

                reader.Close(); // Se cierra correctamente
            }

            return articulos;
        }

        public void RegistrarCompra(int idArticulo, string idUsuario, int cantidad)
        {
            if (cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor a 0.");
            }

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Compra (IdArticulo, IdUsuario, Cantidad, Fecha) VALUES (@idArticulo, @idUsuario, @cantidad, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idArticulo", idArticulo);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.Parameters.AddWithValue("@cantidad", cantidad);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarCantidad(int idArticulo, int cantidad)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Articulos SET Cantidad = Cantidad - @cantidad WHERE Id = @idArticulo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cantidad", cantidad);
                    command.Parameters.AddWithValue("@idArticulo", idArticulo);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}