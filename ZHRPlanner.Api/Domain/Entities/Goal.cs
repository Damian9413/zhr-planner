using ZHRPlanner.Api.Domain.Enums;

namespace ZHRPlanner.Api.Domain.Entities;

public class Goal
{
    public int Id { get; set; }
    public GoalCategory Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public int WorkPlanId { get; set; }
    public WorkPlan WorkPlan { get; set; } = null!;
    
    public ICollection<ActivityGoal> ActivityGoals { get; set; } = new List<ActivityGoal>();
}