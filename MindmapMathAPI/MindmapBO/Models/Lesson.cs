using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindmapBO.Models;

public partial class Lesson
{
    [Key] public int LessonId { get; set; }
    [ForeignKey(nameof(Chapter))] public int ChapterId { get; set; }
    public int? LessonNumber { get; set; }
    public string LessonName { get; set; }
    public string Description { get; set; }
    public int? OrderIndex { get; set; }

    public Chapter Chapter { get; set; }
}
