using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MindmapBO.DTOs
{
    public class LessonDTO
    {
        public int LessonId { get; set; }
        public int ChapterId { get; set; }
        public int? LessonNumber { get; set; }
        public string LessonName { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
    }
}
