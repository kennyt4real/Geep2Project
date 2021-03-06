﻿using Geep.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Geep.DomainLayer.GeneralAbstractions
{
    public interface ICrudInteger<T> where T : AuditVm
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<ResponseVm> AddOrUpdate(T t);
        Task<ResponseVm> Delete(int id);
    }
}
