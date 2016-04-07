using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class PosContext:DbContext
    {
        public PosContext() : base("PosContext")
        {

        }
        public DbSet<FinancialYear> FinancialYears { set; get; }
        public DbSet<Shop> Shops { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<Measurement> Measurements { set; get; }
        public DbSet<Product> Products { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}
