using Microsoft.EntityFrameworkCore;
using MindmapBO;
using MindmapBO.Data;
using MindmapBO.Models;
using MindmapDAO;
using MindmapRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Threading.Tasks;

namespace MindmapRepository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly MindmapMathDbContext _context;
        public ChapterRepository(MindmapMathDbContext context) => _context = context;

        public async Task<List<Chapter>> GetAllChapter()
            => await _context.Chapters.Include(ch => ch.Lessons).ToListAsync();

        public async Task<Chapter> GetByIdChapter(int chapterId)
            => await _context.Chapters.Include(ch => ch.Lessons)
                                      .FirstOrDefaultAsync(ch => ch.ChapterId == chapterId);

        public async Task<Chapter> AddChapter(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();
            return chapter;
        }

        public async Task UpdateChapter(Chapter chapter)
        {
            _context.Chapters.Update(chapter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChapter(int chapterId)
        {
            var entity = await _context.Chapters.FindAsync(chapterId);
            if (entity != null)
            {
                _context.Chapters.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
