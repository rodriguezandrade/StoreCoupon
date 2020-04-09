using AutoMapper;
using Core.Exceptions;
using Core.Services.Interfaces;
using Repository.Models;
using Repository.Models.Dtos;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<IQueryable<GeneralCategoryDto>> Get()
        {
            var query = await _categoryRepository.FindAll();
            return _mapper.Map<List<GeneralCategoryDto>>(query).AsQueryable();
        }

        public void Save(GeneralCategoryDto category)
        {
            var query = _mapper.Map<GeneralCategory>(category);
            _categoryRepository.Save(query);
            _categoryRepository.SaveChanges();
        }

        public async Task<GeneralCategoryDto> DeleteById(Guid Id)
        {
            var query = await _categoryRepository.DeleteById(Id);
            return _mapper.Map<GeneralCategoryDto>(query);
        }

        public async Task<GeneralCategoryDto> Update(GeneralCategoryDto category)
        {
            var entity = _mapper.Map<GeneralCategory>(category);
            var modelToUpdate = await _categoryRepository.FindByCondition(x => x.Id == entity.Id);
            if (!modelToUpdate.Any())
            {
                throw new ApiException("No se pudo editar la GeneralCategory", HttpStatusCode.NotFound);
            }
            _categoryRepository.Update(entity);
            return _mapper.Map<GeneralCategoryDto>(entity);
        }

        public async Task<GeneralCategoryDto> GetById(Guid id)
        {
            var query = await _categoryRepository.GetById(id);
            return _mapper.Map<GeneralCategoryDto>(query);
        }
    }
}
