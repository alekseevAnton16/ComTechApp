﻿using System.Diagnostics;
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

		[HttpGet]
		public IActionResult GetAllSubdivisions()
		{
			var allSubdivisions = _dbContext.Subdivisions.ToList();
			return View(allSubdivisions);
		}

		public IActionResult GetSubdivisionAndLecturers(int subdivisionId)
		{
			var subdivision = _dbContext.Subdivisions.Find(subdivisionId);
			if (subdivision == null)
			{
				return StatusCode(404);
			}

			var lecturers = _dbContext.Lecturers.Where(x => x.SubdivisionId == subdivisionId);
			ViewBag.Lecturers = lecturers;
			return View(subdivision);
		}

		[HttpGet]
		public IActionResult EditSubdivision(int id)
		{
			var subdivision = _dbContext.Subdivisions.Find(id);
			if (subdivision == null)
			{
				return StatusCode(404);
			}

			return View(nameof(CreateSubdivision), subdivision);
		}

		public IActionResult DeleteSubdivision(int id)
		{
			var subdivision = _dbContext.Subdivisions.Find(id);
			if (subdivision == null)
			{
				return StatusCode(404);
			}

			_dbContext.Subdivisions.Remove(subdivision);
			_dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
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
			return RedirectToAction(nameof(Index));
		}

		#endregion
		

		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}
