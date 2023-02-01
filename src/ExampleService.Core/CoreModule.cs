using System;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Module = Autofac.Module;

namespace ExampleService.Core
{
    public class CoreModule : Module
    {
        private readonly Assembly[] _assemblies;

        public CoreModule(Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new TraceLogger());

            builder.RegisterAssemblyTypes(_assemblies)
                .Where(t =>
                    t.Name.EndsWith("UseCase", StringComparison.Ordinal) ||
                    t.Name.EndsWith("Service", StringComparison.Ordinal) ||
                    t.Name.EndsWith("Helper", StringComparison.Ordinal) ||
                    t.Name.EndsWith("Provider", StringComparison.Ordinal) ||
                    t.Name.EndsWith("Query", StringComparison.Ordinal) ||
                    t.Name.EndsWith("Repository", StringComparison.Ordinal) ||
                    t.Name.EndsWith("Validator", StringComparison.Ordinal)
                    )
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TraceLogger))
                .InstancePerLifetimeScope()
                .PreserveExistingDefaults();
        }
    }
}