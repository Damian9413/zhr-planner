using ZHRPlanner.Api.Domain.Enums;

namespace ZHRPlanner.Api.Dtos.Goals;

public record GoalResponse(
    int Id,
    GoalCategory Category,
    string Name,
    string? Description,
    int WorkPlanId
);