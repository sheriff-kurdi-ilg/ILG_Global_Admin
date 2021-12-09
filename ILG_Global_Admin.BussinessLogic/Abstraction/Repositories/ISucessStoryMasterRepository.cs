using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface ISucessStoryMasterRepository
    {
        bool DeleteById(int Id);
        Task<bool> Insert(SucessStoryMaster SucessStoryMaster);
        Task<IEnumerable<SucessStoryMaster>> SelectAllAsync();
        Task<SucessStoryMaster> SelectByIdAsync(int id);
        Task<bool> Update(SucessStoryMaster SucessStoryMaster);
    }
}