using FastighetsProjectApi_CCRA.Contracs;
using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext Context)
            : base(Context)
        {

        }

        public IEnumerable<User> GetAllUser(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(c => c.UserName)
                    .ToList();
        }

        public User GetUser(Guid inId, bool trackChanges) =>
            FindByCondition(c => c.ID.Equals(inId), trackChanges)
            .SingleOrDefault();

        void IUserRepository.CreateUser(User user) => Create(user);

        void IUserRepository.DeleteUser(User user)
        {
            Delete(user);
        }

        IEnumerable<User> IUserRepository.GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.ID), trackChanges) //GUID?
                .ToList();
    }
}
