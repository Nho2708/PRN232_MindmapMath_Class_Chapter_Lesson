using MindmapBO;
using MindmapBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MindmapRepository.Interfaces
{
    public interface IChapterRepository
    {
        Task<List<Chapter>> GetAllChapter();
        Task<Chapter> GetByIdChapter(int chapterId);
        Task<Chapter> AddChapter(Chapter chapter);
        Task UpdateChapter(Chapter chapter);
        Task DeleteChapter(int chapterId);
    }
}
