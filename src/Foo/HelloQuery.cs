using System.Collections.Generic;
using System.Linq;
using HotChocolate;

namespace Foo
{
    public class HelloQuery
    {
        public IQueryable<string> SayHello([Service] IMediator mediator) => new List<string> { "Hello", "World" }.AsQueryable();
    }
}
