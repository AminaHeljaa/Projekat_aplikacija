
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekatv2.Models;

namespace Projekatv2.Services
{
    public class Service:IService
    {
        private readonly Dictionary<string, User> Users = new();

        private void AddUser(User user) => Users.Add(user.Email, user);

        public Service()
        {
            AddUser(new User { Id = 1, FullName = "Hana Karzic", Email = "hanakarzic@size.ba", Password = "12345678",ProfileImage="profil.png" });
            AddUser(new User { Id = 2, FullName = "Amina Helja", Email = "aminahelja@size.ba", Password = "87654321",ProfileImage="amina.png" });
        }

        public Task<bool> TryLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return Task.FromResult(false);

            bool result = Users.TryGetValue(email, out User user) && user.Password.Equals(password);

            if (result) Preferences.Set("userId", user.Id.ToString());
            return Task.FromResult(result);
        }


        /*za ime na profile*/
        public User GetUserById(int id)
        {
            return Users.Values.FirstOrDefault(u => u.Id == id);
        }
    }
}
