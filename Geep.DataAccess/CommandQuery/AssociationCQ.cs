﻿using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class AssociationCQ : ICrudInteger<AssociationVm>
    {
        private IRepo<Association> _repo;
        public IMapper _mapper;

        public AssociationCQ(IRepo<Association> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AssociationVm>> GetAll()
        {
            return _mapper.Map<List<AssociationVm>>(await _repo.GetAll());
        }

        public async Task<AssociationVm> GetById(int id)
        {
            return _mapper.Map<AssociationVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(AssociationVm vm)
        {
            var model = _mapper.Map<Association>(vm);
            if (model.AssociationId > 0)
            {
                _repo.Update(model);
            }
            else
            {
                await _repo.Save(model);
            }
            return await _repo.SaveChangesAsync();
        }

        public async Task<ResponseVm> Delete(int id)
        {
            await _repo.Delete(id);
            return await _repo.SaveChangesAsync();

        }

    }
}
