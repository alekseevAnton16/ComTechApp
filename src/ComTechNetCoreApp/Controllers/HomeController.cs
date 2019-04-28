using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ComTechNetCoreApp.Models;

namespace ComTechNetCoreApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult CreateSubdivision()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateSubdivision(Subdivision subdivision)
		{
			return null;
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}
