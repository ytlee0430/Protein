using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaiwanMuscle.Models
{
    public partial class ProteinsContext : DbContext
    {

        public ProteinsContext(DbContextOptions<ProteinsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<ProteinData> ProteinData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=proteins.cdys9koffynq.us-east-1.rds.amazonaws.com;port=3306;database=Proteins;uid=protein;password=hilosystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstPic).HasColumnType("varchar(200)");

                entity.Property(e => e.FourthPic).HasColumnType("varchar(200)");

                entity.Property(e => e.HeadPic)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.SecondPic).HasColumnType("varchar(200)");

                entity.Property(e => e.StockId)
                    .HasColumnName("StockID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ThirdPic).HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<ProteinData>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Discount).HasColumnType("int(11)");

                entity.Property(e => e.Favor)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Price).HasColumnType("int(11)");

                entity.Property(e => e.Stock).HasColumnType("int(11)");
            });
        }
    }
}
