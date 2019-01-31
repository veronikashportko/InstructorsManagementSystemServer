using Microsoft.EntityFrameworkCore;

namespace InstructorsManagementSystemService.Models.Contexts
{
    public class InstructorsContext: DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }

        public InstructorsContext()
        {
            Database.EnsureCreated();
        }

        public InstructorsContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>(entity =>
            {
                // Set key for entity
                entity.HasKey(p => p.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
