using System;
namespace Fit.BusinessLogic
{
    public class Fitter
    {
        private int a;
        private int b;
        private Queue<int> queueSegments;

        public Fitter(int a, int b)
        {
            this.a = a;
            this.b = b;
            this.queueSegments = new Queue<int>();
        }


        private bool fitsThroughCurrentJoint(int s1, int s2)
        {
            bool ret = false;

            int secondSegmentWidth = s2;
            InputFormatter.swapIfNeeded(ref s1, ref s2);

            if (bothSegmentsSmallerThanSmallerEdge(s1, s2)) ret = false;

            // see picture for AE and EC
            double AE = Math.Sqrt(s1 * s1 - a * a);
            double EC = Math.Sqrt((b - AE) * (b - AE) + a * a);

            if ((s2 >= b && s1 >= a) ||
                                (AE >= b) ||
                                (EC <= s2))
            {
                ret = true;
            }
            if (queueSegments.Count == 0) return ret;
            return (ret == true? fitsThroughCurrentJoint(secondSegmentWidth, queueSegments.Dequeue()) : false);
        }

        public bool fits(List<int> listSegments)
        {
            if (listSegments.Count == 1)
                return fitsThroughSingleSegment(listSegments[0]);

            bool ret = true;
            this.queueSegments = new Queue<int>(listSegments);
            return ret && fitsThroughCurrentJoint(queueSegments.Dequeue(), queueSegments.Dequeue());
        }

        private bool fitsThroughSingleSegment(int segWidth)
        {
            return (segWidth >= a);
        }

        private bool bothSegmentsSmallerThanSmallerEdge(int s1, int s2)
        {
            return s1 < a || s2 < a;
        }
    }
}

