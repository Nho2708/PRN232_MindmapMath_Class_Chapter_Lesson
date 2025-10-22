using MindmapBO;
using MindmapBO.Models;
using MindmapRepository.Interfaces;
using MindmapService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindmapBO.DTOs;
using MindmapService.Mappers;

namespace MindmapService
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _repo;
        public ClassService(IClassRepository repo) => _repo = repo;

        public async Task<List<ClassDTO>> GetAllClass()
            => (await _repo.GetAllClass()).Select(c => c.ToDTO()).ToList();

        public async Task<ClassDTO> GetByIdClass(int classId)
            => (await _repo.GetByIdClass(classId))?.ToDTO();

        public async Task<ClassDTO> AddClass(ClassDTO dto)
        {
            var entity = dto.ToEntity();
            var created = await _repo.AddClass(entity);
            return created.ToDTO();
        }

        public async Task UpdateClass(int classId, ClassDTO dto)
        {
            if (classId != dto.ClassId) throw new System.ArgumentException("ClassId mismatch");
            await _repo.UpdateClass(dto.ToEntity());
        }

        public Task DeleteClass(int classId) => _repo.DeleteClass(classId);
    }
}
