using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ToDo.WPF.Core.Validators;

namespace ToDo.WPF.Core.Models
{
    [TypeConverter(typeof(StringToDoItemsTypeConverter))]
    public class ToDoItemModelCollection : ObservableCollection<ToDoItemModel>
    {
        public ToDoItemModelCollection()
        {

        }

        public ToDoItemModelCollection(IEnumerable<ToDoItemModel> collection) : base(collection)
        {

        }
    }
}
