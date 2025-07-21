using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiProject.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }

        [Required]
        public DateTime BorrowedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? DateReturned { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Borrowed";

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        [Required]
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; } = null!;
    }
}