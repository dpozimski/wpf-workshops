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

namespace ToDo.WPF.Core
{
    /// <summary>
    /// Interaction logic for LeftCounterControl.xaml
    /// </summary>
    [ContentProperty(nameof(Value))]
    public partial class LeftCounterControl : UserControl
    {
        public static DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value), typeof(string), typeof(LeftCounterControl));

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public LeftCounterControl()
        {
            InitializeComponent();
        }
    }
}
