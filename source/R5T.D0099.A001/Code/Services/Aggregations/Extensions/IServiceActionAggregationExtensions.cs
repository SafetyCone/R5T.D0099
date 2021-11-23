using System;

using R5T.D0099.A001;


namespace System
{
    public static class IServiceActionAggregationExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceActionAggregation other)
            where T : IServiceActionAggregation
        {
            (aggregation as IServiceActionAggregationIncrement).FillFrom(other);

            return aggregation;
        }
    }
}