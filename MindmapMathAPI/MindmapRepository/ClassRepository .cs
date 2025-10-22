using MindmapBO;
using MindmapBO.Data;
using MindmapBO.Models;
using MindmapDAO;
using MindmapRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace MindmapRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly MindmapMathDbContext _context;
        public ClassRepository(MindmapMathDbContext context) => _context = context;

        public async Task<List<Class>> GetAllClass()
            => await _context.Classes.Include(c => c.Chapters).ToListAsync();

        public async Task<Class> GetByIdClass(int classId)
            => await _context.Classes.Include(c => c.Chapters)
                                     .FirstOrDefaultAsync(c => c.ClassId == classId);

        public async Task<Class> AddClass(Class cls)
        {
            _context.Classes.Add(cls);
            await _context.SaveChangesAsync();
            return cls;
        }

        public async Task UpdateClass(Class cls)
        {
            _context.Classes.Update(cls);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClass(int classId)
        {
            var entity = await _context.Classes.FindAsync(classId);
            if (entity != null)
            {
                _context.Classes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
