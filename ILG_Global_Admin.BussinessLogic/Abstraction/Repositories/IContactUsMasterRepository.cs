using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IContactUsMasterRepository
    {
        bool DeleteByID(int Id);
        Task<bool> Insert(ContactInformationMaster ContactInformationMaster);
        Task<List<ContactInformationMaster>> SelectAllAsync();
        Task<ContactInformationMaster> SelectByIdAsync(int id);
        Task<bool> Update(ContactInformationMaster ContactInformationMaster);
    }
}