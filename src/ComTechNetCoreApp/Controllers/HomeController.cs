using System.Diagnostics;
using System.Linq;
using ComTechNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using ComTechNetCoreApp.Models;

namespace ComTechNetCoreApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public HomeController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region Subdivision

		public IActionResult GetAllSubdivisions()
		{
			var allSubdivisions = _dbContext.Subdivisions.ToList();
			return View(allSubdivisions);
		}

		[HttpGet]
		public IActionResult CreateSubdivision()
		{
			var newSubdivision = new Subdivision();
			return View(newSubdivision);
		}

		[HttpPost]
		public IActionResult CreateSubdivision(Subdivision subdivision)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(403);
			}

			_dbContext.Subdivisions.Add(subdivision);
			_dbContext.SaveChanges();
			return RedirectToAction("Index");
		}

		#endregion

		

		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}
