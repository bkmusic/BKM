using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BKM.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BKM.dal
{
    public class BKMInitializer : DropCreateDatabaseIfModelChanges<BKMContext>
    {
        protected override void Seed(BKMContext context)
        {
            var caSies = new List<CaSi>
            {
                new CaSi{TenCaSi ="Default", MoTa ="", HinhAnh="181668.png"},
                new CaSi{TenCaSi ="Ariana Grande", MoTa ="", HinhAnh="a3-15460480392821349991640.jpg"},
                new CaSi{TenCaSi ="B Ray", MoTa ="",  HinhAnh="9ce68f7d32102e37837bf3d87c82895c.jpg"},
                new CaSi{TenCaSi ="Black Pink",MoTa ="",  HinhAnh="1747927_1.jpg"},
                new CaSi{TenCaSi ="Đạt G",MoTa ="",  HinhAnh="Datg-0.jpg"},
                new CaSi{TenCaSi ="ERIK	1",MoTa ="",  HinhAnh="1474010206663_600.jpg"},
                new CaSi{TenCaSi ="Hương Giang",MoTa ="", HinhAnh="16-1520665091402914466665.jpg"},
                new CaSi{TenCaSi ="Jennie", MoTa ="",  HinhAnh="jennie-22.jpg"}
            };
            caSies.ForEach(s => context.CaSies.Add(s));
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

            var KhuVucs = new List<KhuVuc>
            {
                 new KhuVuc{TenKhuVuc="Viet Nam"},
                 new KhuVuc{TenKhuVuc="Au My"},
                 new KhuVuc{TenKhuVuc="Han Quoc"}
            };
            KhuVucs.ForEach(s => context.KhuVucs.Add(s));
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

            var DetailBaiHats = new List<DetailBaiHat>
            {
                new DetailBaiHat{MaBaiHat = 1, TenBaiHat = "Anh Đang Ở Đâu Đấy Anh", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"},
                new DetailBaiHat{MaBaiHat = 2, TenBaiHat = "Thank U, Next", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"},
                new DetailBaiHat{MaBaiHat = 3, TenBaiHat = "Ve", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"},
                new DetailBaiHat{MaBaiHat = 4, TenBaiHat = "Cham Day Noi Dau", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"},
                new DetailBaiHat{MaBaiHat = 5, TenBaiHat = "Mình Chia Tay Đi", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"},
                new DetailBaiHat{MaBaiHat = 6, TenBaiHat = "SoLo", MaCaSi = 1, MoTa = "", HinhAnh = "img.png"}

            };
            DetailBaiHats.ForEach(s => context.DetailBaiHats.Add(s));
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