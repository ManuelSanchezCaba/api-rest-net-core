using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Models;
using Services.Common;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class UserRepo : IUser
    {
        private readonly AppDBContext _db;

        public UserRepo(AppDBContext db)
        {
            _db = db;
        }

        public async Task<object> getAllUsers()
        {
            try
            {
                var usuarios = await _db.Usuario.ToListAsync();
                return new { usuarios };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message.ToString() };
            }
        }

        public async Task<object> getUserByID(int id)
        {
            try
            {
                var usuario = await _db.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
                return new { usuario };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message.ToString() };
            }
        }

        public async Task<object> createUser(Usuario usuario)
        {
            try
            {
                usuario.Contrasena = CommonMethods.EncryptPassword(usuario.Contrasena);
                await _db.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Creado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message.ToString() };
            }
        }

        public async Task<object> updateUser(Usuario usuario)
        {
            try
            {
                _db.Update(usuario);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Actualizado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message.ToString() };
            }
        }

        public async Task<object> deleteUser(int id)
        {
            try
            {
                var usuario = await _db.Usuario.FirstOrDefaultAsync(x => x.Id == id);

                if (usuario == null) return new
                {
                    msg = "Usuario no Existe"
                };

                _db.Remove(usuario);
                await _db.SaveChangesAsync();

                return new
                {
                    msg = "Eliminado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message.ToString() };
            }
        }
    }
}
