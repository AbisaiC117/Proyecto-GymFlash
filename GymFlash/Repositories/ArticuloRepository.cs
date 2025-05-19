using GymFlash.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public void CrearArticulo(ArticuloModel articulo)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Articulos (Nombre, Precio, Cantidad, Imagen) VALUES (@Nombre, @Precio, @Cantidad, @Imagen)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                    command.Parameters.AddWithValue("@Precio", articulo.Precio);
                    command.Parameters.AddWithValue("@Cantidad", articulo.Cantidad);
                    command.Parameters.AddWithValue("@Imagen", articulo.Imagen);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarArticulo(ArticuloModel articulo)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Articulos SET Nombre=@Nombre, Precio=@Precio, Cantidad=@Cantidad, Imagen=@Imagen WHERE Id=@Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", articulo.Id);
                    command.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                    command.Parameters.AddWithValue("@Precio", articulo.Precio);
                    command.Parameters.AddWithValue("@Cantidad", articulo.Cantidad);
                    command.Parameters.AddWithValue("@Imagen", articulo.Imagen);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarArticulo(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Articulos WHERE Id=@Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}