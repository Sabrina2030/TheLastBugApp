using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;

namespace TheLastBug.Business.Interfaces
{
    public interface IAyudaSocialService
    {
        Task<int> CreateAyudaSocialForRegion(AyudaSocialForRegionDTO ayudaSocialDto);
        Task<int> CreateAyudaSocial(AyudaSocialDTO ayudaSocialDto);
        Task<bool> CanAssignAyudaSocial(int usuarioId, string tipoDeAyuda, int año);
        Task<List<UsuariosConAyudasDTO>> GetUsuariosConAyudas();
        Task<(List<AyudaSocialDTO> ayudasSociales, string ultimaAyudaVigente)> GetAyudasSocialesByUsuarioByOrder(int usuarioId);
        Task<List<AyudaSocialDTO>> GetAyudasSocialesByUsuario(int usuarioId);
    }
}
