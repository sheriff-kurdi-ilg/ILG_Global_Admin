using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface INewsLetterSubscribeRepository
    {
        Task<bool> DeleteByID(int nID);
        Task<bool> Insert(NewsLetterSubscribe oNewsLetterSubscribe);
        Task<IEnumerable<NewsLetterSubscribe>> SelectAllAsync();
        Task<NewsLetterSubscribe> SelectByIdAsync(int nID);
        Task<bool> Update(NewsLetterSubscribe oNewsLetterSubscribe);
    }
}