// Import required namespaces
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    // ==============================
    //      DB CONTEXT DEFINITION
    // ==============================
    // ClaimStatusDbContext is responsible for managing database access and interactions
    // with the ClaimStatus table.

    public class ClaimStatusDbContext : DbContext
    {
        // ==============================
        //      CONSTRUCTOR
        // ==============================
        // The constructor takes DbContextOptions and passes them to the base class.

        public ClaimStatusDbContext(DbContextOptions<ClaimStatusDbContext> options)
            : base(options)
        {
        }

        // ==============================
        //      DB SETS
        // ==============================
        // DbSet represents a table in the database.
        // This DbSet corresponds to the ClaimStatus table.
        
        public DbSet<ClaimStatus> ClaimStatuses { get; set; }

        // ==============================
        //      MODEL CONFIGURATION
        // ==============================
        // This method configures model properties using Fluent API.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimStatus>()
                .HasKey(cs => cs.Id); // Primary Key
        }
    }
}
