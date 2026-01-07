using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekatv2.Models;

namespace Projekatv2.Services
{
    public interface IService
    {
        Task<bool> TryLogin(string email, string password);
        User GetUserById(int id);
    }
}
