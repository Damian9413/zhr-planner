using Microsoft.EntityFrameworkCore;
using ZHRPlanner.Api.Domain.Entities;

namespace ZHRPlanner.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Activity> Activities { get; set; } = null!;
    public DbSet<ActivityGoal> ActivityGoals { get; set; } = null!;
    public DbSet<Goal> Goals { get; set; } = null!;
    public DbSet<WorkPlan> WorkPlans { get; set; } = null!;
    public DbSet<Troop> Troops { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ActivityGoal: the same activity cannot be linked to the same goal twice.
        modelBuilder.Entity<ActivityGoal>()
            .HasKey(e => new { e.ActivityId, e.GoalId });

        // Troop
        modelBuilder.Entity<Troop>()
            .Property(t => t.ShortName)
            .HasMaxLength(50);

        modelBuilder.Entity<Troop>()
            .Property(t => t.FullName)
            .HasMaxLength(200);

        // WorkPlan
        modelBuilder.Entity<WorkPlan>()
            .Property(wp => wp.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<WorkPlan>()
            .Property(wp => wp.Location)
            .HasMaxLength(200);

        modelBuilder.Entity<WorkPlan>()
            .Property(wp => wp.DailySchedule)
            .HasMaxLength(4000);

        modelBuilder.Entity<WorkPlan>()
            .Property(wp => wp.TripType)
            .HasConversion<string>();

        modelBuilder.Entity<WorkPlan>()
            .Property(wp => wp.Status)
            .HasConversion<string>();

        // Goal
        modelBuilder.Entity<Goal>()
            .Property(g => g.Category)
            .HasConversion<string>();
        
        modelBuilder.Entity<Goal>()
            .Property(g => g.Name)
            .HasMaxLength(200);

        modelBuilder.Entity<Goal>()
            .Property(g => g.Description)
            .HasMaxLength(1000);
    }
}