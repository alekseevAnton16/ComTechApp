using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ComTechNetCoreApp.Models
{
	public class Lecturer
	{
		private Subdivision _subdivision;

		/// <summary>
		/// Уникальный идентификатор преподавателя.
		/// </summary>
		[HiddenInput(DisplayValue = false)]
		public int LecturerId { get; set; }

		/// <summary>
		/// Уникальный идентификатор кафедры.
		/// </summary>
		[Required]
		[HiddenInput]
		public int SubdivisionId { get; set; }
		
		/// <summary>
		/// Дата начала работы на кафедре.
		/// </summary>
		[Display(Name = "Дата начала работы на кафедре")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime WorkStartDate { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Display(Name = "Фамилия")]
		[Required]
		[StringLength(70)]
		public string Surname { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Display(Name = "Имя")]
		[Required]
		[StringLength(70)]
		public string FirstName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Display(Name = "Отчество")]
		[StringLength(70)]
		public string Patronymic { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		[Display(Name = "Должность")]
		[Required]
		[StringLength(70, ErrorMessage = "Недопустимая длина", MinimumLength = 1)]
		public string Position { get; set; }

		/// <summary>
		/// Научное звание.
		/// </summary>
		[StringLength(100)]
		[Display(Name = "Научное звание")]
		public string ScienceGrade { get; set; }

		/// <summary>
		/// Дополнительные сведения.
		/// </summary>
		[StringLength(70)]
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
