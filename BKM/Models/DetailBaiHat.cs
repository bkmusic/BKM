using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NgayDang { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
        public virtual NhacSi NhacSi { get; set; }
        public virtual CaSi CaSi { get; set; }
    }

    public class DetailBaiHatViewModel
    {
        public string MaBaiHat { get; set; }

        [Required]
        public string TenBaiHat { get; set; }

        [Required]
        public string MaCaSi { get; set; }
        public IEnumerable<SelectListItem> TenCaSi { get; set; }

        [Required]
        public string MaNhacSi { get; set; }
        public IEnumerable<SelectListItem> TenNhacSi { get; set; }

        [Required]
        public string MoTa { get; set; }

        [Required]
        public string HinhAnh { get; set; }
    }
}