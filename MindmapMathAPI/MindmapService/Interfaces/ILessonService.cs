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
    public interface ILessonService
    {
        Task<List<LessonDTO>> GetAllLesson();
        Task<LessonDTO> GetByIdLesson(int lessonId);
        Task<LessonDTO> AddLesson(LessonDTO lesson);
        Task UpdateLesson(int lessonId, LessonDTO lesson);
        Task DeleteLesson(int lessonId);
    }
}
