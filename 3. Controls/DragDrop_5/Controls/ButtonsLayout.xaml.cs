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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo.WPF.Core.Controls
{
    /// <summary>
    /// Interaction logic for ButtonsLayout.xaml
    /// </summary>
    public partial class ButtonsLayout : StackPanel
    {
        public static readonly DependencyProperty OrderProperty = DependencyProperty.RegisterAttached(
              "Order",
              typeof(int),
              typeof(ButtonsLayout),
              new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender, OnOrderPropertyChanged)
            );

        public static void SetOrderProperty(UIElement element, int value)
        {
            element.SetValue(OrderProperty, value);
        }

        public static int GetOrderProperty(UIElement element)
        {
            return (int)element.GetValue(OrderProperty);
        }

        public event EventHandler<string> ButtonClicked;

        public ButtonsLayout()
        {
            InitializeComponent();

            Unloaded += OnUnloaded;
            Loaded += OnLoaded;
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Unloaded -= OnUnloaded;
            Loaded -= OnLoaded;

            var buttons = Children.OfType<Button>();

            foreach (var button in buttons)
            {
                button.Click -= OnButtonClicked;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var buttons = Children.OfType<Button>();

            foreach (var button in buttons)
            {
                button.Click += OnButtonClicked;
            }
        } 

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(this, (string)((Button)sender).Tag);
        }

        private static void OnOrderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Control)d;
            var order = e.NewValue;
            var parent = (ButtonsLayout)control.Parent;

            var elements = parent.Children.Cast<UIElement>()
                .OrderBy(c => GetOrderProperty(c))
                .ToList();

            parent.Children.Clear();
            
            foreach(var element in elements)
            {
                parent.Children.Add(element);
            }
        }
    }
}
