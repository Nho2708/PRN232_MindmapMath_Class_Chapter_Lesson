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
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        // GET: api/Lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLesson()
        {
            var result = await _lessonService.GetAllLesson();
            return Ok(result);
        }

        // GET: api/Lesson/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDTO>> GetByIdLesson(int id)
        {
            var result = await _lessonService.GetByIdLesson(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<ActionResult<LessonDTO>> AddLesson(LessonDTO dto)
        {
            var created = await _lessonService.AddLesson(dto);
            return CreatedAtAction(nameof(GetByIdLesson), new { id = created.LessonId }, created);
        }

        // PUT: api/Lesson/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonDTO dto)
        {
            await _lessonService.UpdateLesson(id, dto);
            return NoContent();
        }

        // DELETE: api/Lesson/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await _lessonService.DeleteLesson(id);
            return NoContent();
        }
    }
}
