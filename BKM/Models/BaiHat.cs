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
        public string File { get; set; }

        public virtual ICollection<NhacCaNhan> NhacCaNhan { get; set; }
        public virtual DetailBaiHat DetailBaiHat { get; set; }
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
        public string MaTheLoai { get; set; }
        public IEnumerable<SelectListItem> TenTheLoai { get; set; }

        [Required]
        public string MaKhuVuc { get; set; }
        public IEnumerable<SelectListItem> TenKhuVuc { get; set; }

        [Required]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [Required]
        public string File { get; set; }
    }
}