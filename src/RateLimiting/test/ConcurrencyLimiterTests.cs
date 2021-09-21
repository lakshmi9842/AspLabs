// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.Threading.RateLimiting.Test
{
    public class ConcurrencyLimiterTests
    {
        [Fact]
        public void CanAcquireResource()
        {
            var limiter = new ConcurrencyLimiter(new ConcurrencyLimiterOptions(1, QueueProcessingOrder.NewestFirst, 1));
            var lease = limiter.Acquire();

            Assert.True(lease.IsAcquired);
            Assert.False(limiter.Acquire().IsAcquired);

            lease.Dispose();

            Assert.True(limiter.Acquire().IsAcquired);
        }
    }
}
