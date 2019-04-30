using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComTechNetCoreApp.Models
{
	public class Lecturer
	{
		private Subdivision _subdivision;

		/// <summary>
		/// Уникальный идентификатор преподавателя.
		/// </summary>
		public int LecturerId { get; set; }

		/// <summary>
		/// Уникальный идентификатор кафедры.
		/// </summary>
		[Required]
		public int SubdivisionId { get; set; }
		
		/// <summary>
		/// Дата начала работы на кафедре.
		/// </summary>
		[Display(Name = "Дата начала работы на кафедре")]
		[Required]
		public DateTime WorkStartDate { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Display(Name = "Фамилия")]
		[Required]
		public string Surname { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Display(Name = "Имя")]
		[Required]
		public string FirstName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Display(Name = "Отчество")]
		public string Patronymic { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		[Display(Name = "Должность")]
		[Required]
		public string Position { get; set; }

		/// <summary>
		/// Научное звание.
		/// </summary>
		[Display(Name = "Научное звание")]
		public string ScienceGrade { get; set; }

		/// <summary>
		/// Дополнительные сведения.
		/// </summary>
		[Display(Name = "Дополнительные сведения")]
		public string Note { get; set; }

		/// <summary>
		/// Кафедра.
		/// </summary>
		[NotMapped]
		[Display(Name = "Кафедра")]
		public Subdivision Subdivision
		{
			get => _subdivision;
			set
			{
				if (_subdivision?.SubdivisionId != value?.SubdivisionId)
				{
					_subdivision = value;
					SubdivisionId = value?.SubdivisionId ?? -1;
				}
			}
		}
	}
}
