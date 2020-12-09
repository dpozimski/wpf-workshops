using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using ToDo.WPF.Core.Models;

namespace ToDo.WPF.Core.Controls
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class TaskListView : ListView
    {
        public TaskListView()
        {
            InitializeComponent();
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            var listView = sender as ListView;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var item = VisualTreeHelper.HitTest(listView, Mouse.GetPosition(listView))?.VisualHit as FrameworkElement;
                if(item != null && item.DataContext != null)
                {
                    var data = new DataObject();
                    data.SetData(typeof(ToDoItemModel), item.DataContext);
                    DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }
        }
    }
}
