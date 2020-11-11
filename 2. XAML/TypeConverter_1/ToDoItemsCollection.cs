using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ToDo.WPF.Core
{
    [TypeConverter(typeof(StringToDoItemsTypeConverter))]
    public class ToDoItemsCollection : IEnumerable<ToDoItemModel>
    {
        private List<ToDoItemModel> _list = new List<ToDoItemModel>();

        public ToDoItemsCollection() { }

        public ToDoItemsCollection(IEnumerable<ToDoItemModel> models)
        {
            _list = models.ToList();
        }

        public IEnumerator<ToDoItemModel> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();
    }
}