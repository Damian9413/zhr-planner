using System.ComponentModel.DataAnnotations;

namespace ZHRPlanner.Api.Dtos.Troops;

public record CreateTroopRequest([Required][MaxLength(50)] string ShortName, [MaxLength(200)]string? FullName);