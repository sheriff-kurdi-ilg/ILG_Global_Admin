using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Index(nameof(LanguageCode), Name = "IX_HtmlContentDetails_LanguageCode")]
    public partial class HtmlContentDetail
    {
        [Key]
        [Column("HtmlContentID")]
        public int HtmlContentId { get; set; }
        [Key]
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(HtmlContentId))]
        [InverseProperty(nameof(HtmlContentMaster.HtmlContentDetails))]
        public virtual HtmlContentMaster HtmlContent { get; set; }
        [ForeignKey(nameof(LanguageCode))]
        [InverseProperty(nameof(Language.HtmlContentDetails))]
        public virtual Language LanguageCodeNavigation { get; set; }
    }
}
