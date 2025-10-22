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
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _repo;
        public ChapterService(IChapterRepository repo) => _repo = repo;

        public async Task<List<ChapterDTO>> GetAllChapter()
            => (await _repo.GetAllChapter()).Select(c => c.ToDTO()).ToList();

        public async Task<ChapterDTO> GetByIdChapter(int chapterId)
            => (await _repo.GetByIdChapter(chapterId))?.ToDTO();

        public async Task<ChapterDTO> AddChapter(ChapterDTO dto)
        {
            var entity = dto.ToEntity();
            var created = await _repo.AddChapter(entity);
            return created.ToDTO();
        }

        public async Task UpdateChapter(int chapterId, ChapterDTO dto)
        {
            if (chapterId != dto.ChapterId) throw new System.ArgumentException("ChapterId mismatch");
            await _repo.UpdateChapter(dto.ToEntity());
        }

        public Task DeleteChapter(int chapterId) => _repo.DeleteChapter(chapterId);
    }
}
