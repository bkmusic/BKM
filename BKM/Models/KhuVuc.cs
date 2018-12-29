using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BKM.Models
{
    [Table("KhuVuc")]
    public class KhuVuc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }

        public virtual ICollection<BaiHat> BaiHat { get; set; }
    }
}