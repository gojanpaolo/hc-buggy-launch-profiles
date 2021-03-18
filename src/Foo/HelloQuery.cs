using System.Collections.Generic;
using System.Linq;
using HotChocolate;

namespace Foo
{
    public class HelloQuery
    {
        private readonly IMediator _mediator;

        public HelloQuery([Service] IMediator mediator)
        {
            _mediator = mediator;
        }

        public IQueryable<string> SayHello() => new List<string> { "Hello", "World"}.AsQueryable();
    }
}
