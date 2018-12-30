using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BKM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace BKM.dal
{
    public class BKMContext : DbContext
    {
        public BKMContext() : base("BKMContext")
        {
        }

        public DbSet<BaiHat> BaiHats { get; set; }
        public DbSet<CaSi> CaSies { get; set; }
        public DbSet<KhuVuc> KhuVucs { get; set; }
        public DbSet<DetailBaiHat> DetailBaiHats { get; set; }
        public DbSet<NhacSi> NhacSies { get; set; }
        public DbSet<TheLoai> TheLoais { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<NhacCaNhan> NhacCaNhans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}