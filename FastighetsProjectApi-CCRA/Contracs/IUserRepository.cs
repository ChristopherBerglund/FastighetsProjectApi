using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Contracs
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser(bool trackChanges);
        User GetUser(Guid UserId, bool trackChanges);
        void CreateUser(User user);
        IEnumerable<User> GetByIds(IEnumerable<Guid> ids, bool trackChanges); //?
        void DeleteUser(User user);
    }
}
