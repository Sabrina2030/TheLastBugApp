using TheLastBug.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Business.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioInfoDTO UserExists(string userMail, string userPass);
        Task<bool> CreateUserAccount(UsuarioDTO userAccount);
    }
}
