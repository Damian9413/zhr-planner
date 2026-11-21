using ZHRPlanner.Api.Domain.Entities;
using ZHRPlanner.Api.Dtos.Goals;

namespace ZHRPlanner.Api.Mappings;

public static class GoalMappings
{
    public static GoalResponse ToResponse(this Goal goal)
    {
        return new GoalResponse(
            goal.Id,
            goal.Category,
            goal.Name,
            goal.Description,
            goal.WorkPlanId
        );
    }
}