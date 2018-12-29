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
        public string TenNhacSi { get; set; }
        public GT GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<DetailBaiHat> DetailBaiHat { get; set; }
    }
}