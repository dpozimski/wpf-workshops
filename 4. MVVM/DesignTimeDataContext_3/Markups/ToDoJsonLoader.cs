using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Markup;
using ToDo.WPF.Core.Models;

namespace ToDo.WPF.Core.Markups
{
    public class ToDoJsonLoader : MarkupExtension
    {
        public string Source { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var content = File.ReadAllText(Source);
            var collection = JsonSerializer.Deserialize<ObservableCollection<ToDoItemModel>>(content);

            return collection;
        }
    }
}
