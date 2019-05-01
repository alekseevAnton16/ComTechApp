using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using NLog;

namespace ComTechNetCoreApp.Models
{
	public static class CStatic
	{
		public static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Получает значение аттрибута displayName переданного объекта.
		/// </summary>
		public static string GetDisplayName(object value) => value.GetType().GetMember(value.ToString())?.FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>()?.Name;
	}
}
