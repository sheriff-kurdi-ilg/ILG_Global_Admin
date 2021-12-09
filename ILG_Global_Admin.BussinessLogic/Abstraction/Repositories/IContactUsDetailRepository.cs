using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IContactUsDetailRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(ContactInformationDetail oContactInformationDetail);
        Task<List<ContactInformationDetail>> SelectAllAsync(string sLanguageCode);
        Task<ContactInformationDetail> SelectByIdAsync(int nID, string sLanguageCode);
        Task<bool> Update(ContactInformationDetail oContactInformationDetail);
    }
}