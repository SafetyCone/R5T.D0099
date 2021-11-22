using System;

using R5T.D0099.A001;


namespace System
{
    public static class IServiceAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IServiceAggregationIncrement other)
            where T : IServiceAggregationIncrement
        {
        
        }
    }
}