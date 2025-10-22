using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MindmapBO.DTOs
{
    public class MathDTO
    {
        public int MathId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        public List<ClassDTO> Classes { get; set; }
    }
}
