using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static BKM.Models.Enumeration;


namespace BKM.Models
{

    [Table("NguoiDung")]
    public class NguoiDung
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaNguoiDung { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên hiển thị")]
        public string TenHienThi { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Giới tính")]
        public GT GioiTinh { get; set; }

        public string Mota { get; set; }

        public string HinhAnh { get; set; }


    }

}
