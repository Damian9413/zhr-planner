using ZHRPlanner.Api.Domain.Enums;

namespace ZHRPlanner.Api.Domain.Entities;

public class WorkPlan
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public TripType TripType { get; set; }
    public WorkPlanStatus Status { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Location { get; set; }
    public string? DailySchedule { get; set; }
    
    public int TroopId { get; set; }
    public Troop Troop { get; set; } = null!;
    
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();

}