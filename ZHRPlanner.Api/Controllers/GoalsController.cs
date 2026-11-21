using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZHRPlanner.Api.Data;
using ZHRPlanner.Api.Domain.Entities;
using ZHRPlanner.Api.Dtos.Goals;
using ZHRPlanner.Api.Mappings;

namespace ZHRPlanner.Api.Controllers;

[ApiController]
[Route("api/workplans/{workPlanId:int}/goals")]
public class GoalsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GoalsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<GoalResponse>>> GetAll(int workPlanId)
    {
        var workPlanExists = await _context.WorkPlans.AnyAsync(wp => wp.Id == workPlanId);
        if (!workPlanExists) return NotFound();

        var goals = await _context.Goals
            .Where(g => g.WorkPlanId == workPlanId)
            .ToListAsync();

        return Ok(goals.Select(g => g.ToResponse()).ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GoalResponse>> GetById(int workPlanId, int id)
    {
        var goal = await _context.Goals
            .FirstOrDefaultAsync(g => g.Id == id && g.WorkPlanId == workPlanId);
        if (goal is null) return NotFound();

        return Ok(goal.ToResponse());
    }

    [HttpPost]
    public async Task<ActionResult<GoalResponse>> Create(int workPlanId, CreateGoalRequest request)
    {
        var workPlanExists = await _context.WorkPlans.AnyAsync(wp => wp.Id == workPlanId);
        if (!workPlanExists) return NotFound();

        var goal = new Goal
        {
            Name = request.Name,
            Category = request.Category!.Value,
            Description = request.Description,
            WorkPlanId = workPlanId
        };

        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { workPlanId, id = goal.Id }, goal.ToResponse());
    }
}