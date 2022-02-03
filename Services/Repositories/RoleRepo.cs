using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class RoleRepo : IRole
    {
        private readonly AppDBContext _db;

        public RoleRepo(AppDBContext db)
        {
            _db = db;
        }

        public async Task<object> getAllRoles()
        {
            try
            {
                var roles = await _db.Role.ToListAsync();
                return new { roles };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> getRoleByID(int id)
        {
            try
            {
                var role = await _db.Role.Where(x => x.Id == id).FirstOrDefaultAsync();
                return new { role };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> createRole(Role role)
        {
            try
            {
                await _db.AddAsync(role);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Creado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> updateRole(Role role)
        {
            try
            {
                _db.Update(role);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Actualizado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }

        public async Task<object> deleteRole(int id)
        {
            try
            {
                var role = await _db.Role.FirstOrDefaultAsync(x => x.Id == id);

                if (role == null) return new
                {
                    msg = "Role no Existe"
                };

                _db.Remove(role);
                await _db.SaveChangesAsync();
                return new
                {
                    msg = "Eliminado Correctamente"
                };
            }
            catch (Exception ex)
            {
                return new { msg = ex.Message };
            }
        }
    }
}
