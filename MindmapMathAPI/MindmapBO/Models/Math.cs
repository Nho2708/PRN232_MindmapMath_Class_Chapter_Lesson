using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MindmapBO.Models;

public partial class Math
{
    [Key]
    public int MathId { get; set; }
    [Required, MaxLength(50)]
    public string SubjectName { get; set; }
    [MaxLength(250)]
    public string Description { get; set; }

    public virtual ICollection<Class> Classes { get; set; }
}
