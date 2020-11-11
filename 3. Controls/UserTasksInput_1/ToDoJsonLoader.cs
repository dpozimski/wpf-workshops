using System;
using System.IO;
using System.Text.Json;
using System.Windows.Markup;

namespace ToDo.WPF.Core
{
    public class ToDoJsonLoader : MarkupExtension
    {
        public string Source { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var content = File.ReadAllText(Source);
            var collection = JsonSerializer.Deserialize<ToDoItemsCollection>(content);

            return collection;
        }
    }
}
