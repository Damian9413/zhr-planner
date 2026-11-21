using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZHRPlanner.Api.Data;
using ZHRPlanner.Api.Dtos.Troops;

namespace ZHRPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TroopsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TroopsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TroopResponse>>> GetAll()
    {
        var troops = await _context.Troops
            .Select(t => new TroopResponse(t.Id, t.ShortName, t.FullName))
            .ToListAsync();
        return Ok(troops);
    }

    [HttpGet("{int:id}")]
    public async Task<ActionResult<TroopResponse>> GetById(int id)
    {
        var troop = await _context.Troops.FindAsync(id);
        if (troop is null) return NotFound();
        return Ok(new TroopResponse(troop.Id, troop.ShortName, troop.FullName));
    }
}