using System;
using System.ComponentModel.DataAnnotations;
using ComTechNetCoreApp.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ComTechNetCoreApp.Models
{
	/// <summary>
	/// Кафедра
	/// </summary>
	public class Subdivision
	{
		/// <summary>
		/// Уникальный идентификатор кафедры.
		/// </summary>
		[HiddenInput(DisplayValue = false)]
		public int SubdivisionId { get; set; }

		/// <summary>
		/// Наименование кафедры.
		/// </summary>
		[Display(Name = "Наименование кафедры")]
		[Required]
		[StringLength(100)]
		public string SubdivisionName { get; set; }

		/// <summary>
		/// Год основания кафедры.
		/// </summary>
		[Display(Name = "Год основания кафедры")]
		[Required]
		public DateTime SubdivisionСreateYear { get; set; }

		/// <summary>
		/// Факультет.
		/// </summary>
		[Display(Name = "Факультет")]
		[Required]
		[EnumDataType(typeof(EFaculty))]
		public EFaculty Faculty { get; set; }
	}
}
