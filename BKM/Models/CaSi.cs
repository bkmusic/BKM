using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BKM.Models
{
    [Table("CaSi")]
    public class CaSi
    {
        public enum GT
        {
            Nam, Nu
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaCaSi { get; set; }
        public string TenCaSi { get; set; }
        public GT GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        
        public virtual BaiHat BaiHat { get; set; }
    }
}