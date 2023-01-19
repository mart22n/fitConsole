using System;
namespace Fit.BusinessLogic
{
    public class Fitter
    {
        private int a;
        private int b;
        private Stack<int> stackSegments;

        public Fitter(int a, int b)
        {
            if (b < a) (a, b) = (b, a);
            this.a = a;
            this.b = b;
            this.stackSegments = new Stack<int>();
        }


        private bool fitsThroughCurrentJoint(int s1, int s2)
        {
            bool ret = false;

            if (s2 < s1) (s1, s2) = (s2, s1);

            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);

            if (bothSegmentsSmallerThanSmallerEdge(s1, s2)) ret = false;
            if ((s2 >= b && s1 >= a) ||
                                (AE >= b) ||
                                (EC <= s2))
            {
                ret = true;
            }
            if (stackSegments.Count == 0) return ret;
            if (stackSegments.Count == 1)
                return (ret == true? fitsThroughSingleSegment(stackSegments.Pop()) : false);
            return (ret == true? fitsThroughCurrentJoint(stackSegments.Pop(), stackSegments.Pop()) : false);
        }

        public bool fits(List<int> listSegments)
        {
            if (listSegments.Count == 1)
                return fitsThroughSingleSegment(listSegments[0]);

            bool ret = true;
            this.stackSegments = new Stack<int>(listSegments);
            return ret && fitsThroughCurrentJoint(stackSegments.Pop(), stackSegments.Pop());
        }

        private bool fitsThroughSingleSegment(int segWidth)
        {
            return (segWidth >= a);
        }

        //public bool fits(int s1)
        //{
        //    return (s1 >= a);

        //}

        //public bool fits(int s1, int s2)
        //{
        //    bool ret = false;
        //    double AE = Math.Sqrt(s1 * s1 - a * a);
        //    double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);

        //    if (bothSegmentsSmallerThanSmallerEdge(s1, s2)) ret = false;
        //    if ((s2 >= b && s1 >= a) ||
        //                        (AE >= b) ||
        //                        (EC <= s2))
        //    {
        //        ret = true;
        //    }
        //    if (joints.Count == 0) return true;
        //    return ret &&
        //        fits(joints.Pop(), joints.Pop());


        //}

        private bool bothSegmentsSmallerThanSmallerEdge(int s1, int s2)
        {
            return s1 < a || s2 < a;
        }
    }
}

