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
    public interface IClassService
    {
        Task<List<ClassDTO>> GetAllClass();
        Task<ClassDTO> GetByIdClass(int classId);
        Task<ClassDTO> AddClass(ClassDTO cls);
        Task UpdateClass(int classId, ClassDTO cls);
        Task DeleteClass(int classId);
    }
}
