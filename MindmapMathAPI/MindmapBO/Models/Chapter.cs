using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindmapBO.Models;

public partial class Chapter
{
    [Key] public int ChapterId { get; set; }
    [ForeignKey(nameof(Class))] public int ClassId { get; set; }
    public int? ChapterNumber { get; set; }
    public string ChapterName { get; set; }
    public string Description { get; set; }
    public int? OrderIndex { get; set; }

    public Class Class { get; set; }

    public ICollection<Lesson> Lessons { get; set; }
}
