using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Index(nameof(LanguageCode), Name = "IX_ImageDetails_LanguageCode")]
    [Index(nameof(OurServiceMasterId), Name = "IX_ImageDetails_OurServiceMasterID")]
    public partial class ImageDetail
    {
        [Key]
        [Column("ImageID")]
        public int ImageId { get; set; }

        [Key]
        public string LanguageCode { get; set; }

        public string Title { get; set; }

        public string AlternateText { get; set; }

        [Column("OurServiceMasterID")]
        public int? OurServiceMasterId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty(nameof(ImageMaster.ImageDetails))]
        public virtual ImageMaster Image { get; set; }


        [ForeignKey(nameof(LanguageCode))]
        [InverseProperty(nameof(Language.ImageDetails))]
        public virtual Language LanguageCodeNavigation { get; set; }


        [ForeignKey(nameof(OurServiceMasterId))]
        [InverseProperty("ImageDetails")]
        public virtual OurServiceMaster OurServiceMaster { get; set; }
    }
}
