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
                            IMC = reader["IMC"].ToString()
                        };
                    }
                }
            }

            return user;
        }

    }
}
