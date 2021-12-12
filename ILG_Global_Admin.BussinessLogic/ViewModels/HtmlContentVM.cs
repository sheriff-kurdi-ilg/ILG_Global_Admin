using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global_Admin.BussinessLogic.ViewModels
{
    public class HtmlContentVM
    {
        [Required]
        public int HtmlContenID { get; set; }

        #region Master
        public bool IsEnabled { get; set; }
        public bool CanBeDeletedByUser { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        #endregion

        #region Detail
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string SubTitle { get; set; }
        public string SubTitleAr { get; set; }
        public string Summary { get; set; }
        public string SummaryAr { get; set; }
        public string LanguageCode { get; set; }
        #endregion
    }
}
