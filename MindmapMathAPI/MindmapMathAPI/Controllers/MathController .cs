using Microsoft.AspNetCore.Mvc;
using MindmapService.Interfaces;
using MindmapBO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MindmapBO.DTOs;

namespace MindmapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly IMathService _mathService;
        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }

        // GET: api/Math
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MathDTO>>> GetAllMath()
        {
            var result = await _mathService.GetAllMath();
            return Ok(result);
        }

        // GET: api/Math/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MathDTO>> GetByIdMath(int id)
        {
            var result = await _mathService.GetByIdMath(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Math
        [HttpPost]
        public async Task<ActionResult<MathDTO>> AddMath(MathDTO dto)
        {
            var created = await _mathService.AddMath(dto);
            return CreatedAtAction(nameof(GetByIdMath), new { id = created.MathId }, created);
        }

        // PUT: api/Math/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMath(int id, MathDTO dto)
        {
            await _mathService.UpdateMath(id, dto);
            return NoContent();
        }

        // DELETE: api/Math/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMath(int id)
        {
            await _mathService.DeleteMath(id);
            return NoContent();
        }
    }
}
