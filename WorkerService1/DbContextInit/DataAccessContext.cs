
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
    }
}
