using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindmapBO.Models;

public partial class Class
{
    [Key] public int ClassId { get; set; }
    [ForeignKey(nameof(Math))] public int MathId { get; set; }
    public int? EducationLevelId { get; set; }
    [Required] public string ClassName { get; set; }
    public string Description { get; set; }
    public string OrderIndex { get; set; }

    public Math Math { get; set; }
    public virtual ICollection<Chapter> Chapters { get; set; }

}
