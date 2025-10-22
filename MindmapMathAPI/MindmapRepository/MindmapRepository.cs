using MindmapBO.Data;
using MindmapRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MindmapBO.Models;
using MindmapDAO;

using System.Threading.Tasks;

namespace MindmapRepository
{
    public class MathRepository : IMathRepository
    {
        private readonly MindmapMathDbContext _context;
        public MathRepository(MindmapMathDbContext context) => _context = context;

        public async Task<List<MindmapBO.Models.Math>> GetAllMath()
            => await _context.Maths.Include(m => m.Classes).ToListAsync();

        public async Task<MindmapBO.Models.Math> GetByIdMath(int mathId)
            => await _context.Maths.Include(m => m.Classes)
                                   .FirstOrDefaultAsync(m => m.MathId == mathId);

        public async Task<MindmapBO.Models.Math> AddMath(MindmapBO.Models.Math math)
        {
            _context.Maths.Add(math);
            await _context.SaveChangesAsync();
            return math;
        }

        public async Task UpdateMath(MindmapBO.Models.Math math)
        {
            _context.Maths.Update(math);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMath(int mathId)
        {
            var entity = await _context.Maths.FindAsync(mathId);
            if (entity != null)
            {
                _context.Maths.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

