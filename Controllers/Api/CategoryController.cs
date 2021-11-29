using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ProjectTask.Dto;
using ProjectTask.Models;

namespace ProjectTask.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private ApplicationDbContext _context ;

            public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        //GET / api /Categories
        public IEnumerable <CategoryDto> GetCategories()
        {
            return _context.Categories.ToList().Select(Mapper.Map<Category,CategoryDto>);
        }

        //Get /api/category/1
        public IHttpActionResult GetCategory(int Id)

        {
            var category = _context.Categories.SingleOrDefault(x => x.CategoryId == Id);

            if (category == null)
                return NotFound();
            return Ok( Mapper.Map<Category,CategoryDto> (category));
        }

        //POST/api/category

        [HttpPost]
        public IHttpActionResult CreateCategory(CategoryDto categoryDto)

        {
            if (!ModelState.IsValid)
                return BadRequest();
            var category = Mapper.Map<CategoryDto, Category>(categoryDto);
            _context.Categories.Add(category);

            categoryDto.CategoryId = category.CategoryId;
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/"+ category.CategoryId),categoryDto);
        }


        [HttpPut]
        //Put /api/category/1

        public void UpdateCategory(int Id , CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var categoryInDb = _context.Categories.SingleOrDefault(x => x.CategoryId == Id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(categoryDto, categoryInDb);

            _context.SaveChanges();
           
        }

        [HttpDelete]
        //DELETE/api/Categories/1
        public void DeleteCategory(int Id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(x => x.CategoryId == Id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();


        }
    }
}
