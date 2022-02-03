using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUser
    {
        public Task<object> getAllUsers();
        public Task<object> getUserByID(int id);
        public Task<object> createUser(Usuario usuario);
        public Task<object> updateUser(Usuario usuario);
        public Task<object> deleteUser(int id);
    }
}
