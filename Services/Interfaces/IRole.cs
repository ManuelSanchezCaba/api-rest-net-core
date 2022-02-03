using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRole
    {
        public Task<object> getAllRoles();
        public Task<object> getRoleByID(int id);
        public Task<object> createRole(Role role);
        public Task<object> updateRole(Role role);
        public Task<object> deleteRole(int id);
    }
}
