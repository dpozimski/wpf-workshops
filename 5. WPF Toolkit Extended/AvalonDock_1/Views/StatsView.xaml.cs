using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ToDo.WPF.Core.ViewModels;

namespace ToDo.WPF.Core.Views
{
    /// <summary>
    /// Interaction logic for StatsView.xaml
    /// </summary>
    public partial class StatsView : UserControl
    {
        private static readonly DependencyPropertyKey CustomContentPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(CustomContent),
            typeof(FrameworkElement),
            typeof(StatsView),
            new PropertyMetadata(null));

        public static readonly DependencyProperty CustomContentProperty = CustomContentPropertyKey.DependencyProperty;

        public FrameworkElement CustomContent
        {
            get => (FrameworkElement)GetValue(CustomContentProperty);
            protected set => SetValue(CustomContentPropertyKey, value);
        }

        public StatsView()
        {
            InitializeComponent();
            Unloaded += OnUnloaded;
            Loaded += OnLoaded;
            DataContextChanged += OnDataContextChanged;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            DataContextChanged -= OnDataContextChanged;
            Unloaded -= OnUnloaded;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is StatsViewModel vm)
            {
                vm.PropertyChanged += OnViewModelPropertyChanged;
            }
            
            if(e.OldValue is StatsViewModel oldVm)
            {
                oldVm.PropertyChanged -= OnViewModelPropertyChanged;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is StatsViewModel vm)
            {
                ApplyCustomContent(vm);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(StatsViewModel.XamlFile) && DataContext is StatsViewModel vm)
            {
                ApplyCustomContent(vm);
            }
        }

        private void ApplyCustomContent(StatsViewModel vm)
        {
            if(string.IsNullOrEmpty(vm.XamlFile))
            {
                return;
            }

            using var fs = new FileStream(vm.XamlFile, FileMode.Open);
            var control = (FrameworkElement)XamlReader.Load(fs);
            gridCustomContent.Content = control;
        }
    }
}
