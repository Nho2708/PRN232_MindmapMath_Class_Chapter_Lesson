
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindmapBO.DTOs;
using MindmapBO.Models;
using MindmapRepository.Interfaces;
using MindmapService.Interfaces;
using MindmapService.Mappers;


namespace MindmapService
{
    public class MathService : IMathService
    {
        private readonly IMathRepository _repo;
        public MathService(IMathRepository repo) => _repo = repo;

        public async Task<List<MathDTO>> GetAllMath()
            => (await _repo.GetAllMath()).Select(m => m.ToDTO()).ToList();

        public async Task<MathDTO> GetByIdMath(int mathId)
            => (await _repo.GetByIdMath(mathId))?.ToDTO();

        public async Task<MathDTO> AddMath(MathDTO dto)
        {
            var entity = dto.ToEntity();
            var created = await _repo.AddMath(entity);
            return created.ToDTO();
        }

        public async Task UpdateMath(int mathId, MathDTO dto)
        {
            if (mathId != dto.MathId) throw new System.ArgumentException("MathId mismatch");
            await _repo.UpdateMath(dto.ToEntity());
        }

        public Task DeleteMath(int mathId) => _repo.DeleteMath(mathId);
    }
}
