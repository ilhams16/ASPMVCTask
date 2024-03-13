using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebFormApp.BLL;
using MyWebFormApp.BLL.Interfaces;
using SampleMVC.ViewModels;

namespace SampleMVC.Controllers
{
	public class RolesController : Controller
	{
		private readonly IUserBLL _userBLL;
		private readonly IRoleBLL _roleBLL;

		public RolesController(IUserBLL userBLL, IRoleBLL roleBLL)
		{
			_userBLL = userBLL;
			_roleBLL = roleBLL;
		}
		// GET: RolesController
		public ActionResult Index()
		{
			var userRoles = _userBLL.GetAllWithRoles();
			UsersAndRolesViewModel usersAndRolesViewModel = new UsersAndRolesViewModel();
			usersAndRolesViewModel.Users = new SelectList(_userBLL.GetAll(), "Username", "Username");
			usersAndRolesViewModel.UsersWithRoles = userRoles;
			usersAndRolesViewModel.Roles = new SelectList(_roleBLL.GetAllRoles(), "RoleID", "RoleName"); ;
			return View(usersAndRolesViewModel);
		}

		// GET: RolesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: RolesController/Create
		public ActionResult Create()
		{
			//	var users = _userBLL.GetAll();
			//	var userRoles = _userBLL.GetAllWithRoles();
			//	var roles = _roleBLL.GetAllRoles();
			//	UsersAndRolesViewModel usersAndRolesViewModel = new UsersAndRolesViewModel();
			//	usersAndRolesViewModel.Users = users;
			//	usersAndRolesViewModel.UsersWithRoles = userRoles;
			//	usersAndRolesViewModel.Roles = roles;
			return View();
		}

		// POST: RolesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(int roleID, string username)
		{
			try
			{
				_roleBLL.AddUserToRole(username, roleID);
				ViewBag.Message = @"<div class='alert alert-success'><strong>Success!&nbsp;</strong>Add Role for User Successfully !</div>";
			}
			catch (Exception ex)
			{
				ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
			}
			return RedirectToAction("index");
		}

		// GET: RolesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: RolesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: RolesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: RolesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
