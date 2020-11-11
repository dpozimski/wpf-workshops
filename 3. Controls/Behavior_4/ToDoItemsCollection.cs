using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ToDo.WPF.Core.Validators;

namespace ToDo.WPF.Core
{
    [TypeConverter(typeof(StringToDoItemsTypeConverter))]
    public class ToDoItemsCollection : ICollection<ToDoItemModel>, IEnumerable<ToDoItemModel>, IList, ICollection
    {
        private List<ToDoItemModel> _list = new List<ToDoItemModel>();

        public int Count => _list.Count;
        public bool IsReadOnly => false;
        public bool IsSynchronized => false;
        public object SyncRoot => null;
        public bool IsFixedSize => false;

        public object this[int index]
        {
            get => _list[index];
            set => _list[index] = (ToDoItemModel)value;
        }

        public ToDoItemsCollection() { }

        public ToDoItemsCollection(IEnumerable<ToDoItemModel> models)
        {
            _list = models.ToList();
        }

        public void Add(ToDoItemModel item) => _list.Add(item);

        public void AddRange(IEnumerable<ToDoItemModel> items) => _list.AddRange(items);

        public void Clear() => _list.Clear();

        public bool Contains(ToDoItemModel item) => _list.Contains(item);

        public IEnumerator<ToDoItemModel> GetEnumerator() => _list.GetEnumerator();

        public bool Remove(ToDoItemModel item) => _list.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        public void CopyTo(Array array, int index) => throw new NotImplementedException();

        public int Add(object value)
        {
            _list.Add((ToDoItemModel)value);
            return 1;
        }

        public bool Contains(object value) => _list.Contains((ToDoItemModel)value);

        public int IndexOf(object value) => _list.IndexOf((ToDoItemModel)value);

        public void Insert(int index, object value) => _list.Insert(index, (ToDoItemModel)value);

        public void Remove(object value) => _list.Remove((ToDoItemModel)value);

        public void RemoveAt(int index) => _list.RemoveAt(index);

        public void CopyTo(ToDoItemModel[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);
    }
}