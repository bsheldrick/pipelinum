namespace Pipelineum
{
    /// <summary>
    /// Factory class to create new IPipelineLink instances.
    /// </summary>
    public static class Pipeline
    {
        /// <summary>
        /// Start a new pipeline with a specified input type.
        /// </summary>
        /// <typeparam name="TIn">The input type of the first pipeline link.</typeparam>
        /// <returns>The first pipeline link.</returns>
        public static IPipelineLink<TIn, TIn> Start<TIn>()
        {
            return new PipelineLink<TIn, TIn>();
        }

        /// <summary>
        /// Start a new context pipeline with a specified context type.
        /// </summary>
        /// <typeparam name="TContext">The context type of the pipeline.</typeparam>
        /// <returns>The pipeline link.</returns>
        public static IContextPipelineLink<TContext> StartContext<TContext>()
        {
            return new ContextPipelineLink<TContext>();
        }
    }
}