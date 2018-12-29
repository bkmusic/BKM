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
        public string TenCaSi { get; set; }
        public GT GioiTinh { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public virtual ICollection<DetailBaiHat> DetailBaiHat { get; set; }
    }
}