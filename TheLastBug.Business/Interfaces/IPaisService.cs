using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;

namespace TheLastBug.Business.Interfaces
{
    public interface IPaisService
    {
        Task<List<PaisDTO>> GetAllPaises();
        Task<PaisDTO> GetPaisById(int paisId);
        Task<int> CreatePais(PaisDTO paisDto);
        Task<bool> UpdatePais(int paisId, PaisDTO paisDto);
        Task<bool> DeletePais(int paisId);
    }
}
