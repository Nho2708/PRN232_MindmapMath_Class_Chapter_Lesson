using MindmapBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindmapRepository.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClass();
        Task<Class> GetByIdClass(int classId);
        Task<Class> AddClass(Class cls);
        Task UpdateClass(Class cls);
        Task DeleteClass(int classId);
    }
}
