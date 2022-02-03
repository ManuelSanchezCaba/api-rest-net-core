using Microsoft.EntityFrameworkCore;
using Models.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class AuthRepo : IAuth
    {
        private readonly AppDBContext _db;

        public AuthRepo(AppDBContext db)
        {
            _db = db;
        }

        public async Task<object> getToken(string username, string password)
        {
            try
            {
                var usuario = await _db.Usuario
                    .Where(x => x.Usuario_Nombre == username && x.Contrasena == password)
                    .FirstOrDefaultAsync();

                if (usuario == null) return new { msg = "No token" };

                return new { token = "token" };
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
