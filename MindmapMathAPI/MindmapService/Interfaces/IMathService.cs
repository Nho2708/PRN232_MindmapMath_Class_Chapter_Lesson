using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MindmapBO.DTOs;

namespace MindmapService.Interfaces
{
    public interface IMathService
    {
        Task<List<MathDTO>> GetAllMath();
        Task<MathDTO> GetByIdMath(int mathId);
        Task<MathDTO> AddMath(MathDTO math);
        Task UpdateMath(int mathId, MathDTO math);
        Task DeleteMath(int mathId);
    }
}
