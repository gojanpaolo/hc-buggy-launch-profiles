# hc-buggy-launch-profiles

In `src/Properties/launchSettings.json` you'll find two profiles


```javascript

"Working Profile": {
    "commandName": "Project"
},
"Buggy Profile": {
    "commandName": "Project",
    "environmentVariables": {
        "DOTNET_ENVIRONMENT": "Development"
    }
}
```

Goes without saying that one of these profiles works, the other doesn't.

Try it out yourself.

I've implemented the following query for you

```graphql
query {
    sayHello
}
```

With the **Working Profile** this query returns;


```json
{
    "data": {
        "sayHello": [
            "Hello",
            "World"
        ]
    }
}
```

With the **Buggy Profile** this query returns;

```json
{
    "errors": [
        {
            "message": "Unexpected Execution Error",
            "locations": [
                {
                    "line": 2,
                    "column": 5
                }
            ],
            "path": [
                "sayHello"
            ],
            "extensions": {
                "message": "Cannot resolve scoped service 'Foo.IMediator' from root provider.",
                "stackTrace": "   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteValidator.ValidateResolution(Type serviceType, IServiceScope scope, IServiceScope rootScope)\r\n   at Microsoft.Extensions.DependencyInjection.ServiceProvider.Microsoft.Extensions.DependencyInjection.ServiceLookup.IServiceProviderEngineCallback.OnResolve(Type serviceType, IServiceScope scope)\r\n   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)\r\n   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)\r\n   at lambda_method68(Closure , IServiceProvider )\r\n   at HotChocolate.Execution.Processing.DefaultActivator.CreateInstance(Type type)\r\n   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)\r\n   at HotChocolate.Execution.Processing.DefaultActivator.GetOrCreate(Type type)\r\n   at HotChocolate.Execution.Processing.DefaultActivator.GetOrCreate[T]()\r\n   at HotChocolate.Execution.Processing.MiddlewareContext.Resolver[T]()\r\n   at lambda_method47(Closure , IResolverContext )\r\n   at HotChocolate.Types.FieldMiddlewareCompiler.<>c__DisplayClass3_0.<<CreateResolverMiddleware>b__0>d.MoveNext()\r\n--- End of stack trace from previous location ---\r\n   at HotChocolate.Types.Sorting.QueryableSortMiddleware`1.InvokeAsync(IMiddlewareContext context)\r\n   at HotChocolate.Utilities.MiddlewareCompiler`1.ExpressionHelper.AwaitTaskHelper(Task task)\r\n   at HotChocolate.Execution.Processing.ResolverTask.ExecuteResolverPipelineAsync(CancellationToken cancellationToken)\r\n   at HotChocolate.Execution.Processing.ResolverTask.TryExecuteAsync(CancellationToken cancellationToken)"
            }
        }
    ]
}
```