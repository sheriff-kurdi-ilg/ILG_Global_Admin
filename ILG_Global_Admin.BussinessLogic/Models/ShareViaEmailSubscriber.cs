using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ILG_Global_Admin.BussinessLogic.Models
{
    [Table("ShareViaEmailSubscriber")]
    public partial class ShareViaEmailSubscriber
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        public string EmailAddress { get; set; }
    }
}
