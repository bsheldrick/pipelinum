using System;
using System.Threading.Tasks;

namespace Pipelines
{
    /// <summary>
    /// Represents a link in a pipeline delegate chain.
    /// </summary>
    /// <typeparam name="TIn">The input type of this link.</typeparam>
    /// <typeparam name="TFirst">The input type of the first link.</typeparam>
    public interface IPipelineLink<TIn, in TFirst>
    {
        /// <summary>
        /// Add a function to the delegate chain.
        /// </summary>
        /// <typeparam name="TOut">The output type of this link.</typeparam>
        /// <param name="func">The function.</param>
        IPipelineLink<TOut, TFirst> Next<TOut>(Func<TIn, TOut> func);

        /// <summary>
        /// Ends the delegate chain and returns the first input function.
        /// </summary>
        Func<TFirst, TIn> End();

        /// <summary>
        /// Ends the delegate chain and returns the first input function as an awaitable Task.
        /// </summary>
        Func<TFirst, Task<TIn>> EndAsync();
    }
}