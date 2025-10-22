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
    public class LessonRepository : ILessonRepository
    {
        private readonly MindmapMathDbContext _context;
        public LessonRepository(MindmapMathDbContext context) => _context = context;

        public async Task<List<Lesson>> GetAllLesson()
            => await _context.Lessons.ToListAsync();

        public async Task<Lesson> GetByIdLesson(int lessonId)
            => await _context.Lessons.FirstOrDefaultAsync(l => l.LessonId == lessonId);

        public async Task<Lesson> AddLesson(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task UpdateLesson(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLesson(int lessonId)
        {
            var entity = await _context.Lessons.FindAsync(lessonId);
            if (entity != null)
            {
                _context.Lessons.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
