using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static BKM.Models.Enumeration;

namespace BKM.Models
{
    [Table("NhacSi")]
    public class NhacSi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaNhacSi { get; set; }
        [Display(Name = "Tên nhạc sĩ")]
        public string TenNhacSi { get; set; }
        [Display(Name = "Giới tính")]
        public GT GioiTinh { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        public virtual ICollection<DetailBaiHat> DetailBaiHat { get; set; }
    }
}