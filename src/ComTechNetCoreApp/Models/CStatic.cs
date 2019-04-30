using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using NLog;

namespace ComTechNetCoreApp.Models
{
	public static class CStatic
	{
		public static ILogger Logger = LogManager.GetCurrentClassLogger();

		public static string GetDisplayName(object enumValue)
		{
			return enumValue.GetType()
				.GetMember(enumValue.ToString())?.FirstOrDefault()?
				.GetCustomAttribute<DisplayAttribute>()?
				.Name;
		}
	}
}
