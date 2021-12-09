using ILG_Global_Admin.BussinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.ViewModels
{
    public class SuccessStoriesVM
    {
        [Required]
        public int SuccessStoryId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PdfFileName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]

        [Display(Name = "Title")]
        public string TitleAr { get; set; }
        [Required]
        [Display(Name = "Summary")]
        public string SummaryAr { get; set; }
        [Required]
        public string LanguageCode { get; set; }

    }
}
