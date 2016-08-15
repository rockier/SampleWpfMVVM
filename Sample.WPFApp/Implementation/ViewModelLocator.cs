using Sample.Entities.Interfaces;
using System.Dynamic;

namespace Sample.WPFApp.Implementation
{
    public class ViewModelLocator : DynamicObject
    {
        public ViewModelLocator()
        {
            Resolver = null;
        }

        public IViewModelResolver Resolver { get; set; }

        public object this[string viewModelName]
        {
            get { return Resolver?.Resolve(viewModelName); }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];

            return true;
        }
    }
}
