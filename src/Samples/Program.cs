using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipelines;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
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

                    return new GetYourRecord(input, "Howdy cunt!");
                })
                .End();

            var result = func("hello");

            Console.WriteLine($"Output ({result.GetType().Name}): {result.TheInput} {result.Message}");
        }
    }

    record GetYourRecord(double TheInput, string Message);
}
