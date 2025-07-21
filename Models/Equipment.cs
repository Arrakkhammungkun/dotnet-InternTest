using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.Models
{
    public class Equipment
    {
        [Required]
        public int EquipmentId { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string SerialNumber { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public int Total { get; set; } 

        public string? Status { get; set; } 

        public string? Unit { get; set; }

        [MaxLength(500)]
        public string? StorageLocation { get; set; } 

        public string? Condition { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}