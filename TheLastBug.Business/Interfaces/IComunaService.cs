using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;

namespace TheLastBug.Business.Interfaces
{
    public interface IComunaService
    {
        Task<List<ComunaDTO>> GetAllComunas();
        Task<ComunaDTO> GetComunaById(int comunaId);
        Task<int> CreateComuna(ComunaDTO comunaDto);
        Task<bool> UpdateComuna(int comunaId, ComunaDTO comunaDto);
        Task<bool> DeleteComuna(int comunaId);
    }
}
