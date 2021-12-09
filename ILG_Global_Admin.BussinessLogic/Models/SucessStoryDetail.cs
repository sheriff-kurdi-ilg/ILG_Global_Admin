using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Index(nameof(LanguageCode), Name = "IX_SucessStoryDetails_LanguageCode")]
    public partial class SucessStoryDetail
    {
        [Key]
        [Column("SucessStoryID")]
        public int SucessStoryId { get; set; }
        [Key]
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        [ForeignKey(nameof(LanguageCode))]
        [InverseProperty(nameof(Language.SucessStoryDetails))]
        public virtual Language LanguageCodeNavigation { get; set; }
        [ForeignKey(nameof(SucessStoryId))]
        [InverseProperty(nameof(SucessStoryMaster.SucessStoryDetails))]
        public virtual SucessStoryMaster SucessStory { get; set; }
    }
}
