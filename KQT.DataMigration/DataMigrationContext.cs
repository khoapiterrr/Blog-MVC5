using KQT.Entity;
using System.Data.Entity;

namespace KQT.DataMigration

{
    public class DataMigrationContext : DbContext
    {
        public DataMigrationContext()
            : base("name=MigrationContext")
        {
        }

        public DbSet<NewsEntity> NewsEntities { get; set; }
        public DbSet<ChucNang> ChucNangs { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<ContactEntity> ContactEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}