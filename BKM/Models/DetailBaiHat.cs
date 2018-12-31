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
        [Key]
        public int MaBaiHat { get; set; }
        public string TenBaiHat { get; set; }
        public int MaCaSi { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
        public virtual CaSi CaSi { get; set; }
    }

    public class DetailBaiHatViewModel
    {
        public string MaBaiHat { get; set; }

        [Required]
        [Display(Name = "Tên bài hát")]
        public string TenBaiHat { get; set; }

        [Required]
        public string MaTheLoai { get; set; }
        public IEnumerable<SelectListItem> TenTheLoai { get; set; }

        [Required]
        public string MaKhuVuc { get; set; }
        public IEnumerable<SelectListItem> TenKhuVuc { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
    }

}