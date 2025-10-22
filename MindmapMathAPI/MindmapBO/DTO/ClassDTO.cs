using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MindmapBO.DTOs
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public int MathId { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string OrderIndex { get; set; }

        public List<ChapterDTO> Chapters { get; set; }
    }
}
