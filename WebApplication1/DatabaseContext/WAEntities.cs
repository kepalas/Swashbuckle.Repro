using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DatabaseContext
{
    public partial class WAEntities : DbContext
    {
        public WAEntities()
        {
        }

        public WAEntities(DbContextOptions<WAEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<ChangeDocumentsSet> ChangeDocumentsSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ChangeDocumentsSet>(entity =>
            {
                entity.HasKey(e => new { e.Changedocobjectclass, e.Changedocobject, e.Changedocument })
                    .HasName("PK__ChangeDocumentsSet__Changedocobjectclass_Changedocobject_Changedocument");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
