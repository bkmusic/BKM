using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BKM.Models
{
    [Table("DetailBaiHat")]
    public class DetailBaiHat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaBaiHat { get; set; }
        public string TenBaiHat { get; set; }
        public int MaTheLoai { get; set; }
        public int MaKhuVuc { get; set; }
        public int MaCaSi { get; set; }
        public int MaNhacSi { get; set; }
        public string NguoiDang { get; set; }
        public DateTime NgayDang { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
        public virtual NhacSi NhacSi { get; set; }
        public virtual CaSi CaSi { get; set; }
    }
}