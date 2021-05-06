using System;

namespace Pipelineum
{
    /// <summary>
    /// Represents a link in a pipeline function chain.
    /// </summary>
    /// <typeparam name="TIn">The input type of this link.</typeparam>
    /// <typeparam name="TFirst">The input type of the first link.</typeparam>
    public interface IPipelineLink<TIn, in TFirst>
    {
        /// <summary>
        /// Add a function to the pipeline.
        /// </summary>
        /// <typeparam name="TOut">The output type of this link.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>The next pipeline link.</returns>
        IPipelineLink<TOut, TFirst> Next<TOut>(Func<TIn, TOut> func);

        /// <summary>
        /// Ends the pipeline chain.
        /// </summary>
        /// <returns>The pipeline function.</returns>
        Func<TFirst, TIn> End();
    }
}