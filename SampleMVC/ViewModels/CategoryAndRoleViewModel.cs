using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebFormApp.BLL.DTOs;

namespace SampleMVC.ViewModels
{
	public class CategoryAndRoleViewModel
	{
		public IEnumerable<CategoryDTO>? Categories { get; set; }
		public List<RoleDTO> Roles { get; set; }
	}
}
