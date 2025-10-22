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
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _chapterService;
        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        // GET: api/Chapter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChapterDTO>>> GetAllChapter()
        {
            var result = await _chapterService.GetAllChapter();
            return Ok(result);
        }

        // GET: api/Chapter/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ChapterDTO>> GetByIdChapter(int id)
        {
            var result = await _chapterService.GetByIdChapter(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/Chapter
        [HttpPost]
        public async Task<ActionResult<ChapterDTO>> AddChapter(ChapterDTO dto)
        {
            var created = await _chapterService.AddChapter(dto);
            return CreatedAtAction(nameof(GetByIdChapter), new { id = created.ChapterId }, created);
        }

        // PUT: api/Chapter/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChapter(int id, ChapterDTO dto)
        {
            await _chapterService.UpdateChapter(id, dto);
            return NoContent();
        }

        // DELETE: api/Chapter/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            await _chapterService.DeleteChapter(id);
            return NoContent();
        }
    }
}
