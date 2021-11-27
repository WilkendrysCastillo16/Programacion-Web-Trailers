using API.Tools;
using API_Trailler.Data;
using API_Trailler.Models;
using API_Trailler.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API_Trailler.Services
{
    public class LoginAdminServices : ILoginAdminServices
    {
        private readonly dbTraillerContext _dbTraillerContext;
        private readonly IConfiguration _configuration;
        public LoginAdminServices(dbTraillerContext dbTraillerContext, IConfiguration configuration)
        {
            _dbTraillerContext = dbTraillerContext;
            _configuration = configuration;
        }

        public async Task<bool> Existe(string email)
        {
            if (await _dbTraillerContext.LoginAdmins.AnyAsync(x =>
                                        x.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task<string> Login(string email, string pass)
        {
            var user = await _dbTraillerContext.LoginAdmins.FirstOrDefaultAsync(
                    LA => LA.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                return "No Encontrado";
            }
            else if (!VerificarPassword(email, pass))
            {
                return "Pass Incorrecta";
            }
            else
            {
                return GetToken(user);
            }
        }
        public bool VerificarPassword(string email, string pass)
        {
            var passEncrypt = Encrypt.GetSHA256(pass);
            var Coincide = _dbTraillerContext.LoginAdmins.Where(LA => LA.Email == email && 
                                                                      LA.Pass == passEncrypt).SingleOrDefault();

            if(Coincide == null) { return false; }
            else { return true; }
        }

        public async Task<string> Registrar(LoginAdmin loginAdmin, string pass)
        {
            try
            {
                if (await Existe(loginAdmin.Email))
                {
                    return "existe";
                }

                loginAdmin.Pass = Encrypt.GetSHA256(pass);

                await _dbTraillerContext.LoginAdmins.AddAsync(loginAdmin);
                await _dbTraillerContext.SaveChangesAsync();
                return "Correcto";
            }
            catch (Exception)
            {
                return "error";
                
            }
        }

        private string GetToken(LoginAdmin loginAdmin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginAdmin.Id.ToString()),
                new Claim(ClaimTypes.Name, loginAdmin.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                                        GetBytes(_configuration.GetSection("AppSettings:Clave").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
