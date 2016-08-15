using Ninject;
using Ninject.Modules;
using Sample.Entities.Implementation;
using Sample.Entities.Interfaces;
using Sample.Entities.ViewModels;
using System.Configuration;

namespace Sample.WPFApp.Implementation
{
    public class WpfNinjectModule : INinjectModule
    {
        private IKernel _kernel;

        public IKernel Kernel
        {
            get { return _kernel; }
        }

        public void OnLoad(IKernel kernel)
        {
            _kernel = kernel;
            kernel.Bind<MainWindow>().To<MainWindow>();
            kernel.Bind<IViewResolver>().To<ViewResolver>();

            var host = ConfigurationManager.AppSettings["ServerHostName"] ?? "http://localhost";
            var port = ConfigurationManager.AppSettings["ServerPort"] ?? "50515";

            kernel.Bind<IDataProvider>().To<WebApiDataProvider>().WithConstructorArgument("host", host).WithConstructorArgument("port", port);

            kernel.Bind<MainFormDatasVm>().To<MainFormDatasVm>();
            kernel.Bind<CustomersVm>().To<CustomersVm>();
        }

        public void OnUnload(IKernel kernel)
        {
            _kernel = null;
        }

        public void OnVerifyRequiredModules()
        {
        }

        public string Name
        {
            get { return "Sample.WpfApp"; }
        }
    }
}
