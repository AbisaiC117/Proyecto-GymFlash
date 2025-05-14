using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GymFlash.Model;

namespace GymFlash.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                // Agregado ID_TipoMembresia en la consulta SQL
                command.CommandText = @"INSERT INTO [User] 
                    (Username, Password, Name, Lastname, Email, Edad, Peso, Altura, IMC, ID_TipoMembresia) 
                    VALUES 
                    (@username, @password, @name, @lastname, @email, @edad, @peso, @altura, @imc, @ID_TipoMembresia)";

                command.Parameters.AddWithValue("@username", userModel.Username);
                command.Parameters.AddWithValue("@password", userModel.Password);
                command.Parameters.AddWithValue("@name", userModel.Name);
                command.Parameters.AddWithValue("@lastname", userModel.Lastname);
                command.Parameters.AddWithValue("@email", userModel.Email);

                // Conversión segura de tipos
                command.Parameters.AddWithValue("@edad", int.Parse(userModel.Edad));
                command.Parameters.AddWithValue("@peso", decimal.Parse(userModel.Peso));
                command.Parameters.AddWithValue("@altura", decimal.Parse(userModel.Altura));
                command.Parameters.AddWithValue("@imc", decimal.Parse(userModel.IMC));

                // Asegúrate de que sea int en el modelo
                command.Parameters.AddWithValue("@ID_TipoMembresia", userModel.ID_TipoMembresia);

                command.ExecuteNonQuery();
            }

            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(1) FROM [User] WHERE Username = @username AND Password = @password";
                command.Parameters.AddWithValue("@username", credential.UserName);
                command.Parameters.AddWithValue("@password", credential.Password);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }        
        }


        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            Lastname = reader["Lastname"].ToString(),
                            Email = reader["Email"].ToString(),
                            Edad = reader["Edad"].ToString(),
                            Peso = reader["Peso"].ToString(),
                            Altura = reader["Altura"].ToString(),
                            IMC = reader["IMC"].ToString(),
                            ID_TipoMembresia = Convert.ToInt32(reader["ID_TipoMembresia"])
                        };
                    }
                }
            }

            return user;
        }

        public void UpdateMembership(string userId, int membershipType)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [User] SET ID_TipoMembresia = @membershipType WHERE ID = @userId";
                command.Parameters.AddWithValue("@membershipType", membershipType);
                command.Parameters.AddWithValue("@userId", Guid.Parse(userId));
                command.ExecuteNonQuery();
            }
        }

    }
}
