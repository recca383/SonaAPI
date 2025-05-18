using Microsoft.EntityFrameworkCore;
using SonaAPI.Models;

namespace SonaAPI.Data
{
    public class MBTIDataContext : DbContext
    {
        public MBTIDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MBTIFromDataSet> MBTIDataset { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MBTIFromDataSet>().ToTable("MBTI_DataSet");
        }
    }
}
