using HotChocolate.Types;

namespace Foo
{
    public class HelloQueryTypeExtension : ObjectTypeExtension<HelloQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<HelloQuery> descriptor)
        {
            descriptor.Name("Query");
            descriptor.Field(query => query.SayHello())
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Name("sayHello")
                .UseSorting();
        }
    }
}
