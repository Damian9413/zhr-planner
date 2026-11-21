using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZHRPlanner.Api.Data;
using ZHRPlanner.Api.Domain.Entities;
using ZHRPlanner.Api.Domain.Enums;
using ZHRPlanner.Api.Dtos.WorkPlans;
using ZHRPlanner.Api.Mappings;

namespace ZHRPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkPlansController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkPlansController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<WorkPlanResponse>>> GetAll()
    {
        var workPlans = await _context.WorkPlans.ToListAsync();

        return Ok(workPlans.Select(wp => wp.ToResponse()).ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WorkPlanResponse>> GetById(int id)
    {
        var workPlan = await _context.WorkPlans.FindAsync(id);
        if (workPlan is null) return NotFound();

        return Ok(workPlan.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult<WorkPlanResponse>> Create(CreateWorkPlanRequest request)
    {
        var troopExists = await _context.Troops.AnyAsync(t => t.Id == request.TroopId);
        if (!troopExists)
        {
            ModelState.AddModelError(nameof(request.TroopId), "Troop does not exist.");
            return ValidationProblem();
        }

        var workPlan = new WorkPlan
        {
            Name = request.Name,
            TripType = request.TripType!.Value,
            StartDate = request.StartDate!.Value,
            EndDate = request.EndDate!.Value,
            Location = request.Location,
            DailySchedule = request.DailySchedule,
            TroopId = request.TroopId!.Value,
            Status = WorkPlanStatus.Draft
        };

        _context.WorkPlans.Add(workPlan);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = workPlan.Id }, workPlan.ToResponse());
    }
}