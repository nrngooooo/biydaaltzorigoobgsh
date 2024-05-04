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
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Bookact>()
                .HasOne(b => b.book)
                .WithMany()
                .HasForeignKey(b => b.bookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bookact>()
                .HasOne(b => b.worker)
                .WithMany()
                .HasForeignKey(b => b.workerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Bookact>()
                .HasOne(b => b.actshaltgaan)
                .WithMany()
                .HasForeignKey(b => b.actshaltgaanId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Bookgive>()
                .HasOne(b => b.worker)
                .WithMany()
                .HasForeignKey(b => b.workerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Torguuli>()
                .HasOne(b => b.worker)
                .WithMany()
                .HasForeignKey(b => b.workerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Turul> turuls { get; set; }
        public DbSet<Dedturul> dedTuruls { get; set; }
        public DbSet<Worker> workers { get; set; }
        public DbSet<Albantushaal> albantushaals { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Torguuli>torguulis { get; set; }
        public DbSet<Torguulishaltgaan> torguulishaltgaans { get; set; }
        public DbSet<Bookgive> bookgives { get; set; }
        public DbSet<Bookact> bookacts { get; set; }
        public DbSet<Actshaltgaan> actshaltgaans { get; set; }

    }
}
