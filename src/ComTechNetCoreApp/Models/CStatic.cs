using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ComTechNetCoreApp.Models
{
	public static class CStatic
	{
		public static string GetDisplayName(Enum enumValue)
		{
			return enumValue.GetType()?
				.GetMember(enumValue.ToString())?[0]?
				.GetCustomAttribute<DisplayAttribute>()?
				.Name;
		}
	}
}
