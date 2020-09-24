using Geep.Models;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.GeneralAbstractions
{
    public interface IRepo<T> where T : Audit
    {
        Task<List<T>> GetAll(string includeProperties = "");
        Task<List<T>> GetAllById(string includeProperties = "", Expression<Func<T, bool>> filter = null);
        Task<T> GetById(int id);
        Task<T> GetById(string id);
        Task<T> GetFirstOrDeafult(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<T> GetFirstOrDeafultWithNoTracking(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<bool> CheckAny(int id);
        Task Save(T t);
        void Update(T t);
        Task Delete(int t);
        Task Delete(string t);
        void Delete(T t);
        Task<ResponseVm> SaveChangesAsync();
        public string UserId { get; set; }

        Task SaveMultiple(List<T> ts);
    }
}
