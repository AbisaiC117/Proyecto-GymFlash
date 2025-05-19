using System.Net;
using System.Windows;

namespace GymFlash.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        void UpdateMembership(string userId, int membershipType);
        void Registrarse_Click(object sender, RoutedEventArgs e);
        bool UserExists(string username);
        bool EmailExists(string email);
    }
}
