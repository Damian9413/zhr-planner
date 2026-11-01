using Microsoft.EntityFrameworkCore;
using ZHRPlanner.Api.Domain.Entities;

namespace ZHRPlanner.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Constructor for the AppDbContext class, which takes DbContextOptions
                                                                                // as a parameter and passes it to the base DbContext class.
    {
    }
    
    public DbSet<Activity> Activities { get; set; } = null!;
    public DbSet<ActivityGoal> ActivityGoals { get; set; } = null!;
    public DbSet<Goal> Goals { get; set; } = null!;
    public DbSet<WorkPlan> WorkPlans { get; set; } = null!;
    public DbSet<Troop> Troops { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityGoal>()
            .HasKey(e => new { e.ActivityId, e.GoalId }); // The same activity cannot be linked to the same goal twice.
    }
}