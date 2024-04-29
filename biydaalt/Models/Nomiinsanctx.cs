using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace biydaalt.Models
{
    public class Nomiinsanctx : DbContext
    {
        public Nomiinsanctx(DbContextOptions<Nomiinsanctx> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(n => n.turuluud)
                .WithMany()
                .HasForeignKey(n => n.turulId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior here

            // Configure other relationships here if needed

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Turul> Turuls { get; set; }
        public DbSet<Dedturul> DedTuruls { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Albantushaal> Albantushaals { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Torguuli> Torguulis { get; set; }
        public DbSet<Bookgive> Bookgives { get; set; }
        public DbSet<Bookact> Bookacts { get; set; }
    }
}
