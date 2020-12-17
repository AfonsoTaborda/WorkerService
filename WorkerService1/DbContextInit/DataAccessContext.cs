
using Microsoft.EntityFrameworkCore;
using WorkerService1.Models;

namespace WorkerService1.DbContextInit
{
    class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options)
           : base(options)
        {
        }
        public DbSet<ValuesModel> ValuesModels { get; set; }
        public DbSet<MicrocontrollerModel> MicrocontrollerModels { get; set; }
        public DbSet<NotificationModel> NotificationModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValuesModel>()
                .HasOne<MicrocontrollerModel>()
                .WithMany()
                .HasForeignKey(p => p.MicrocontrollerID);

            modelBuilder.Entity<NotificationModel>()
                .HasOne<MicrocontrollerModel>()
                .WithMany()
                .HasForeignKey(p => p.MicrocontrollerID);
        }
    }
}
