using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using Expression = System.Linq.Expressions.Expression;
using System.Linq;

namespace ToDo.WPF.Core.Behaviors
{
    public class DisableControlWhenFilterBehavior : Behavior<UIElement>
    {
        public static readonly DependencyProperty CollectionProperty = DependencyProperty.Register(
            nameof(Collection),
            typeof(IEnumerable<ToDoItemModel>),
            typeof(DisableControlWhenFilterBehavior),
            new PropertyMetadata(null, OnCollectionPropertyChanged));

        public IEnumerable<ToDoItemModel> Collection
        {
            get => (IEnumerable<ToDoItemModel>)GetValue(CollectionProperty);
            set => SetValue(CollectionProperty, value);
        }

        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register(
            nameof(Filter),
            typeof(string),
            typeof(DisableControlWhenFilterBehavior),
            new PropertyMetadata(null, OnFilterPropertyChanged));

        public string Filter
        {
            get => (string)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            UpdateControl();
        }

        private void UpdateControl()
        {
            if(AssociatedObject is null)
            {
                return;
            }

            if(Collection is null)
            {
                AssociatedObject.IsEnabled = false;
            }
            else if(string.IsNullOrEmpty(Filter))
            {
                AssociatedObject.IsEnabled = true;
            }
            else
            {
                var parameter = Expression.Parameter(typeof(ToDoItemModel), "task");
                var expression = System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(new[] { parameter }, null, Filter);
                var compiled = expression.Compile();

                var result = Collection.Any(t => (bool)compiled.DynamicInvoke(t));

                AssociatedObject.IsEnabled = result;
            }
        }

        private static void OnFilterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DisableControlWhenFilterBehavior)d;

            instance.UpdateControl();
        }

        private static void OnCollectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DisableControlWhenFilterBehavior)d;

            if(e.NewValue is IEnumerable<ToDoItemModel> newModels)
            {
                foreach(var model in newModels)
                {
                    model.PropertyChanged += (o, e) => instance.UpdateControl();
                }   
            }

            if (e.OldValue is IEnumerable<ToDoItemModel> oldModels)
            {
                foreach (var model in oldModels)
                {
                    model.PropertyChanged -= (o, e) => instance.UpdateControl();
                }
            }

            instance.UpdateControl();
        }
    }
}
