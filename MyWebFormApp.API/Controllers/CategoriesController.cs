using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebFormApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryBLL _categoryBLL;

		public CategoriesController(ICategoryBLL categoryBLL)
		{
			_categoryBLL = categoryBLL;
		}

		// GET: api/<CategoriesController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
		{
			var categories = _categoryBLL.GetAll();
			return StatusCode(200,categories);
		}

		// GET api/<CategoriesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryDTO>> GetByID(int id)
		{
			var category = _categoryBLL.GetById(id);
			return StatusCode(200,category);
		}

		// POST api/<CategoriesController>
		[HttpPost]
		public async Task<ActionResult> CreateCategory(CategoryCreateDTO categoryCreate)
		{
			_categoryBLL.Insert(categoryCreate);
			return StatusCode(201, "Category added successfully");
		}

		// PUT api/<CategoriesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateCategory(CategoryUpdateDTO categoryUpdate)
		{
			_categoryBLL.Update(categoryUpdate);
			return StatusCode(204, "Category updated successfully");
		}

		// DELETE api/<CategoriesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCategory(int id)
		{
			_categoryBLL.Delete(id);
			return StatusCode(204, "Category deleted successfully");
		}
	}
}
