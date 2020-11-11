using System.Windows;

namespace ToDo.WPF.Core
{
    public class BaseWindow : Window
    {
        public static DependencyProperty ToDoItemsProperty = DependencyProperty.Register(nameof(ToDoItems), typeof(ToDoItemsCollection), typeof(MainWindow), new PropertyMetadata(new ToDoItemsCollection()));

        public ToDoItemsCollection ToDoItems
        {
            get => (ToDoItemsCollection)GetValue(ToDoItemsProperty);
            set => SetValue(ToDoItemsProperty, value);
        }
    }
}
