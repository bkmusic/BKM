 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace BKM.Models
{
    [Table("NhacCaNhan")]
    public class NhacCaNhan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int MaBaiHat { get; set; }
        public int MaNguoiDung { get; set; }

        public virtual BaiHat BaiHat { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}