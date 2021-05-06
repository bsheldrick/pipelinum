
using System;
using System.Threading.Tasks;

namespace Pipelineum
{
    /// <summary>
    /// IPipelineLink extension methods.
    /// </summary>
    public static class PipelineLinkExtensions
    {
        /// <summary>
        /// Ends the pipeline chain and returns the pipeline function.
        /// </summary>
        /// <returns>The pipeline function as an awaitable Task.</returns>
        public static Func<TFirst, Task<TIn>> EndAsync<TIn, TFirst>(this IPipelineLink<TIn, TFirst> pipeline)
        {
            if (pipeline is null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            var func = pipeline.End();

            return input => Task.FromResult(func.Invoke(input));
        }

        /// <summary>
        /// Immediately ends and executes the pipeline function and returns the output.
        /// </summary>
        /// <param name="pipeline">The pipeline link.</param>
        /// <param name="input">The input to the pipeline function.</param>
        /// <returns>The output of the pipeline function.</returns>
        public static TOut Run<TOut, TFirst>(this IPipelineLink<TOut, TFirst> pipeline, TFirst input)
        {
            if (pipeline is null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            var func = pipeline.End();

            return func.Invoke(input);
        }

        /// <summary>
        /// Inserts another pipeline into the current pipeline.
        /// </summary>
        /// <param name="pipeline">The pipeline link.</param>
        /// <param name="other">The pipeline to insert.</param>
        public static IPipelineLink<TOut, TFirst> Insert<TIn, TOut, TFirst>(this IPipelineLink<TIn, TFirst> pipeline,
            IPipelineLink<TOut, TIn> other)
        {
            if (pipeline is null)
            {
                throw new ArgumentNullException(nameof(pipeline));
            }

            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherFunc = other.End();

            return pipeline.Next(otherFunc);
        }
    }
}