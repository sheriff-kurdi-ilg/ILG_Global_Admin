using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class HtmlContentVM
    {
        [Required]
        public int HtmlContenID { get; set; }

        #region Master
        public bool IsEnabled { get; set; }
        public bool CanBeDeletedByUser { get; set; }

        #endregion

        #region Detail
        // [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        // [Required]
        [MaxLength(80)]
        public string TitleAr { get; set; }
        [MaxLength(80)]
        [Required]
        public string SubTitle { get; set; }
        [MaxLength(80)]
        [Required]
        public string SubTitleAr { get; set; }
        [Required]
        [MaxLength(500)]
        public string Summary { get; set; }
        [Required]
        [MaxLength(500)]
        public string SummaryAr { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        #endregion
    }
}
