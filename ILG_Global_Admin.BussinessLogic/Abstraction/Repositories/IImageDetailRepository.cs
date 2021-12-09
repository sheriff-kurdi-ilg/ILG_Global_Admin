
using ILG_Global_Admin.BussinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.Abstraction.Repositories
{
    public interface IImageDetailRepository
    {
        Task<ImageDetail> SelectById(string languageCode, int imageMasterId);
        Task<List<ImageDetail>> SelectAll(string languageCode);
        Task UpdateById(ImageDetail entity);
        Task Insert(ImageDetail entity);
        Task DeleteById(int Id);
        Task SaveImageDetail(ImageDetail entity);
    }
}
