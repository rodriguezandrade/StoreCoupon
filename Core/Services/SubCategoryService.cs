using Core.Services.Interfaces;
using Repository.Models;
using Repository.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Repository.Models.Dtos;
using AutoMapper;
using System.Collections.Generic;
using Core.Exceptions;
using System.Net;

namespace Core.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IRepositoryWrapper _subCategoryRepositoryWrapper;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper, IRepositoryWrapper subCategoryRepositoryWrapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
            _subCategoryRepositoryWrapper = subCategoryRepositoryWrapper;
        }

        public async Task<IQueryable<SubCategoryDto>> Get()
        {
            var query = await _subCategoryRepository.FindAll();
            return _mapper.Map<List<SubCategoryDto>>(query).AsQueryable();
        }

        public async Task<IQueryable<SubCategoryDto>> GetDetails()
        {
            var query = _subCategoryRepositoryWrapper.GetSubCategories().ToList();
            var result = _mapper.Map<List<SubCategoryDto>>(query);
            return result.AsQueryable();
        }

        public void Save(SubCategoryDto subcategory)
        {
            subcategory.Id = new Guid();
            var query = _mapper.Map<SubCategory>(subcategory);
            _subCategoryRepository.Create(query);
            _subCategoryRepository.SaveChanges();
        }

        public async Task<SubCategoryDto> DeleteById(Guid Id)
        {
            var modelToDelete = await _subCategoryRepository.FindByCondition(x => x.Id == Id);
            _subCategoryRepository.Delete(modelToDelete.FirstOrDefault());
            return _mapper.Map<SubCategoryDto>(modelToDelete.FirstOrDefault());
        }

        public async Task<SubCategoryDto> Update(SubCategoryDto subcategory)
        {
            var entity = _mapper.Map<SubCategory>(subcategory);
            var modelToUpdate = await _subCategoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar la subcategory", HttpStatusCode.NotFound);
            }
            _subCategoryRepository.Update(entity);
            return _mapper.Map<SubCategoryDto>(entity);
        }

        public async Task<SubCategoryDto> GetById(Guid id)
        {
            var query = await _subCategoryRepository.FindByCondition(x => x.Id == id);
            return _mapper.Map<SubCategoryDto>(query.FirstOrDefault());
        }
    }
}