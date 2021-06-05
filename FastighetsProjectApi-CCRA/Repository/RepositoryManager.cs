using FastighetsProjectApi_CCRA.Contracs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Repository
{


    public class RepositoryManager : IRepositoryManager
    {
        private DbContext _dbContext;

        private IRealEstateRepository _realEstateRepository;
        private ICommentRepository _commentRepository;
        private IUserRepository _userRepository;


        public RepositoryManager(DbContext Context)
        {
            _dbContext = Context;
        }

        public IRealEstateRepository realEstate
        {
            get
            {
                if (_realEstateRepository == null)
                {
                    _realEstateRepository = new RealEstateRepository(_dbContext);
                }
                return _realEstateRepository;
            }
        }
        public IUserRepository user
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }
        public ICommentRepository comment
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_dbContext);
                }
                return _commentRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

