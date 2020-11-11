using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.WPF.Core;

namespace ToDo.WPF.Core.Validators
{
    public class StringToDoItemsTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context,
				System.Globalization.CultureInfo culture, object value)
		{
			var str = (string)value;
			if(!string.IsNullOrEmpty(str))
            {
				var split = str.Split(", ");
				var models = split.Select(s => new ToDoItemModel() { Task = s });
				return new ToDoItemsCollection(models);
            }

			return new ToDoItemsCollection();
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || base.CanConvertFrom(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context,
				System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			return value == null ? null : string.Join(", ", ((ToDoItemsCollection)value).Select(ti => ti.Task));
		}
	}
}
