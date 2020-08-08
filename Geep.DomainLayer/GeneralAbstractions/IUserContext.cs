using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.GeneralAbstractions
{
    public interface IUserContext
    {
        bool IsInRole(string role);
        string GetUserId();
        string GetUserEmail();
        Task<List<string>> GetUserRoles();
    }
}
