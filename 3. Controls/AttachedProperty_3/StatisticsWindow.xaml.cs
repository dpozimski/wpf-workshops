using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace ToDo.WPF.Core
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        private static readonly DependencyPropertyKey AllTasksCountPropertyKey = DependencyProperty.RegisterReadOnly(nameof(AllTasksCount), 
            typeof(int), typeof(StatisticsWindow), new PropertyMetadata(0));

        public static readonly DependencyProperty AllTasksCountProperty = AllTasksCountPropertyKey.DependencyProperty;

        public int AllTasksCount
        {
            get => (int)GetValue(AllTasksCountProperty);
            protected set => SetValue(AllTasksCountProperty, value);
        }

        private static readonly DependencyPropertyKey ActiveTasksCountPropertyKey = DependencyProperty.RegisterReadOnly(nameof(ActiveTasksCount),
            typeof(int), typeof(StatisticsWindow), new PropertyMetadata(0));

        public static readonly DependencyProperty ActiveTasksCountProperty = ActiveTasksCountPropertyKey.DependencyProperty;

        public int ActiveTasksCount
        {
            get => (int)GetValue(ActiveTasksCountProperty);
            protected set => SetValue(ActiveTasksCountProperty, value);
        }

        private static readonly DependencyPropertyKey CompletedTasksCountPropertyKey = DependencyProperty.RegisterReadOnly(nameof(CompletedTasksCount),
            typeof(int), typeof(StatisticsWindow), new PropertyMetadata(0));

        public static readonly DependencyProperty CompletedTasksCountProperty = CompletedTasksCountPropertyKey.DependencyProperty;

        public int CompletedTasksCount
        {
            get => (int)GetValue(CompletedTasksCountProperty);
            protected set => SetValue(CompletedTasksCountProperty, value);
        }

        private readonly string _xamlFile;
        private readonly ToDoItemsCollection _collection;

        public StatisticsWindow(string xamlFile, ToDoItemsCollection collection)
        {
            _xamlFile = xamlFile;
            _collection = collection;
            InitializeComponent();    
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            SetValue(ActiveTasksCountPropertyKey, _collection.Count(i => !i.Done));
            SetValue(CompletedTasksCountPropertyKey, _collection.Count(i => i.Done));
            SetValue(AllTasksCountPropertyKey, _collection.Count);

            using var fs = new FileStream(_xamlFile, FileMode.Open);
            var control = (FrameworkElement)XamlReader.Load(fs);
            control.DataContext = this;
            gridCustomContent.Content = control;
        }
    }
}
