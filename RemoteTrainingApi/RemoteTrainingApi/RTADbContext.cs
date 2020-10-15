using Microsoft.EntityFrameworkCore;

namespace RemoteTrainingApi
{
    public class RTADbContext : DbContext
    {
        public RTADbContext()
        {

        }

        public RTADbContext(DbContextOptions<RTADbContext> options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=RTADbContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
