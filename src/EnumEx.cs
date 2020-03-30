using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gInk
{
	public static class EnumExtensions
	{
		public static T[] GetEnums<T>()
		{
			return (T[])Enum.GetValues(typeof(T));
		}
		public static string GetDescription(this Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			if (fi != null)
			{
				DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

				if (attributes.Length > 0)
				{
					return attributes[0].Description;
				}
			}

			return value.ToString();
		}
		public static string[] GetEnumDescriptions<T>(int skip = 0)
		{
			return Enum.GetValues(typeof(T)).OfType<Enum>().Skip(skip).Select(x => x.GetDescription()).ToArray();
		}
	}
}
