using Microsoft.Win32;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo.WPF.Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(ToDoItems);
            RegisterPropertyChangedListener(ToDoItems);
            UpdateLeftCounter();
        }

        private void btAddTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItems.AddRange(userTasksInputControl.Input);

            RegisterPropertyChangedListener(userTasksInputControl.Input);
            UpdateLeftCounter();

            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(ToDoItems);
        }

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(ToDoItemModel.Done))
            {
                UpdateLeftCounter();
            }
        }

        private void btAll_Click(object sender, RoutedEventArgs e)
        {
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(ToDoItems);
        }

        private void btActive_Click(object sender, RoutedEventArgs e)
        {
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(ToDoItems.Where(ti => !ti.Done));
        }

        private void btCompleted_Click(object sender, RoutedEventArgs e)
        {
            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(ToDoItems.Where(ti => ti.Done));
        }

        private void UpdateLeftCounter()
        {
            tbLeftCounter.Value = ToDoItems.Count(m => !m.Done).ToString();
        }

        private void btStats_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();

            if(result == true)
            {
                var statisticsWindow = new StatisticsWindow(fileDialog.FileName, ToDoItems);
                statisticsWindow.Owner = this;
                statisticsWindow.Show();
            }
        }

        private void RegisterPropertyChangedListener(IEnumerable<ToDoItemModel> models)
        {
            foreach (var model in models)
            {
                model.PropertyChanged += OnModelPropertyChanged;
            }
        }
    }
}
