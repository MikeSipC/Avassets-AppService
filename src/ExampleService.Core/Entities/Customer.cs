using System;
using System.Collections.Generic;
using ExampleService.SharedKernel;

namespace ExampleService.Core.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}