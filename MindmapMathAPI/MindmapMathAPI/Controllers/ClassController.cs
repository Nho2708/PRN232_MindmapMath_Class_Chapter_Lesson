using Microsoft.AspNetCore.Mvc;
using MindmapBO;
using MindmapBO.Models;
using MindmapService.Interfaces;
using MindmapBO.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindmapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAllClass()
        {
            var result = await _classService.GetAllClass();
            return Ok(result);
        }

        // GET: api/Class/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDTO>> GetByIdClass(int id)
        {
            var result = await _classService.GetByIdClass(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Class
        [HttpPost]
        public async Task<ActionResult<ClassDTO>> AddClass(ClassDTO dto)
        {
            var created = await _classService.AddClass(dto);
            return CreatedAtAction(nameof(GetByIdClass), new { id = created.ClassId }, created);
        }

        // PUT: api/Class/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, ClassDTO dto)
        {
            await _classService.UpdateClass(id, dto);
            return NoContent();
        }

        // DELETE: api/Class/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            await _classService.DeleteClass(id);
            return NoContent();
        }
    }
}
