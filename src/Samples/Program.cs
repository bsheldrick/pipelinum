using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipelineum;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var func = Pipeline
                .Start<string>()
                .Next(input =>
                {
                    Console.WriteLine($"Input 1 ({input.GetType().Name}): {input}");
                    return 5;
                })
                .Next(input =>
                {
                    Console.WriteLine($"Input 2 ({input.GetType().Name}): {input}");
                    return true;
                })
                .Next(input =>
                {
                    Console.WriteLine($"Input 3 ({input.GetType().Name}): {input}");

                    if (input)
                    {
                        return Math.PI;
                    }

                    return 0;
                })
                .Next(input =>
                {
                    Console.WriteLine($"Input 4 ({input.GetType().Name}): {input}");

                    return new MyRecord(input, "Everything's a drum!");
                })
                .EndAsync();

            var result = await func("hello");
            Console.WriteLine($"Output ({result.GetType().Name}): {result.TheInput} {result.Message}");

            Func<int, string> f1 = input =>
            {
                Console.WriteLine($"Next ({input.GetType().Name}): {input}");

                return "Hello";
            };

            Console.WriteLine();
            var output = Pipeline
                .Start<int>()
                .Next(x => x + 1)
                .Next(x => x + 1)
                .Next(f1)
                .Next(x => x.ToString())
                .Run(5);

            Console.WriteLine($"Run output: {output}");

            var other = Pipeline
                .Start<string>()
                .Next(input =>
                {
                    Console.WriteLine($"Insert: {input}");
                    return 9;
                });
            var func2 = Pipeline
                .Start<int>()
                .Next(input => input.ToString())
                .Insert(other)
                .End();

            Console.WriteLine();
            var result2 = func2(12);
            Console.WriteLine($"Insert output: {result2}");

            var ctxFunc = Pipeline
                .StartContext<MyContext>()
                .Next(ctx =>
                {
                    Console.WriteLine($"Context: {ctx.StringProperty}");
                    ctx.StringProperty = "Hello, context";
                })
                .End();

            Console.WriteLine();
            var context = new MyContext { StringProperty = "Yo" };
            ctxFunc(context);
            Console.WriteLine($"Context output: {context.StringProperty}");
        }
    }

    record MyRecord(double TheInput, string Message);

    public class MyContext
    {
        public string StringProperty { get; set; }
    }
}
