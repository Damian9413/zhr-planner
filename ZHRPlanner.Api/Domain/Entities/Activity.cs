namespace ZHRPlanner.Api.Domain.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string? Location { get; set; }
    public string? NeededItems { get; set; }
    public int HelperCount { get; set; }
    public string ResponsiblePerson { get; set; } = string.Empty;
    public string? ReviewerFeedback { get; set; }
    public string? SafetyNotes { get; set; }
    
    public int WorkPlanId { get; set; }
    public WorkPlan WorkPlan { get; set; } = null!;
    
    public ICollection<ActivityGoal> ActivityGoals { get; set; } = new List<ActivityGoal>();
}