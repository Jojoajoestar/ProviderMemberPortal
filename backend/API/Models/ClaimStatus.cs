// Import required namespaces
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    // ==============================
    //      CLAIM STATUS MODEL
    // ==============================
    // This model represents the schema for the ClaimStatus table in the database.
    // It follows the Entity Framework Core conventions for code-first migrations.

    [Table("ClaimStatus")] // Map this model to the ClaimStatus table in the database
    public class ClaimStatus
    {
        // ==============================
        //      PROPERTY DEFINITIONS
        // ==============================
        
        // Primary Key: Unique identifier for each claim status
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Unique claim number
        [Required]
        [MaxLength(50)]
        public string ClaimNumber { get; set; } = string.Empty;

        // Status of the claim (e.g., Pending, Approved, Rejected)
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;

        // Date when the status was last updated
        [Required]
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;

        // Optional description of the claim status
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
