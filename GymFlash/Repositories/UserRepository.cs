using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GymFlash.Model;

namespace GymFlash.Repositories
{
    public class UserRepository : RepositoryBase,IUserRepository
    {
        public void Add(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO [User] 
            (Username, Password, Name, Lastname, Email, Edad, Peso, Altura, IMC, ID_TipoMembresia, ID_TipoUsuario) 
            VALUES 
            (@username, @password, @name, @lastname, @email, @edad, @peso, @altura, @imc, @ID_TipoMembresia, @ID_TipoUsuario)";

                command.Parameters.AddWithValue("@username", userModel.Username);
                command.Parameters.AddWithValue("@password", userModel.Password);
                command.Parameters.AddWithValue("@name", userModel.Name);
                command.Parameters.AddWithValue("@lastname", userModel.Lastname);
                command.Parameters.AddWithValue("@email", userModel.Email);
                command.Parameters.AddWithValue("@edad", int.Parse(userModel.Edad));
                command.Parameters.AddWithValue("@peso", float.Parse(userModel.Peso));
                command.Parameters.AddWithValue("@altura", float.Parse(userModel.Altura));
                command.Parameters.AddWithValue("@imc", float.Parse(userModel.IMC));
                command.Parameters.AddWithValue("@ID_TipoMembresia", userModel.ID_TipoMembresia);
                command.Parameters.AddWithValue("@ID_TipoUsuario", userModel.ID_TipoUsuario);

                command.ExecuteNonQuery();
            }
            
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

        //agregacion de el metodo para actualiaar las oantallas
        public bool ActualizarUsuario(UserModel usuario)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = @"UPDATE [User] SET 
            [Name] = @Name,
            LastName = @LastName,
            Email = @Email,
            Edad = @Edad,
            Peso = @Peso,
            Altura = @Altura,
            IMC = @IMC
            WHERE ID = @ID";

                // Conversión segura de los datos string a tipos numéricos
                if (!int.TryParse(usuario.Edad, out int edad))
                    edad = 0;

                if (!decimal.TryParse(usuario.Peso, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal peso))
                    peso = 0;

                if (!decimal.TryParse(usuario.Altura, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal altura))
                    altura = 0;

                if (!decimal.TryParse(usuario.IMC, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out decimal imc))
                    imc = 0;

                // Asignación de parámetros
                command.Parameters.AddWithValue("@ID", Guid.Parse(usuario.Id));
                command.Parameters.AddWithValue("@Name", usuario.Name);
                command.Parameters.AddWithValue("@LastName", usuario.Lastname);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Edad", edad);
                command.Parameters.AddWithValue("@Peso", peso);
                command.Parameters.AddWithValue("@Altura", altura);
                command.Parameters.AddWithValue("@IMC", imc);

                return command.ExecuteNonQuery() > 0;
            }
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
                            ID_TipoMembresia = (int)(reader["ID_TipoMembresia"]),
                            ID_TipoUsuario = (int)reader["ID_TipoUsuario"]
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

        public void Registrarse_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }

        public bool EmailExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
