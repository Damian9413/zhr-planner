using System.ComponentModel.DataAnnotations;
using ZHRPlanner.Api.Domain.Enums;

namespace ZHRPlanner.Api.Dtos.Goals;

public record CreateGoalRequest(
    [Required, MaxLength(200)] string Name,
    [Required] GoalCategory? Category,
    [MaxLength(1000)] string? Description
);