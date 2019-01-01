using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static BKM.Models.Enumeration;

namespace BKM.Models
{
    [Table("CaSi")]
    public class CaSi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaCaSi { get; set; }

        [Display(Name = "Tên ca sĩ")]
        public string TenCaSi { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
    }
}