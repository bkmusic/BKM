using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        public int MaCaSi { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string File { get; set; }

        public virtual ICollection<NhacCaNhan> NhacCaNhan { get; set; }
        public virtual KhuVuc KhuVuc { get; set; }
        public virtual TheLoai TheLoai { get; set; }        
    }

    public class BaiHatViewModel
    {
        public string MaBaiHat { get; set; }

        [Required]
        [Display(Name = "Tên bài hát")]
        public string TenBaiHat { get; set; }

        [Required]
        [Display(Name = "Tên thể loại")]
        public string MaTheLoai { get; set; }
        public IEnumerable<SelectListItem> TenTheLoai { get; set; }

        [Required]
        [Display(Name = "Tên Khu Vực")]
        public string MaKhuVuc { get; set; }
        public IEnumerable<SelectListItem> TenKhuVuc { get; set; }

        [Required]
        [Display(Name = "Tên Ca Sĩ")]
        public string MaCaSi { get; set; }
        public IEnumerable<SelectListItem> TenCaSi { get; set; }

        [Display(Name = "Tên Hình Ảnh")]
        public string HinhAnh { get; set; }

        [Display(Name = "Tên Mô Tả")]
        public string MoTa { get; set; }

        [Required]
        public string File { get; set; }
    }
}