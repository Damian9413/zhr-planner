namespace ZHRPlanner.Api.Domain.Entities;

public class Troop
{
    public int Id { get; set; }
    public string ShortName { get; set; } = string.Empty;
    public string? FullName { get; set; }
    
    public ICollection<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();
}