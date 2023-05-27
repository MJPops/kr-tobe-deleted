using KR.Domains;
using KR.Domains.Model;
using Microsoft.EntityFrameworkCore;

namespace KR.Api
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProcedureType> ProcedureTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureType>().ToTable("procedure_type");
            modelBuilder.Entity<ProcedureType>().Property(e => e.Id).HasColumnName("id");
            modelBuilder.Entity<ProcedureType>().Property(e => e.Name).HasColumnName("name");
            modelBuilder.Entity<ProcedureType>().Property(e => e.Description).HasColumnName("description");
            modelBuilder.Entity<ProcedureType>().Property(e => e.ApproximateTime).HasColumnName("approximate_time");
        }
    }
}
