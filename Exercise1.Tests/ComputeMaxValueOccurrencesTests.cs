using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Exercise1;

namespace Exercise1.Tests
{
    public class ComputeMaxValueOccurrencesTests
    {
        [Theory]
        [InlineData(new[] { "2 3", "3 7", "4 1" }, 2)]
        [InlineData(new[] { "1 4", "2 3", "4 1" }, 1)]
        public void CountMaxComputesMaxValueOccurrencesCorrectly(string[] instructions, long expectedMaxValueCount)
        {
            var actualMaxValueCount = ComputeMaxValueOccurrences.CountMax(instructions.ToList());
            Assert.Equal(expectedMaxValueCount, actualMaxValueCount);
        }
    }
}
