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
        public int ID { get; set; }
        public int MaBaiHat { get; set; }
        public string TenBaiHat { get; set; }
        public int MaCaSi { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<NhacCaNhan> NhacCaNhan { get; set; }
        public virtual BaiHat BaiHat { get; set; }
        public virtual CaSi CaSi { get; set; }
    }
    public class DetailBaiHatViewModel
    {
        public string MaBaiHat { get; set; }

        [Display(Name = "Tên bài hát")]
        public string TenBaiHat { get; set; }

        [Required]
        [Display(Name = "Tên thể loại")]
        public string MaCaSi { get; set; }
        public IEnumerable<SelectListItem> TenCaSi { get; set; }

        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
    }
}