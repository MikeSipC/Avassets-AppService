using System;
using System.Linq;
using Castle.DynamicProxy;
using Serilog;

namespace ExampleService.Core
{
    public class TraceLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation == null) throw new Exception(nameof(invocation));
            var logger = Log.ForContext(invocation.TargetType);

            logger.Information(
                $"Calling method {invocation.Method.Name} with parameters {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())}... ");

            invocation.Proceed();

            logger.Information($"Done: result was {invocation.ReturnValue}.");
        }
    }
}