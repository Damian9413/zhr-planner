namespace ZHRPlanner.Api.Domain.Entities;

public class ActivityGoal
{
    public int GoalId { get; set; }
    public Goal Goal { get; set; } = null!;

    public int ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;
    
    public int Weight { get; set; }
}