using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiProject.Models
{
    public class Borrowing_Detail
    {
        [Key, Column(Order = 0)]
        public int BorrowingId { get; set; }

        [Key, Column(Order = 1)]
        public int EquipmentId { get; set; }

        [MaxLength(100)]
        public string ConditionAfterReturn { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Note { get; set; }

        public int Quantity { get; set; }

        public bool IsDamaged { get; set; } 

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow; 

        [ForeignKey("BorrowingId")]
        public Borrowing Borrowing { get; set; } = null!;

        [ForeignKey("EquipmentId")]
        public Equipment Equipment { get; set; } = null!;
    }
}