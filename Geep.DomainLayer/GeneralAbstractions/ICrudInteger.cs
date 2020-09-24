using Geep.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.GeneralAbstractions
{
    public interface ICrudInteger<T> where T : AuditVm
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAllById(int id);
        Task<T> GetById(int id);
        Task<T> GetByReferenceId(int refId);
        Task<ResponseVm> AddOrUpdate(T t);
        Task<ResponseVm> Delete(int id);
        Task<ResponseVm> ExcelImport(IFormFile excelFile);
    }
}
