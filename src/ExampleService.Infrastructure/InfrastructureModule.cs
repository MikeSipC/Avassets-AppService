using Autofac;
using ExampleService.Core.Extensions;
using ExampleService.Infrastructure.Commands.Repository.Handlers;
using ExampleService.SharedKernel;
using ExampleServiceInfrastructure.Queries.Repository.Handlers;
using System;
using System.Linq;

namespace ExampleService.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Split your modules into multiple files (i.e. don't mix core with infra)

            var assembly = typeof(StringExtension).Assembly;




            // Support both int and guid identifiers (id) on database entities
            var entityTypes = assembly.GetTypes().Where(
                x => x.IsSubclassOf(typeof(BaseEntity<int>)));

            foreach (var type in entityTypes)
            {
                builder.RegisterType(typeof(AddCommandHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(UpdateCommandHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(AddOrUpdateCommandHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(DeleteCommandHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(DeleteRangeCommandHandler<,>).MakeGenericType(type, typeof(int)))
                    .AsImplementedInterfaces().PreserveExistingDefaults();

                builder.RegisterType(typeof(EntityAnyQueryHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(EntityCountQueryHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(EntityListQueryHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(EntityQueryHandler<,>).MakeGenericType(type, typeof(int))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
            }

            entityTypes = assembly.GetTypes().Where(
                x => x.IsSubclassOf(typeof(BaseEntity<Guid>)));

            foreach (var type in entityTypes)
            {
                builder.RegisterType(typeof(AddCommandHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(UpdateCommandHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(AddOrUpdateCommandHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(DeleteCommandHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(DeleteRangeCommandHandler<,>).MakeGenericType(type, typeof(Guid)))
                    .AsImplementedInterfaces().PreserveExistingDefaults();

                builder.RegisterType(typeof(EntityAnyQueryHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(EntityCountQueryHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(EntityListQueryHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
                builder.RegisterType(typeof(EntityQueryHandler<,>).MakeGenericType(type, typeof(Guid))).AsImplementedInterfaces()
                    .PreserveExistingDefaults();
            }
        }

        
    }
}