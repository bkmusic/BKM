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
        public int MaTheLoai { get; set; }
        public int MaKhuVuc { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string File { get; set; }

        public virtual ICollection<KhuVuc> KhuVuc { get; set; }
        public virtual ICollection<TheLoai> TheLoai { get; set; }
        public virtual ICollection<DetailBaiHat> DetailBaiHat { get; set; }
    }
}