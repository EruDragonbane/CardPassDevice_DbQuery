using System.Data.Entity;
using DbDQ.Entity.Entities;

namespace DbDQ.Entity
{
    public class DbDQContext : DbContext
    {
        public DbDQContext() : base(nameOrConnectionString: "Default") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            // Due to npgsql, s is added to the end of table names.
            // To prevent this, the table names are customized with this structure.
            modelBuilder.Entity<Tablo1>().ToTable("Tablo1");
            modelBuilder.Entity<Tablo2>().ToTable("Tablo2");
            modelBuilder.Entity<Tablo3>().ToTable("Tablo3");
            modelBuilder.Entity<Tablo4>().ToTable("Tablo4");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tablo4> Tablo4 { get; set; }
        public DbSet<Tablo3> Tablo3 { get; set; }
        public DbSet<Tablo2> Tablo2 { get; set; }
        public DbSet<Tablo1> Tablo1 { get; set; }
    }
}
