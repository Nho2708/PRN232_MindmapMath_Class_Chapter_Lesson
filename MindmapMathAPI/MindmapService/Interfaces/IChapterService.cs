using MindmapBO;
using MindmapBO.DTOs;
using MindmapBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindmapService.Interfaces
{
    public interface IChapterService
    {
        Task<List<ChapterDTO>> GetAllChapter();
        Task<ChapterDTO> GetByIdChapter(int chapterId);
        Task<ChapterDTO> AddChapter(ChapterDTO chapter);
        Task UpdateChapter(int chapterId, ChapterDTO chapter);
        Task DeleteChapter(int chapterId);
    }
}
