using Geep.DataAccess.Context;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models;
using Geep.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DataAccess.Concrete
{
    public class Repo<T> : IRepo<T> where T : Audit
    {
        private GeepDbContext _db { get; }
        private readonly DbSet<T> _dbSet;
        private readonly IUserContext _userContext;

        public Repo(GeepDbContext db, IUserContext userContext)
        {
            _db = db;
            _dbSet = _db.Set<T>();
            _userContext = userContext;
        }
        public async Task<List<T>> GetAll(string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllById(string includeProperties = "", Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            //return await query.AsNoTracking().ToListAsync();
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetFirstOrDeafult(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> GetFirstOrDeafultWithNoTracking(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Save(T t)
        {
            t.DateCreated = DateTime.Now;
            t.CreatedBy = UserId;
            await _db.AddAsync(t);
        }

        public void Update(T t)
        {
            t.DateUpdated = DateTime.Now;
            t.UpdatedBy = UserId;
            if (_db.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _db.Entry(t).State = EntityState.Modified;
        }

        public async Task<bool> CheckAny(int id)
        {
            var t = await _dbSet.FindAsync(id);
            return t != null;
        }

        public async Task Delete(int id)
        {
            var t = await _dbSet.FindAsync(id);
            if (_db.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
        }

        public async Task Delete(string id)
        {
            var t = await _dbSet.FindAsync(id);
            if (_db.Entry(t).State == EntityState.Detached)
            {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
        }

        public void Delete(T t)
        {
            if (t != null)
            {
                if (_db.Entry(t).State == EntityState.Detached)
                {
                    _dbSet.Attach(t);
                }
                _dbSet.Remove(t);
            }
        }
        public async Task<ResponseVm> SaveChangesAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                return new ResponseVm { Status = true, Message = "Record transaction completed  Successfully" };
            }
            catch (Exception e)
            {
                return new ResponseVm { Status = false, Message = e.Message };
            }
        }

        public async Task SaveMultiple(List<T> ts)
        {
            foreach (var t in ts)
            {
                await Save(t);
            }


        }

        public string UserId
        {
            get
            {
                return _userContext.GetUserEmail();
            }
            set { }
        }
       
    }
}
