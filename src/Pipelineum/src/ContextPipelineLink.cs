using System;

namespace Pipelineum
{
    internal class ContextPipelineLink<TContext> : PipelineLink<TContext, TContext>, IContextPipelineLink<TContext>
    {
        internal ContextPipelineLink(PipelineLink prev = null)
            : base(prev)
        { }

        public IContextPipelineLink<TContext> Next(Action<TContext> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            Func = ctx =>
            {
                func.Invoke((TContext)ctx);

                if (NextLink?.Func is null)
                {
                    return ctx;
                }

                return NextLink.Func.Invoke(ctx);
            };

            return new ContextPipelineLink<TContext>(this);
        }

        Action<TContext> IContextPipelineLink<TContext>.End()
        {
            var link = GetFirstPipelineLink();

            return ctx =>
            {
                link.Func.Invoke(ctx);
            };
        }
    }
}