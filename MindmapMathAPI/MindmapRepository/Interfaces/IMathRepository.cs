using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindmapBO.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindmapRepository.Interfaces
{
    public interface IMathRepository
    {
        Task<List<MindmapBO.Models.Math>> GetAllMath();
        Task<MindmapBO.Models.Math> GetByIdMath(int mathId);
        Task<MindmapBO.Models.Math> AddMath(MindmapBO.Models.Math math);
        Task UpdateMath(MindmapBO.Models.Math math);
        Task DeleteMath(int mathId);
    }
}

