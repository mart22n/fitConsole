using System;
namespace Fit.BusinessLogic
{
	public class InputFormatterTest
	{
        [Fact]
        public void if_second_smaller_first_theyAreSwapped()
        {
            int first = 6;
            int second = 5;
            InputFormatter.swapIfNeeded(ref first,ref second);
            Assert.Equal(5, first);
            Assert.Equal(6, second);
        }

        [Fact]
        public void if_second_greaterThan_first_theyAreNotSwapped()
        {
            int first = 5;
            int second = 6;
            InputFormatter.swapIfNeeded(ref first, ref second);
            Assert.Equal(5, first);
            Assert.Equal(6, second);
        }
    }
}

