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
            };
            caSies.ForEach(s => context.CaSies.Add(s));
            context.SaveChanges();

            var TheLoais = new List<TheLoai>
            {
            };
            TheLoais.ForEach(s => context.TheLoais.Add(s));
            context.SaveChanges();

            var KhuVucs = new List<KhuVuc>
            {
            };
            KhuVucs.ForEach(s => context.KhuVucs.Add(s));
            context.SaveChanges();

            var BaiHats = new List<BaiHat>
            {            
            };
            BaiHats.ForEach(s => context.BaiHats.Add(s));
            context.SaveChanges();

            var NguoiDungs = new List<NguoiDung>
            {
            };

            var NhacCaNhans = new List<NhacCaNhan>
            {
            };
            NhacCaNhans.ForEach(s => context.NhacCaNhans.Add(s));
            context.SaveChanges();
        }
    }
}