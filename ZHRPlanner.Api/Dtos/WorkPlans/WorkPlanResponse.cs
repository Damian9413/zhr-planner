
using ZHRPlanner.Api.Domain.Enums;

namespace ZHRPlanner.Api.Dtos.WorkPlans;

public record WorkPlanResponse(
    int Id,
    WorkPlanStatus Status,
    string Name,
    TripType TripType,
    DateOnly StartDate,
    DateOnly EndDate,
    string? Location,
    string? DailySchedule,
    int TroopId
);