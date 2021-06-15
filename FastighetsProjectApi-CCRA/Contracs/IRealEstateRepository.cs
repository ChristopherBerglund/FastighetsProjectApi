using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Contracs
{
    public interface IRealEstateRepository
    {
        IEnumerable<RealEstate> GetAllRealEstate(bool trackChanges);
        RealEstate GetRealEstate(Guid ID, bool trackChanges);
        void CreateRealEstate(RealEstate realEstate);
        //void UpdateRealEstate(int ID);
        IEnumerable<RealEstate> GetByIds(IEnumerable<Guid> ids, bool trackChanges); //?
        void DeleteRealEstate(RealEstate realEstate);
    }
}
