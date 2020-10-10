using AutoMapper;
using Geep.DomainLayer.GeneralAbstractions;
using Geep.Models.Core;
using Geep.ViewModels;
using Geep.ViewModels.CoreVm;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geep.DataAccess.CommandQuery
{
    public class DocumentCQ : ICrudInteger<DocumentVm>
    {
        private IRepo<Document> _repo;
        public IMapper _mapper;

        public DocumentCQ(IRepo<Document> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<DocumentVm>> GetAll()
        {
            return _mapper.Map<List<DocumentVm>>(await _repo.GetAll());
        }

        public async Task<DocumentVm> GetById(int id)
        {
            return _mapper.Map<DocumentVm>(await _repo.GetById(id));
        }

        public async Task<DocumentVm> GetByReferenceId(int refId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseVm> AddOrUpdate(DocumentVm vm)
        {
            var model = _mapper.Map<Document>(vm);
            if (model.DocumentId > 0)
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

        public Task<List<DocumentVm>> GetAllById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseVm> ExcelImport(IFormFile excelFile)
        {
            throw new System.NotImplementedException();
        }
    }
}
