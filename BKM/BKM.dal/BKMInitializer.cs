using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BKM.Models;

namespace BKM.dal
{
    public class BKMInitializer : DropCreateDatabaseIfModelChanges<BKMContext>
    {
        protected override void Seed(BKMContext context)
        {
            var CaSies = new List<CaSi>
            {
                new CaSi{TenCaSi ="Default",   GioiTinh=Enumeration.GT.Unknown,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="181668.png"},
                new CaSi{TenCaSi ="Ariana Grande",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="a3-15460480392821349991640.jpg"},
                new CaSi{TenCaSi ="B Ray",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="9ce68f7d32102e37837bf3d87c82895c.jpg"},
                new CaSi{TenCaSi ="Black Pink",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="1747927_1.jpg"},
                new CaSi{TenCaSi ="Đạt G",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="Datg-0.jpg"},
                new CaSi{TenCaSi ="ERIK	1",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="1474010206663_600.jpg"},
                new CaSi{TenCaSi ="Hương Giang",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="16-1520665091402914466665.jpg"},
                new CaSi{TenCaSi ="Jennie",   GioiTinh=Enumeration.GT.Nu,  NgaySinh= DateTime.Today, MoTa="", HinhAnh="jennie-22.jpg"}
            };
            CaSies.ForEach(s => context.CaSies.Add(s));
            context.SaveChanges();

            var DetailBaiHats = new List<DetailBaiHat>
            {
                new DetailBaiHat{MaBaiHat = 0, TenBaiHat = "Default", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"}
            };
            DetailBaiHats.ForEach(s => context.DetailBaiHats.Add(s));
            context.SaveChanges();

            var TheLoais = new List<TheLoai>
            {
                new TheLoai{TenTheLoai="Classical"},
                new TheLoai{TenTheLoai="Country"},
                new TheLoai{TenTheLoai="Electronic"},
                new TheLoai{TenTheLoai="Indie"},
                new TheLoai{TenTheLoai="Jazz"},
                new TheLoai{TenTheLoai="Pop"},
                new TheLoai{TenTheLoai="R&B"},
                new TheLoai{TenTheLoai="Rock"},
            };
            TheLoais.ForEach(s => context.TheLoais.Add(s));
            context.SaveChanges();

            var BaiHats = new List<BaiHat>
            {
                new BaiHat{TenBaiHat="Anh Đang Ở Đâu Đấy Anh", MaTheLoai=1, MaKhuVuc= 1, File="Anh - Dang - O - Dau - Day - Anh - Huong - Giang.mp3" },
                new BaiHat{TenBaiHat="Thank U, Next", MaTheLoai=1, MaKhuVuc= 2, File="Thank U_ Next - Ariana Grande[128kbps_MP3].mp3" },
                new BaiHat{TenBaiHat="Ve", MaTheLoai= 1  , MaKhuVuc=  1  , File=" Ve-Dat-G-DuUyen-BeeBB.mp3" },
                new BaiHat{TenBaiHat="Cham Day Noi Dau",  MaTheLoai=  1, MaKhuVuc =  1 , File="Cham -Day-Noi-Dau-ERIK.mp3"} ,
                new BaiHat{TenBaiHat="Mình Chia Tay Đi" , MaTheLoai=  1,  MaKhuVuc = 1, File="Minh -Chia-Tay-Di-ERIK.mp3"},
                new BaiHat{TenBaiHat="SoLo" ,  MaTheLoai= 1, MaKhuVuc =3, File = "Solo - Jennie [128kbps_MP3].mp3" }
            };
            BaiHats.ForEach(s => context.BaiHats.Add(s));
            context.SaveChanges();

            var KhuVucs = new List<KhuVuc>
            {
                 new KhuVuc{TenKhuVuc="Viet Nam"},
                 new KhuVuc{TenKhuVuc="Au My"},
                 new KhuVuc{TenKhuVuc="Han Quoc"}
            };
            KhuVucs.ForEach(s => context.KhuVucs.Add(s));
            context.SaveChanges();

            var NguoiDungs = new List<NguoiDung>
            {
            };
            NguoiDungs.ForEach(s => context.NguoiDungs.Add(s));
            context.SaveChanges();

            var NhacCaNhans = new List<NhacCaNhan>
            {
            };
            NhacCaNhans.ForEach(s => context.NhacCaNhans.Add(s));
            context.SaveChanges();
        }
    }
}