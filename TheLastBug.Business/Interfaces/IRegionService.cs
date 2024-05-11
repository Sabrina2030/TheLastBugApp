using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;

namespace TheLastBug.Business.Interfaces
{
    public interface IRegionService
    {
        Task<List<RegionDTO>> GetAllRegiones();
        Task<RegionDTO> GetRegionById(int regionId);
        Task<int> CreateRegion(RegionDTO regionDto);
        Task<bool> UpdateRegion(int regionId, RegionDTO regionDto);
        Task<bool> DeleteRegion(int regionId);
    }
}
