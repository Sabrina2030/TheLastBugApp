using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBug.Business.DTOs;

namespace TheLastBug.Business.Interfaces
{
    public interface ILogService
    {
        Task LogUserAction(int userId, string accion);
        Task<List<LogDTO>> GetLogsByDate(DateTime fecha);
    }
}
