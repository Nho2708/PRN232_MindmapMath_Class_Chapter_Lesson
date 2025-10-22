// LessonService.cs
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
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repo;
        public LessonService(ILessonRepository repo) => _repo = repo;

        public async Task<List<LessonDTO>> GetAllLesson()
            => (await _repo.GetAllLesson()).Select(l => l.ToDTO()).ToList();

        public async Task<LessonDTO> GetByIdLesson(int lessonId)
            => (await _repo.GetByIdLesson(lessonId))?.ToDTO();

        public async Task<LessonDTO> AddLesson(LessonDTO dto)
        {
            var entity = dto.ToEntity();
            var created = await _repo.AddLesson(entity);
            return created.ToDTO();
        }

        public async Task UpdateLesson(int lessonId, LessonDTO dto)
        {
            if (lessonId != dto.LessonId) throw new System.ArgumentException("LessonId mismatch");
            await _repo.UpdateLesson(dto.ToEntity());
        }

        public Task DeleteLesson(int lessonId) => _repo.DeleteLesson(lessonId);
    }
}
