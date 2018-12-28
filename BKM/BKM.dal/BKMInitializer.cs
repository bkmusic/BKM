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
            };

            KhuVucs.ForEach(s => context.KhuVucs.Add(s));
            context.SaveChanges();
        }
    }
}