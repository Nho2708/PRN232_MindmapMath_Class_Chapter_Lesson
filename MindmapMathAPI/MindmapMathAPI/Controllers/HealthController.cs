using Microsoft.AspNetCore.Mvc;
using MindmapBO.Data;

namespace MindmapMathAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly MindmapMathDbContext _db;

        public HealthController(MindmapMathDbContext db)
        {
            _db = db;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            var count = _db.Maths.Count();
            return Ok(new { status = "ok", mathCount = count });
        }
    }
}
