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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}