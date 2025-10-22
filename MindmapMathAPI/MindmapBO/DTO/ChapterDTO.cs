using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace MindmapBO.DTOs
{
    public class ChapterDTO
    {
        public int ChapterId { get; set; }
        public int ClassId { get; set; }
        public int? ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }

        public List<LessonDTO> Lessons { get; set; }
    }
}
