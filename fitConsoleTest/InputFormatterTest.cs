using System;
namespace Fit.BusinessLogic
{
	public class InputFormatterTest
	{
        [Fact]
        public void if_b_smaller_a_theyAreSwapped()
        {
            string s = "3,2,2";
            InputFormatter f = new InputFormatter(s);
            Assert.Equal(2, f.a);
            Assert.Equal(3, f.b);
        }
    }
}

