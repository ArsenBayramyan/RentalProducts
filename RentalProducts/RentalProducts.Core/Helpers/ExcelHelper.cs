using ClosedXML.Excel;
using RentalProducts.Core.CustomAttributes;
using RentalProducts.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace RentalProducts.Core.Helpers
{
	public static class ExcelHelper
	{
		public static byte[] ExportToExcel<T>(IList<T> data, string worksheetTitle)
		{
			var wb = new XLWorkbook();
			var wsh = wb.Worksheets.Add(worksheetTitle);
			var props = TypeExtensions.GetFilteredProperties(typeof(T));
			List<string> titles = new List<string>();
			for (int i = 0; i < props.Length; ++i)
			{
				var attr = (DisplayAttribute)Attribute.GetCustomAttribute(props[i], typeof(DisplayAttribute), true);
				titles.Add(attr?.Name);
			}

			var row = wsh.Row(1);
			var cell = wsh.Cell(1, 1);
			for (int i = 0; i < titles.Count; ++i)
			{
				cell.Value = titles[i];
				cell = cell.CellRight();
			}

			var headerCells = wsh.Range(1, 1, 1, titles.Count);
			var headerFont = headerCells.Style.Font;
			headerFont.Bold = true;

			decimal?[] totals = new decimal?[titles.Count];

			row = wsh.Row(2);

			if (data != null && data.Count > 0)
			{
				for (int i = 0; i < data.Count; ++i)
				{
					cell = wsh.Cell(i + 2, 1);
					for (int j = 0; j < props.Length; ++j)
					{
						var property = data[i].GetType().GetProperty(props[j].Name);
						var value = property.GetValue(data[i]);
						var displayFormat = (DisplayFormatAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayFormatAttribute));

						if (displayFormat != null)
						{
							if (value == null)
							{
								cell.SetValue(displayFormat.NullDisplayText);
							}
							else
							{
								cell.SetValue(string.Format(displayFormat.DataFormatString, value));
							}
						}
						else
						{
							cell.SetValue(value);
						}

						cell = cell.CellRight();
					}
				}
			}

			wsh.ColumnsUsed().AdjustToContents();
			MemoryStream ms = null;
			try
			{
				ms = new MemoryStream();
				wb.SaveAs(ms);
				return ms.ToArray();
			}
			finally
			{
				ms?.Dispose();
				wb.Dispose();
			}
		}
	}
}
