using FastighetsProjectApi_CCRA.Contracs;
using FastighetsProjectApi_CCRA.HelpClasses;
using FastighetsProjectApi_CCRA.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Repository
{
    public class RealEstateRepository : RepositoryBase<RealEstate>, IRealEstateRepository
    {
        public RealEstateRepository(DbContext Context)
            : base(Context)
        {

        }

        public IEnumerable<RealEstate> GetAllRealEstate(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(c => c.ConstructionYear)
                    .ToList();
        }

        public RealEstate GetRealEstate(Guid inId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(inId), trackChanges)
            .SingleOrDefault();

        void IRealEstateRepository.CreateRealEstate(RealEstate realEstate) => Create(realEstate);

        void IRealEstateRepository.DeleteRealEstate(RealEstate realEstate)
        {
            Delete(realEstate);
        }

        IEnumerable<RealEstate> IRealEstateRepository.GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges) //GUID?
                .ToList();

        public IEnumerable<RealEstate> GetRealEstateST(SkipTakeParameters skipTakeParameters)
        {
     
            return _dbContext.RealEstates.Include(x => x.Comments).Skip(skipTakeParameters.skip).Take(skipTakeParameters.take).OrderByDescending(c => c.CreatedOn).ToList();
        }
    }
}

