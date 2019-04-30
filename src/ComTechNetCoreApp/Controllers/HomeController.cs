using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ComTechNetCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using ComTechNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

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
			CStatic.Logger.Trace($"Start {nameof(Index)}");
			return View();
		}

		#region Subdivision

		[HttpGet]
		public IActionResult GetAllSubdivisions()
		{
			CStatic.Logger.Trace($"Start {nameof(GetAllSubdivisions)}");
			var allSubdivisions = _dbContext.Subdivisions.ToList();
			return View(allSubdivisions);
		}

		public IActionResult GetSubdivisionAndLecturers(int subdivisionId)
		{
			CStatic.Logger.Trace($"Start {nameof(GetSubdivisionAndLecturers)}");
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
			CStatic.Logger.Trace($"Start {nameof(EditSubdivision)}");
			var subdivision = _dbContext.Subdivisions.Find(id);
			if (subdivision == null)
			{
				return StatusCode(404);
			}

			return View(nameof(CreateSubdivision), subdivision);
		}

		public IActionResult DeleteSubdivision(int id)
		{
			CStatic.Logger.Trace($"Start {nameof(DeleteSubdivision)}");
			var subdivision = _dbContext.Subdivisions.Find(id);
			if (subdivision == null)
			{
				return StatusCode(404);
			}

			_dbContext.Subdivisions.Remove(subdivision);
			_dbContext.SaveChanges();
			return RedirectToAction(nameof(GetAllSubdivisions));
		}

		[HttpGet]
		public IActionResult CreateSubdivision()
		{
			CStatic.Logger.Trace($"Start {nameof(CreateSubdivision)}");
			var newSubdivision = new Subdivision();
			return View(newSubdivision);
		}

		[HttpPost]
		public IActionResult CreateSubdivision(Subdivision subdivision)
		{
			CStatic.Logger.Trace($"Start {nameof(CreateSubdivision)}");
			if (!ModelState.IsValid)
			{
				CStatic.Logger.Warn($"Method {nameof(CreateSubdivision)}: model is invalid");
				return StatusCode(403);
			}

			var subdivisionInDb = _dbContext.Subdivisions.Find(subdivision.SubdivisionId);
			if (subdivisionInDb == null)
			{
				_dbContext.Subdivisions.Add(subdivision);
			}
			else
			{
				subdivisionInDb.SubdivisionName = subdivision.SubdivisionName;
				subdivisionInDb.SubdivisionСreateYear = subdivision.SubdivisionСreateYear;
				subdivisionInDb.Faculty = subdivision.Faculty;
				_dbContext.Update(subdivisionInDb);
			}

			_dbContext.SaveChanges();
			return RedirectToAction(nameof(GetAllSubdivisions));
		}

		#endregion

		#region Lecturer

		[HttpGet]
		public IActionResult GetAllLecturers()
		{
			CStatic.Logger.Trace($"Start {nameof(GetAllLecturers)}");
			IncludeReferencedFieldsToLecturers();
			var allLecturers = _dbContext.Lecturers.ToList();
			return View(allLecturers);
		}

		[HttpGet]
		public IActionResult GetLecturerById(int id)
		{
			CStatic.Logger.Trace($"Start {nameof(GetLecturerById)}");
			var lecturer = _dbContext.Lecturers.Find(id);
			if (lecturer == null)
			{
				return StatusCode(404);
			}

			var subdivision = _dbContext.Subdivisions.Find(lecturer.SubdivisionId);
			if (subdivision != null)
			{
				lecturer.Subdivision = subdivision;
			}

			return View(lecturer);
		}

		[HttpGet]
		public IActionResult EditLecturer(int id)
		{
			CStatic.Logger.Trace($"Start {nameof(EditLecturer)}");
			var lecturer = _dbContext.Lecturers.Find(id);
			if (lecturer == null)
			{
				return StatusCode(404);
			}
			
			var allSubdivisions = _dbContext.Subdivisions.ToList();
			ViewBag.AllSubdivisions = allSubdivisions;

			return View(nameof(CreateLecturer), lecturer);
		}

		public IActionResult DeleteLecturer(int id)
		{
			CStatic.Logger.Trace($"Start {nameof(DeleteLecturer)}");
			var lecturer = _dbContext.Lecturers.Find(id);
			if (lecturer == null)
			{
				return StatusCode(404);
			}

			_dbContext.Lecturers.Remove(lecturer);
			_dbContext.SaveChanges();
			return RedirectToAction(nameof(GetAllLecturers));
		}

		[HttpGet]
		public IActionResult CreateLecturer()
		{
			CStatic.Logger.Trace($"Start {nameof(CreateLecturer)}");
			var newLecturer = new Lecturer();
			var allSubdivisions = _dbContext.Subdivisions.ToList();
			ViewBag.AllSubdivisions = allSubdivisions;
			return View(newLecturer);
		}

		[HttpPost]
		public IActionResult CreateLecturer(Lecturer lecturer)
		{
			CStatic.Logger.Trace($"Start {nameof(CreateLecturer)}");
			if (!ModelState.IsValid)
			{
				CStatic.Logger.Warn($"Method {nameof(CreateLecturer)}: model is invalid");
				return StatusCode(403);
			}

			var lecturerInDb = _dbContext.Lecturers.Find(lecturer.LecturerId);
			if (lecturerInDb == null)
			{
				_dbContext.Lecturers.Add(lecturer);
			}
			else
			{
				lecturerInDb.Surname = lecturer.Surname;
				lecturerInDb.FirstName = lecturer.FirstName;
				lecturerInDb.Patronymic = lecturer.Patronymic;
				lecturerInDb.Position = lecturer.Position;
				lecturerInDb.ScienceGrade = lecturer.ScienceGrade;
				lecturerInDb.Note = lecturer.Note;
				lecturerInDb.WorkStartDate = lecturer.WorkStartDate;
				lecturerInDb.Subdivision = lecturer.Subdivision;
				_dbContext.Lecturers.Update(lecturerInDb);
			}

			_dbContext.SaveChanges();
			return RedirectToAction(nameof(GetAllLecturers));
		}

		#endregion

		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}

		/// <summary>
		/// Заполнение связанного свойства Subdivision у преподавателей (временная замена include)
		/// </summary>
		private void IncludeReferencedFieldsToLecturers()
		{
			var lecturersSubdivisions = new HashSet<int>(_dbContext.Lecturers.Select(x => x.SubdivisionId));
			var allSubdivisions = _dbContext.Subdivisions.Where(x => lecturersSubdivisions.Contains(x.SubdivisionId)).ToDictionary(x => x.SubdivisionId, x => x);
			foreach (var lecturer in _dbContext.Lecturers)
			{
				if (lecturer.Subdivision == null)
				{
					lecturer.Subdivision = allSubdivisions[lecturer.SubdivisionId];
				}
			}
		}
	}
}
