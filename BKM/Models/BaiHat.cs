using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BKM.Models
{
    [Table("BaiHat")]
    public class BaiHat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaBaiHat { get; set; }
        public string TenBaiHat { get; set; }
        public int MaCaSi { get; set; }
        public string MaKhuVuc { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string file { get; set; }

        public virtual ICollection<CaSi> CaSi { get; set; }
        public virtual ICollection<KhuVuc> KhuVuc { get; set; }
    }
}