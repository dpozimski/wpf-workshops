using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ToDo.WPF.Core.Models;

namespace ToDo.WPF.Core.Controls
{
    /// <summary>
    /// Interaction logic for UserTasksInputControl.xaml
    /// </summary>
    public partial class UserTasksInputControl : UserControl
    {
        public static readonly RoutedEvent AddEvent =
           EventManager.RegisterRoutedEvent("Add", RoutingStrategy.Bubble,
           typeof(RoutedEventHandler), typeof(UserTasksInputControl));

        public event RoutedEventHandler Add
        {
            add { AddHandler(AddEvent, value); }
            remove { RemoveHandler(AddEvent, value); }
        }

        public static DependencyProperty InputProperty = DependencyProperty.Register(
            nameof(Input), typeof(ToDoItemModelCollection), typeof(UserTasksInputControl));

        public ToDoItemModelCollection Input
        {
            get => (ToDoItemModelCollection)GetValue(InputProperty);
            set => SetValue(InputProperty, value);
        }

        public UserTasksInputControl()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AddEvent));
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            var listView = sender as ListView;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var item = VisualTreeHelper.HitTest(listView, Mouse.GetPosition(listView))?.VisualHit as FrameworkElement;
                if (item != null && item.DataContext != null)
                {
                    var data = new DataObject();
                    data.SetData(typeof(ToDoItemModel), item.DataContext);
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }
        }
    }
}
