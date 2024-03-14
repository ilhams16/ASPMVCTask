using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebFormApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IRoleBLL _roleBLL;

		public RolesController(IRoleBLL roleBLL)
		{
			_roleBLL = roleBLL;
		}
		// GET: api/<RolesController>
		[HttpGet]
		public ActionResult<IEnumerable<RoleDTO>> GetAllRoles()
		{
			var roles = _roleBLL.GetAllRoles();
			return StatusCode(200, roles);
		}

		// POST api/<RolesController>
		[HttpPost]
		public ActionResult Post(string newRole)
		{
			_roleBLL.AddRole(newRole);
			return StatusCode(201, "Role added successfully");
		}

		[HttpPost("Role/{roleId}")]
		public ActionResult Post(string username, int roleId)
		{
			_roleBLL.AddUserToRole(username,roleId);
			return StatusCode(201, "User role updated successfully");
		}
	}
}
