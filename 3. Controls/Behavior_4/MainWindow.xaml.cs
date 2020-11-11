using Microsoft.Win32;
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
        }

        private void btAddTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItems.AddRange(userTasksInputControl.Input);

            UpdateLeftCounter();

            lvToDoItems.ItemsSource = new ObservableCollection<ToDoItemModel>(ToDoItems);
        }

        private void cbTaskDone_Checked(object sender, RoutedEventArgs e)
        {
            UpdateLeftCounter();
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

        private void ButtonsLayout_ButtonClicked(object sender, string e)
        {
            switch(e)
            {
                case "btAll": btAll_Click(sender, null); break;
                case "btActive": btActive_Click(sender, null); break;
                case "btCompleted": btCompleted_Click(sender, null); break;
                case "btStats": btStats_Click(sender, null); break;
            };
        }
    }
}
