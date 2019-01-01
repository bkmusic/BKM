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
        public int MaCaSi { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
        public virtual CaSi CaSi { get; set; }
    }
    public class DetailBaiHatViewModel
    {
        [Required]
        [Display(Name = "Tên Ca Sĩ")]
        public string MaCaSi { get; set; }
        public IEnumerable<SelectListItem> TenCaSi { get; set; }

        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string HinhAnh { get; set; }
    }
}