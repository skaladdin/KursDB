using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursDB
{
    internal class Context : DbContext
    {
        public DbSet<Studenten> Studenten { get; set; }
        public DbSet<Kurs> Kurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KursDB;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studenten>().HasKey(s => s.StudentID);
            modelBuilder.Entity<Kurs>().HasKey(k => k.KursID);

            modelBuilder.Entity<Studenten>().HasOne(s => s.Kurs)
                    .WithMany(k => k.Studenten)
                    .HasForeignKey(s => s.KursID)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
