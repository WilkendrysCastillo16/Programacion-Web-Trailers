using API_Trailler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Trailler.Services.Interface
{
    public interface ILoginAdminServices
    {
        Task<string> Registrar(LoginAdmin loginAdmin, string pass);
        Task<string> Login(string email, string pass);
        Task<bool> Existe(string email);
    }
}
