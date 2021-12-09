using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    public partial class OurServiceMaster
    {
        public OurServiceMaster()
        {
            ImageDetails = new HashSet<ImageDetail>();
            ImageMasterImageMasters = new HashSet<ImageMaster>();
            ImageMasterOurServiceMasters = new HashSet<ImageMaster>();
            OurServiceDetails = new HashSet<OurServiceDetail>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public bool IsEnabled { get; set; }
        public int ImageMastersId { get; set; }

        [InverseProperty(nameof(ImageDetail.OurServiceMaster))]
        public virtual ICollection<ImageDetail> ImageDetails { get; set; }


        [InverseProperty(nameof(ImageMaster.ImageMasters))]
        public virtual ICollection<ImageMaster> ImageMasterImageMasters { get; set; }


        [InverseProperty(nameof(ImageMaster.OurServiceMaster))]
        public virtual ICollection<ImageMaster> ImageMasterOurServiceMasters { get; set; }


        [InverseProperty(nameof(OurServiceDetail.OurService))]
        public virtual ICollection<OurServiceDetail> OurServiceDetails { get; set; }

        public string ImageURL { get; set; }
    }
}
