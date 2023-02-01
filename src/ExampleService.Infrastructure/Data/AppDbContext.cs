using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;

namespace ExampleService.Infrastructure.Data
{
    /// <summary>
    /// EF implementation example
    /// </summary>
    public partial class AppDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions<AppDbContext> options, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IMediator mediator)
            : base(options)
        {
            _loggerFactory = loggerFactory;
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //ValidateChanges();
            var rv = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return rv;
        }


        // Use FluentValidation
        //private void ValidateChanges()
        //{
        //    var changedEntities = ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged);
        //    var changedEntitiesByType = changedEntities.GroupBy(x => x.Entity.GetType());
        //    foreach (IGrouping<Type, EntityEntry> grouping in changedEntitiesByType)
        //    {
        //        var validatorType = typeof(IValidator<>).MakeGenericType(grouping.Key);
        //        IEnumerable<IValidator> validators;
        //        try
        //        {
        //            validators = _serviceProvider.GetServices(validatorType).Cast<IValidator>();
        //        }
        //        catch
        //        {
        //            return;
        //        }

        //        foreach (EntityEntry entityEntry in grouping)
        //        {
        //            var validationContextType = typeof(FluentValidation.ValidationContext<>).MakeGenericType(grouping.Key);
        //            var validationContext = (IValidationContext) Activator.CreateInstance(validationContextType, entityEntry.Entity);
        //            foreach (var validator in validators)
        //            {
        //                var validationResult = validator.Validate(validationContext);
        //                if (!validationResult.IsValid)
        //                {
        //                    throw new ValidationException(validationResult.Errors);
        //                }
        //            }
        //        }
        //    }
        //}

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
