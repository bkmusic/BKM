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
            var DetailBaiHats = new List<DetailBaiHat>
            {
            };

            DetailBaiHats.ForEach(s => context.DetailBaiHats.Add(s));
            context.SaveChanges();
            var NhacSies = new List<NhacSi>
            {

            };
            NhacSies.ForEach(s => context.NhacSies.Add(s));
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
            };

            BaiHats.ForEach(s => context.BaiHats.Add(s));
            context.SaveChanges();
            var CaSies = new List<CaSi>
            {

            };
            CaSies.ForEach(s => context.CaSies.Add(s));
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
            { };
            NhacCaNhans.ForEach(s => context.NhacCaNhans.Add(s));
            context.SaveChanges();
        }

    }
}