using RentalProducts.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RentalProducts.Core.Extensions
{
	public static class TypeExtensions
	{
		public static PropertyInfo[] GetFilteredProperties(this Type type)
		{
			var properties = type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(SkipPropertyAttribute), true).Length == 0);

			var ordered = properties.Select(x => new
			{
				Property = x,
				Attribute = (DisplayAttribute)Attribute.GetCustomAttribute(x, typeof(DisplayAttribute), true)
			}).OrderBy(x => x.Attribute?.Order).Select(c => c.Property);

			return ordered.ToArray();
		}
	}
}
