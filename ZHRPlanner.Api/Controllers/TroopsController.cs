using Microsoft.AspNetCore.Mvc;
using ZHRPlanner.Api.Data;

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
}