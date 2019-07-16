using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DataAccess
{
    class FacultateDbContext : DbContext
    {
        DbSet<Student> students;
        DbSet<Adresa> adrese;
        DbSet<Curs> cursuri;
        DbSet<Grupa> grupe;
        DbSet<Materie> materii;
        DbSet<Nota> note;
        DbSet<Orar> ore;
        DbSet<Profesor> profesori;
        DbSet<GrupareStudenti> grupareStudenti;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Facultate;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(c => c.Nume).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(c => c.Prenume).HasMaxLength(100);
            modelBuilder.Entity<GrupareStudenti>().HasKey(c => new { c.GrupaId, c.StudentId });
            modelBuilder.Entity<GrupareStudenti>().
                HasOne<Student>(c => c.Student)
                .WithMany(s => s.GrupareStudenti)
                .HasForeignKey(c => c.StudentId);
            modelBuilder.Entity<GrupareStudenti>()
                .HasOne<Grupa>(c => c.Grupa)
                .WithMany(c => c.GrupeStudenti)
                .HasForeignKey(c => c.GrupaId);

            modelBuilder.Entity<Materie>()
                .Property(c => c.Denumire)
                .HasMaxLength(50);
            modelBuilder.Entity<Materie>()
                .Property(C => C.Denumire)
                .HasColumnName("Nume_Materie");
            modelBuilder.Entity<Profesor>()
                .Property(c => c.Nume)
                .HasMaxLength(50);
            modelBuilder.Entity<Profesor>()
                .Property(c => c.Prenume)
                .HasMaxLength(100);

            modelBuilder.Entity<Curs>()
                .HasKey(e => new { e.MaterieId, e.ProfesorId });
            modelBuilder.Entity<Curs>()
                .HasOne<Materie>(c => c.Materie)
                .WithMany(c => c.Cursuri)
                .HasForeignKey(c => c.MaterieId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Curs>()
                .HasOne<Profesor>(c => c.Profesor)
                .WithMany(c => c.Cursuri)
                .HasForeignKey(c => c.ProfesorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orar>()
                .HasKey(c => new { c.GrupaId, c.MaterieId, c.ProfesorId });
            modelBuilder.Entity<Orar>()
                .HasOne<Curs>(c => c.Curs)
                .WithMany(c => c.Ore)
                .HasForeignKey(c => new { c.MaterieId, c.ProfesorId })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Orar>()
                .HasOne<Grupa>(c => c.Grupa)
                .WithMany(c => c.Ore)
                .HasForeignKey(c => c.GrupaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nota>()
                .HasKey(c => new { c.StudentId, c.GrupaId, c.MaterieId, c.ProfesorId });
            modelBuilder.Entity<Nota>()
                .HasOne<Orar>(c => c.Ora)
                .WithMany(c => c.Note)
                .HasForeignKey(c => new { c.GrupaId, c.MaterieId, c.ProfesorId })
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Nota>()
                .HasOne<Student>(c => c.Student)
                .WithMany(c => c.Note)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Adresa>()
                .HasOne<Student>(s => s.Student)
                .WithOne(s => s.Adresa)
                .HasForeignKey<Student>(s => s.AdresaId)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
