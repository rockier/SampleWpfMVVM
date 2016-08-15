using Ninject;
using Sample.Entities.Interfaces;
using System;

namespace Sample.WPFApp.Implementation
{
    public class ViewModelResolver : IViewModelResolver
    {
        public object Resolve(string viewModelName)
        {
            var form =
                Type.GetType(
                    string.Format("Sample.Entities.ViewModels.{0}, Sample.Entities", viewModelName), true);
            var o = App.Container.Get(form);

            return o;
        }
    }
}
