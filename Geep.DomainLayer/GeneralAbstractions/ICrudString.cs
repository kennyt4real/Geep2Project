using Geep.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.GeneralAbstractions
{
    public interface ICrudString<T> where T: AuditVm
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<ResponseVm> AddOrUpdate(T t);
        Task<ResponseVm> Delete(string id);
    }
}
