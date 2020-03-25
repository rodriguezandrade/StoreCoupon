using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GeneralCategoryService : IGeneralCategoryService
    {
        private readonly IGeneralCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GeneralCategoryService(IGeneralCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<GeneralCategoryDto>> GetAll()
        { 
            var query = await _categoryRepository.FindAll();
            return _mapper.Map<List<GeneralCategoryDto>>(query).AsQueryable();
        }

        public void Save(GeneralCategoryDto category)
        {
            category.Id = new Guid();
            var query = _mapper.Map<GeneralCategory>(category);
            _categoryRepository.Save(query);
            _categoryRepository.SaveChanges();
        }

        public async Task<GeneralCategoryDto> DeleteById(Guid Id)
        { 
            var query = await _categoryRepository.DeleteById(Id);
            return _mapper.Map<GeneralCategoryDto>(query);
        }

        public async Task<GeneralCategoryDto> Update(GeneralCategoryDto model)
        {
            var query = _mapper.Map<GeneralCategory>(model);
            var resp = await _categoryRepository.Modify(query);
            return _mapper.Map<GeneralCategoryDto>(resp);
        }

        public async Task<GeneralCategoryDto> GetById(Guid id)
        {
            var query = await _categoryRepository.GetById(id);
            return _mapper.Map<GeneralCategoryDto>(query);
        }
    }
}
