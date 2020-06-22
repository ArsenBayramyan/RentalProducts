using System;
using System.Collections.Generic;
using System.Text;

namespace RentalProducts.Core.CustomAttributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class SkipPropertyAttribute : Attribute
	{
	}
}
