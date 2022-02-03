using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class AuthRepo : IAuth
    {
        private readonly AppDBContext _db;
        private readonly IConfiguration Configuration;

        public AuthRepo(AppDBContext db, IConfiguration configuration)
        {
            _db = db;
            Configuration = configuration;
        }

        public async Task<object> getToken(string username, string password)
        {
            try
            {
                var usuario = await _db.Usuario
                    .Where(x => x.Usuario_Nombre == username && x.Contrasena == password)
                    .FirstOrDefaultAsync();

                if (usuario == null) return new { msg = "No token" };

                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = Encoding.UTF8.GetBytes(Configuration.GetSection("SECRET").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(24),
                    SigningCredentials = 
                    new SigningCredentials(
                            new SymmetricSecurityKey(secret),
                            SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new { token = tokenHandler.WriteToken(token) };
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
