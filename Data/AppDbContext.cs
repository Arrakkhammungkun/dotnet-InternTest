using Microsoft.EntityFrameworkCore;
using MyApiProject.Models;

namespace MyApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DbSet<Borrowing> Borrowings { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Borrowing_Detail> Borrowing_Details { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Equipment>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Borrowing>()
                .Property(b => b.BorrowedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Borrowing_Detail>()
                .Property(bd => bd.RecordedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            
            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Equipment)
                .WithMany()
                .HasForeignKey(b => b.EquipmentId);

            modelBuilder.Entity<Borrowing_Detail>()
                .HasKey(bd => new { bd.BorrowingId, bd.EquipmentId });

            modelBuilder.Entity<Borrowing_Detail>()
                .HasOne(bd => bd.Borrowing)
                .WithMany()
                .HasForeignKey(bd => bd.BorrowingId);

            modelBuilder.Entity<Borrowing_Detail>()
                .HasOne(bd => bd.Equipment)
                .WithMany()
                .HasForeignKey(bd => bd.EquipmentId);

           
            var seedDate = new DateTime(2025, 7, 20, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<User>().HasData(
                Enumerable.Range(1, 50).Select(i => new User
                {
                    UserId = i,
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    Email = $"user{i}@example.com",
                    Phone = $"12345678{i:D2}",
                    IsAdmin = i % 2 == 0,
                    CreatedAt = seedDate.AddDays(i - 1)
                }).ToArray()
            );

            modelBuilder.Entity<Equipment>().HasData(
                Enumerable.Range(1, 50).Select(i => new Equipment
                {
                    EquipmentId = i,
                    Name = $"Equipment{i}",
                    SerialNumber = $"SN{i:D3}",
                    Description = $"Description for Equipment {i}",
                    Total = i % 10 + 1,
                    Status = i % 2 == 0 ? "Available" : "In Use",
                    Unit = "Unit",
                    StorageLocation = $"Room {i}",
                    Condition = i % 3 == 0 ? "Good" : "Fair",
                    CreatedAt = seedDate.AddDays(i - 1)
                }).ToArray()
            );

            modelBuilder.Entity<Borrowing>().HasData(
                Enumerable.Range(1, 50).Select(i => new Borrowing
                {
                    BorrowingId = i,
                    BorrowedDate = seedDate.AddDays(-i),
                    DueDate = seedDate.AddDays(-i + 7),
                    Status = i % 2 == 0 ? "Borrowed" : "Returned",
                    UserId = i,
                    EquipmentId = i
                }).ToArray()
            );

            modelBuilder.Entity<Borrowing_Detail>().HasData(
                Enumerable.Range(1, 50).Select(i => new Borrowing_Detail
                {
                    BorrowingId = i,
                    EquipmentId = i,
                    ConditionAfterReturn = i % 2 == 0 ? "Good" : "Needs Repair",
                    Note = $"Note for Borrowing {i}",
                    Quantity = i % 5 + 1,
                    IsDamaged = i % 3 == 0,
                    RecordedAt = seedDate.AddDays(i - 1)
                }).ToArray()
            );
        }
    }
}