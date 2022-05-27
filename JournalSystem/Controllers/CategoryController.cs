using AutoMapper;
using JournalSystem.Entities;
using JournalSystem.Models;
using JournalSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JournalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryController(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll ()
        {
            IEnumerable<Category> categories = await _categoryRepo.GetAll();
            var map = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(map);
        }

        [HttpGet("GetCategoryByID/{CategoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByID(Guid CategoryId)
        {

            var response = await _categoryRepo.GetById(CategoryId);
            return Ok(_mapper.Map<CategoryDto>(response));
        }

        [HttpPost("SubmitCategory")]
        public async Task<ActionResult<CategoryDto>> SubmitCategory(CategoryDto category)
        {
            var map = _mapper.Map<Category>(category);
            await _categoryRepo.Insert(map);
            return CreatedAtAction(nameof(GetCategoryByID), new { CategoryId = category.CategoryId }, category);
        }

        [HttpPut("UpdateCategory/{CategoryId}")]
        public async Task<ActionResult<CategoryDto>> PutCategory(CategoryDto category)
        {
            var map = _mapper.Map<Category>(category);
            await _categoryRepo.Update(map);
            return Ok(_mapper.Map<CategoryDto>(await _categoryRepo.GetById(category.CategoryId)));
        }

        [HttpDelete("DeleteCategory/{cId}")]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(Guid cId)
        {
            var deletable = await _categoryRepo.Delete(cId);
            var map = _mapper.Map<CategoryDto>(deletable);

            if (deletable == null)
            {
                return NotFound();
            }
            return map;
        }
    }
}
