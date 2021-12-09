using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Index(nameof(HtmlContentMasterId), Name = "IX_ImageMasters_HtmlContentMasterID")]
    [Index(nameof(ImageMastersId), Name = "IX_ImageMasters_ImageMastersId")]
    [Index(nameof(OurServiceMasterId), Name = "IX_ImageMasters_OurServiceMasterID")]
    public partial class ImageMaster
    {
        public ImageMaster()
        {
            ImageDetails = new HashSet<ImageDetail>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("HtmlContentMasterID")]
        public int? HtmlContentMasterId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsEnabled { get; set; }
        [Column("OurServiceMasterID")]
        public int? OurServiceMasterId { get; set; }
        public string Name { get; set; }
        public int? ImageMastersId { get; set; }

        [ForeignKey(nameof(HtmlContentMasterId))]
        [InverseProperty("ImageMasters")]
        public virtual HtmlContentMaster HtmlContentMaster { get; set; }
        [ForeignKey(nameof(ImageMastersId))]
        [InverseProperty("ImageMasterImageMasters")]
        public virtual OurServiceMaster ImageMasters { get; set; }
        [ForeignKey(nameof(OurServiceMasterId))]
        [InverseProperty("ImageMasterOurServiceMasters")]
        public virtual OurServiceMaster OurServiceMaster { get; set; }
        [InverseProperty(nameof(ImageDetail.Image))]
        public virtual ICollection<ImageDetail> ImageDetails { get; set; }
    }
}
