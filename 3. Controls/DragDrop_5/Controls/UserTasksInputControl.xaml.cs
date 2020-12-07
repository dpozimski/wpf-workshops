using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo.WPF.Core.Controls
{
    /// <summary>
    /// Interaction logic for UserTasksInputControl.xaml
    /// </summary>
    public partial class UserTasksInputControl : UserControl
    {
        public event RoutedEventHandler AddEvent
        {
            add { btAddTask.Click += value; }
            remove { btAddTask.Click -= value; }
        }

        public static DependencyProperty InputProperty = DependencyProperty.Register(
            nameof(Input), typeof(ToDoItemsCollection), typeof(UserTasksInputControl));

        public ToDoItemsCollection Input
        {
            get => (ToDoItemsCollection)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public UserTasksInputControl()
        {
            InitializeComponent();
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            var model = e.Data.GetData(typeof(ToDoItemModel)) as ToDoItemModel;

            if(model != null)
            {
                var cloned = new ToDoItemModel() { Task = model.Task };
                Input = new ToDoItemsCollection(new[] { cloned });
            }
        }
    }
}
