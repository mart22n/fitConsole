using System;
using Fit.BusinessLogic;
namespace FitterTest
{
	public class FitterTest
    { 
        /*
         * testcases for zero joints. 
         */
        [Fact]
        public void if_a_smaller_b_smaller_s1_fits()
        {
            var l = new List<int>() { 4 };
            Fitter f = new Fitter(2, 3);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_b_equals_s1_fits()
        {
            var l = new List<int>() { 3 };
            Fitter f = new Fitter(2, 3);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_s1_smaller_b_fits()
        {
            var l = new List<int>() { 3 };
            Fitter f = new Fitter(2, 4);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_equal_s1_smaller_b_fits()
        {
            var l = new List<int>() { 2 };
            Fitter f = new Fitter(2, 3);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_a_smaller_b_noFit()
        {
            var l = new List<int>() { 2 };
            Fitter f = new Fitter(3, 4);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_a_equal_b_smaller_s1_fits()
        {
            var l = new List<int>() { 4 };
            Fitter f = new Fitter(2, 3);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_equal_b_equal_s2_()
        {
            var l = new List<int>() { 2 };
            Fitter f = new Fitter(2, 2);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_a_equal_b()
        {
            var l = new List<int>() { 2 };
            Fitter f = new Fitter(3, 3);
            Assert.False(f.fits(l));
        }

        /*
         * testcases for multiple joints - no rotation
         */
        [Fact]
        public void if_allJointsTooSmall_noFit()
        {
            var l = new List<int>() { 4, 3, 2 };
            Fitter f = new Fitter(5, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_allJointsBigEnough_fits()
        {
            var l = new List<int>() { 7, 8, 7 };
            Fitter f = new Fitter(5, 6);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_onlyFirstJointTooSmall_noFit()
        {
            var l = new List<int>() { 4, 7, 8 };
            Fitter f = new Fitter(5, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_onlySecondJointTooSmall_noFit()
        {
            var l = new List<int>() { 7, 4, 8 };
            Fitter f = new Fitter(5, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_onlyThirdJointTooSmall_noFit()
        {
            var l = new List<int>() { 7, 8, 4 };
            Fitter f = new Fitter(5, 6);
            Assert.False(f.fits(l));
        }

        /*
         * testcases for a single joint - no rotation
         */
        [Fact]
		public void if_a_smaller_b_smaller_s1_smaller_s2_fits()
		{
            var l = new List<int>() { 7, 8 };
            Fitter f = new Fitter(5, 6);
            Assert.True(f.fits(l));
		}

        [Fact]
        public void if_a_smaller_b_smaller_s1_equals_s2_fits()
        {
            var l = new List<int>() { 7, 7 };
            Fitter f = new Fitter(5, 6);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_b_equals_s1_smaller_s2_fits()
        {
            var l = new List<int>() { 6, 7 };
            Fitter f = new Fitter(5, 6);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_s1_smaller_b_smaller_s2_fits()
        {
            var l = new List<int>() { 6, 8 };
            Fitter f = new Fitter(5, 7);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_equals_s1_smaller_b_smaller_s2_fits()
        {
            var l = new List<int>() { 5, 8 };
            Fitter f = new Fitter(5, 7);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_a_smaller_b_smaller_s2_noFit()
        {
            var l = new List<int>() { 5, 8 };
            Fitter f = new Fitter(6, 7);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_b_equals_s1_equals_s2_fits()
        {
            var l = new List<int>() { 6, 6 };
            Fitter f = new Fitter(5, 6);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_s1_equals_b_equals_s2_fits()
        {
            var l = new List<int>() { 6, 7 };
            Fitter f = new Fitter(5, 7);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_equals_s1_smaller_s2_smaller_b_noFit()
        {
            var l = new List<int>() { 5, 6 };
            Fitter f = new Fitter(5, 7);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_a_equals_s1_equals_s2_smaller_b_noFit()
        {
            var l = new List<int>() { 5, 5 };
            Fitter f = new Fitter(5, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_a_equals_s2_smaller_b_noFit()
        {
            var l = new List<int>() { 5, 5 };
            Fitter f = new Fitter(5, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_s2_smaller_a_smaller_b_noFit()
        {
            var l = new List<int>() { 5, 6 };
            Fitter f = new Fitter(7, 8);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_s1_equals_s2_smaller_a_smaller_b_noFit()
        {
            var l = new List<int>() { 5, 5};
            Fitter f = new Fitter(6, 7);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_a_equals_b_smaller_s1_smaller_s2_Fits()
        {
            var l = new List<int>() { 6, 7 };
            Fitter f = new Fitter(5, 5);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_equals_b_equals_s1_smaller_s2_Fits()
        {
            var l = new List<int>() { 5, 6 };
            Fitter f = new Fitter(5, 5);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_a_equals_b_smaller_s2_noFit()
        {
            var l = new List<int>() { 5, 7 };
            Fitter f = new Fitter(6, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_a_equals_b_equals_s2_noFit()
        {
            var l = new List<int>() { 5, 6 };
            Fitter f = new Fitter(6, 6);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_s1_smaller_s2_smaller_a_equals_b_noFit()
        {
            var l = new List<int>() { 5, 6 };
            Fitter f = new Fitter(7, 7);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_a_equals_b_equals_s1_equals_s2_Fits()
        {
            var l = new List<int>() { 5, 5 };
            Fitter f = new Fitter(5, 5);
            Assert.True(f.fits(l));
        }

        /* Testcases for a single joint - rotation
         */
        [Fact]
        public void if_a_smaller_s1_and_EC_smaller_s2_then_s2_smaller_b()
        {
            int s1 = 5000;
            int a = 4000;
            int b = 6000;
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);
            var l = new List<int>() { s1, (int)EC + 1 };

            Fitter f = new Fitter(a, b);
            Assert.True(((int)EC + 1) < b);
        }

        [Fact]
        public void if_a_smaller_s1_and_EC_smaller_s2_smaller_b_fits()
        {
            int s1 = 5000;
            int a = 4000;
            int b = 6000;
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);
            var l = new List<int>() { s1, (int)EC + 1 };

            Fitter f = new Fitter(a, b);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_a_smaller_s1_and_EC_greater_s2_smaller_b_noFit()
        {
            int s1 = 5000;
            int a = 4000;
            int b = 6000;
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);
            var l = new List<int>() { s1, (int)EC - 1 };

            Fitter f = new Fitter(a, b);
            Assert.False(f.fits(l));
        }



        /* Testcases for multiple joints - rotation
        */
        [Fact]
        public void if_onlyOneJointABitTooSmall_noFit()
        {
            int s1 = 5000;
            int a = 4000;
            int b = 6000;
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);
            var l = new List<int>() { s1, (int)EC - 1, 7000, 7000 };

            Fitter f = new Fitter(a, b);
            Assert.False(f.fits(l));
        }

        [Fact]
        public void if_rotationNeededInOnlyOneJoint_fits()
        {
            int s1 = 5000;
            int a = 4000;
            int b = 6000;
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);
            var l = new List<int>() { s1, (int)EC + 1, 7000, 7000};

            Fitter f = new Fitter(a, b);
            Assert.True(f.fits(l));
        }

        [Fact]
        public void if_rotationNeededInAllJoints_fits()
        {
            int s1 = 5000;
            int a = 4000;
            int b = 6000;
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);
            // here we have 3 joints where the parcel very "narrowly" fits through
            var l = new List<int>() { s1, (int)EC + 1, 5000,  (int)EC + 1 , 5000 };

            Fitter f = new Fitter(a, b);
            Assert.True(f.fits(l));
        }


    }
}

