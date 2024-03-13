using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebFormApp.BLL.DTOs;

namespace SampleMVC.ViewModels
{
	public class UsersAndRolesViewModel
	{
		public SelectList Users { get; set; }
		public string Username { get; set; }
		public IEnumerable<UserDTO> UsersWithRoles { get; set; }
		public SelectList Roles { get; set; }
		public int RoleID { get; set; }
	}
}
