namespace Pipelines
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
        public static IPipelineLink<TIn, TIn> Start<TIn>()
        {
            return new PipelineLink<TIn, TIn>();
        }
    }
}