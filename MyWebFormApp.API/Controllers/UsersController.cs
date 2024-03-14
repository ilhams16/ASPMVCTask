using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.Interfaces;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebFormApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserBLL _userBLL;
		public UsersController(IUserBLL userBLL)
		{
			_userBLL = userBLL;
		}
		// GET: api/<UsersController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
		{
			var users = _userBLL.GetAll();
			return StatusCode(200, users);
		}

		// Post api/<UsersController>/Login
		[HttpPost("Login")]
		public async Task<ActionResult> UserLogin(LoginDTO loginDTO)
		{
			var user = _userBLL.LoginMVC(loginDTO);
			if (user == null)
			{
				return Unauthorized();
			}
			//var userDtoSerialize = JsonSerializer.Serialize(user);
			//HttpContext.Session.SetString("user", userDtoSerialize);
			return StatusCode(200,$"You logged in as {user.Username}");
		}
		// Post api/<UsersController>/Logout
		[HttpPost("Logout")]
		public IActionResult Logout()
		{
			return StatusCode(204,"You logged out");
		}

		// POST api/<UsersController>
		[HttpPost]
		public async Task<ActionResult> CreateUser(UserCreateDTO userCreate)
		{
			_userBLL.Insert(userCreate);
			return StatusCode(201, "User added successfully");
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
