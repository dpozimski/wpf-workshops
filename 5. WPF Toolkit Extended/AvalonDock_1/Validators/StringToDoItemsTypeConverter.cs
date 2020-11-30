using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ToDo.WPF.Core.Models;

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
				var entities = split.Select(s => new ToDoItem() { Task = s });
				var vms = entities.Select(s => new ToDoItemModel(s));
				var result = new ToDoItemModelCollection(vms);
				return result;
            }

			return new ObservableCollection<ToDoItemModel>();
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || base.CanConvertFrom(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context,
				System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			return value == null ? null : string.Join(", ", ((ToDoItemModelCollection)value).Select(ti => ti.Task));
		}
	}
}
