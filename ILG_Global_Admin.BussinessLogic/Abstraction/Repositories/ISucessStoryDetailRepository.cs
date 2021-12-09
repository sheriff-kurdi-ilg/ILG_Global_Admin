using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface ISucessStoryDetailRepository
    {
        Task<bool> Delete(SucessStoryDetail oSucessStoryDetail);
        Task<bool> Insert(SucessStoryDetail oSucessStoryDetail);
        Task<List<SucessStoryDetail>> SelectAllAsync(string languageCode);
        Task<List<SucessStoryDetail>> SelectByIdAsync(int nID);
        Task<bool> AddRange(List<SucessStoryDetail> sucessStoryDetailsEntity);
        Task<SucessStoryDetail> SelectByIdLanguageCodeAsync(int nID, string sLanguageCode);
        Task<bool> Update(SucessStoryDetail oSucessStoryDetail);
        Task<bool> UpdateRange(List<SucessStoryDetail> sucessStoryDetailsEntity);
    }
}