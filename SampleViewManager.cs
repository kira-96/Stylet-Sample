using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace WpfSample
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class ViewModelAttribute : Attribute
    {
        public ViewModelAttribute(Type viewModel)
        {
            ViewModel = viewModel;
        }

        public Type ViewModel { get; }
    }

    public class SampleViewManager : ViewManager
    {
        // Dictionary of ViewModel type -> View type
        private readonly Dictionary<Type, Type> viewModelToViewMapping;

        public SampleViewManager(ViewManagerConfig config) : base(config)
        {
            var mappings = from type in ViewAssemblies.SelectMany(x => x.GetExportedTypes())
                           let attribute = type.GetCustomAttribute<ViewModelAttribute>()
                           where attribute != null && typeof(UIElement).IsAssignableFrom(type)
                           select new { View = type, ViewModel = attribute.ViewModel };

            viewModelToViewMapping = mappings.ToDictionary(x => x.ViewModel, x => x.View);
        }

        protected override Type LocateViewForModel(Type modelType)
        {
            // bug: Could not find MessageBoxViewModel
            if (!viewModelToViewMapping.TryGetValue(modelType, out Type viewType))
                throw new Exception($"Could not find View for ViewModel {modelType.Name}");
            return viewType;
        }
    }
}
