using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MindmapBO.Models;
using MindmapBO.DTOs;
using System.Linq;

namespace MindmapService.Mappers
{
    public static class EntityMapper
    {
        // Math
        public static MathDTO ToDTO(this MindmapBO.Models.Math m) => m == null ? null : new MathDTO
        {
            MathId = m.MathId,
            SubjectName = m.SubjectName,
            Description = m.Description,
            Classes = m.Classes?.Select(c => c.ToDTO()).ToList()
        };
        public static MindmapBO.Models.Math ToEntity(this MathDTO dto) => dto == null ? null : new MindmapBO.Models.Math
        {
            MathId = dto.MathId,
            SubjectName = dto.SubjectName,
            Description = dto.Description
        };

        // Class
        public static ClassDTO ToDTO(this Class c) => c == null ? null : new ClassDTO
        {
            ClassId = c.ClassId,
            MathId = c.MathId,
            ClassName = c.ClassName,
            Description = c.Description,
            OrderIndex = c.OrderIndex,
            Chapters = c.Chapters?.Select(ch => ch.ToDTO()).ToList()
        };
        public static Class ToEntity(this ClassDTO dto) => dto == null ? null : new Class
        {
            ClassId = dto.ClassId,
            MathId = dto.MathId,
            ClassName = dto.ClassName,
            Description = dto.Description,
            OrderIndex = dto.OrderIndex
        };

        // Chapter
        public static ChapterDTO ToDTO(this Chapter ch) => ch == null ? null : new ChapterDTO
        {
            ChapterId = ch.ChapterId,
            ClassId = ch.ClassId,
            ChapterNumber = ch.ChapterNumber,
            ChapterName = ch.ChapterName,
            Description = ch.Description,
            OrderIndex = ch.OrderIndex,
            Lessons = ch.Lessons?.Select(l => l.ToDTO()).ToList()
        };
        public static Chapter ToEntity(this ChapterDTO dto) => dto == null ? null : new Chapter
        {
            ChapterId = dto.ChapterId,
            ClassId = dto.ClassId,
            ChapterNumber = dto.ChapterNumber,
            ChapterName = dto.ChapterName,
            Description = dto.Description,
            OrderIndex = dto.OrderIndex
        };

        // Lesson
        public static LessonDTO ToDTO(this Lesson l) => l == null ? null : new LessonDTO
        {
            LessonId = l.LessonId,
            ChapterId = l.ChapterId,
            LessonNumber = l.LessonNumber,
            LessonName = l.LessonName,
            Description = l.Description,
            OrderIndex = l.OrderIndex
        };
        public static Lesson ToEntity(this LessonDTO dto) => dto == null ? null : new Lesson
        {
            LessonId = dto.LessonId,
            ChapterId = dto.ChapterId,
            LessonNumber = dto.LessonNumber,
            LessonName = dto.LessonName,
            Description = dto.Description,
            OrderIndex = dto.OrderIndex
        };
    }
}
