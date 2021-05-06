# Pipelineum

Pipelineum is an open-source library for building simple, type-safe, pipeline functions for .NET.

## Example

```csharp
var func = Pipeline
    .Start<string>()    // declare first input type
    .Next(input =>      // input is string
    {
        return 5;       // output is int
    })
    .Next(input =>      // input is int
    {
        return true;    // output is bool
    })
    .Next(input =>      // input is bool
    {
        return Math.PI; // output is double
    })
    .Next(input =>      // input is double
    {
        return new { Message = "Hello, Pipelineum!" }; // output is anonymous type
    })
    .End();

// execute the pipeline function, remember the first input type was string...
var result = func("hello");

Console.WriteLine(result.Message) // Hello, Pipelineum!
```
