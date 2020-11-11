using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ToDo.WPF.Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ToDoItemModel> _todoItems = new List<ToDoItemModel>();

        public ToDoItemsCollection InputTasks { get; set; } = new ToDoItemsCollection();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btAddTask_Click(object sender, RoutedEventArgs e)
        {
            _todoItems.AddRange(InputTasks);

            UpdateLeftCounter();

            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(_todoItems);
        }

        private void cbTaskDone_Checked(object sender, RoutedEventArgs e)
        {
            UpdateLeftCounter();
        }

        private void btAll_Click(object sender, RoutedEventArgs e)
        {
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(_todoItems);
        }

        private void btActive_Click(object sender, RoutedEventArgs e)
        {
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(_todoItems.Where(ti => !ti.Done));
        }

        private void btCompleted_Click(object sender, RoutedEventArgs e)
        {
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(_todoItems.Where(ti => ti.Done));
        }

        private void UpdateLeftCounter()
        {
            tbLeftCounter.Text = $"{_todoItems.Count(m => !m.Done)} items left";
        }
    }
}
