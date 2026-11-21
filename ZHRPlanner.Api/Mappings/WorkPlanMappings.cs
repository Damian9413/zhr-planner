using ZHRPlanner.Api.Domain.Entities;

using ZHRPlanner.Api.Dtos.WorkPlans;

namespace ZHRPlanner.Api.Mappings;

public static class WorkPlanMappings
{
    public static WorkPlanResponse ToResponse(this WorkPlan workPlan)
    {
        return new WorkPlanResponse(
            workPlan.Id,
            workPlan.Status,
            workPlan.Name,
            workPlan.TripType,
            workPlan.StartDate,
            workPlan.EndDate,
            workPlan.Location,
            workPlan.DailySchedule,
            workPlan.TroopId
        );
    }
}