using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebFormApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticlesController : ControllerBase
	{
		private readonly IArticleBLL _articleBLL;

		public ArticlesController(IArticleBLL articleBLL)
		{
			_articleBLL = articleBLL;
		}
		// GET: api/<ArticlesController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ArticleDTO>>> GetAllArticles()
		{
			var articles = _articleBLL.GetArticleWithCategory();
			return StatusCode(200, articles);
		}

		// GET api/<ArticlesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ArticleDTO>> GetByID(int id)
		{
			var Article = _articleBLL.GetArticleById(id);
			return StatusCode(200, Article);
		}
		// GET api/<ArticlesController>/Category/5
		[HttpGet("Category/{id}")]
		public async Task<ActionResult<ArticleDTO>> GetByCategoryID(int id)
		{
			var Article = _articleBLL.GetArticleByCategory(id);
			return StatusCode(200, Article);
		}

		// POST api/<CategoriesController>
		[HttpPost]
		public async Task<ActionResult> CreateArticle(ArticleCreateDTO ArticleCreate)
		{
			_articleBLL.Insert(ArticleCreate);
			return StatusCode(201, "Article added successfully");
		}

		// PUT api/<CategoriesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateArticle(ArticleUpdateDTO ArticleUpdate)
		{
			_articleBLL.Update(ArticleUpdate);
			return StatusCode(204, "Article updated successfully");
		}

		// DELETE api/<CategoriesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteArticle(int id)
		{
			_articleBLL.Delete(id);
			return StatusCode(204, "Article deleted successfully");
		}
	}
}
