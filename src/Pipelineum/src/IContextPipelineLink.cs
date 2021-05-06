using System;

namespace Pipelineum
{
    /// <summary>
    /// Represents a link in a context pipeline action chain.
    /// </summary>
    /// <typeparam name="TContext">The context type of this link.</typeparam>
    public interface IContextPipelineLink<TContext>
    {
        /// <summary>
        /// Add an action to the pipeline.
        /// </summary>
        /// <param name="func">The action.</param>
        /// <returns>The next context pipeline link.</returns>
        IContextPipelineLink<TContext> Next(Action<TContext> func);

        /// <summary>
        /// Ends the pipeline chain.
        /// </summary>
        /// <returns>The pipeline action.</returns>
        Action<TContext> End();
    }
}