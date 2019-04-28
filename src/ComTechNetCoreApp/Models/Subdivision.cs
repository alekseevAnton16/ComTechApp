using System.ComponentModel.DataAnnotations;
using ComTechNetCoreApp.Models.Enums;

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
		public int SubdivisionId { get; set; }

		/// <summary>
		/// Наименование кафедры.
		/// </summary>
		[Display(Name = "Наименование кафедры")]
		[Required]
		public string SubdivisionName { get; set; }

		/// <summary>
		/// Год основания кафедры.
		/// </summary>
		[Display(Name = "Год основания кафедры")]
		[Required]
		public int SubdivisionСreateYear { get; set; }

		/// <summary>
		/// Факультет.
		/// </summary>
		[Display(Name = "Факультет")]
		[Required]
		public EFaculty Faculty { get; set; }
	}
}
