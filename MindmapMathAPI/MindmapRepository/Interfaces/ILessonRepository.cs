using MindmapBO;
using MindmapBO.Models;
using System;
using System.Linq;
using System.Text;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindmapRepository.Interfaces
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllLesson();
        Task<Lesson> GetByIdLesson(int lessonId);
        Task<Lesson> AddLesson(Lesson lesson);
        Task UpdateLesson(Lesson lesson);
        Task DeleteLesson(int lessonId);
    }
}
