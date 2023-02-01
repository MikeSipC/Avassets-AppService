using System;
using System.Runtime.Serialization;

namespace ExampleServiceInfrastructure.Queries.Repository.Handlers
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(int code, string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RepositoryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}