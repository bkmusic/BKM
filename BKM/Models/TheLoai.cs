using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BKM.Models
{
    [Table("TheLoai")]
    public class TheLoai
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
    }
}