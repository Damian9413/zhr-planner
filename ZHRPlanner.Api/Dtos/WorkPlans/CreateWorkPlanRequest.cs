using System.ComponentModel.DataAnnotations;
using ZHRPlanner.Api.Domain.Enums;

namespace ZHRPlanner.Api.Dtos.WorkPlans;

public record CreateWorkPlanRequest(
    [Required, MaxLength(100)] string Name,
    [Required] TripType? TripType,
    [Required] DateOnly? StartDate,
    [Required] DateOnly? EndDate,
    [MaxLength(200)] string? Location,
    [MaxLength(4000)] string? DailySchedule,
    [Required] int? TroopId
) : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate >= EndDate)
        {
            yield return new ValidationResult(
                "StartDate must be earlier than EndDate.",
                new[] { nameof(StartDate), nameof(EndDate) }
            );
        }
    }
}