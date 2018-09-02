[assembly: WebActivator.PostApplicationStartMethod(typeof(MNS.Translator.UI.Site.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace MNS.Translator.UI.Site.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using MNS.Translator.Infra.CrossCutting;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleInjectorContainer.Register(container);
        }
    }
}