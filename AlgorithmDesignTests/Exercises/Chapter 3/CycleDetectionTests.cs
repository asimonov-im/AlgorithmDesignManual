using System;
using AlgorithmDesign.DataStructures;
using AlgorithmDesign.Exercises.Chapter3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmDesignTests.Exercises
{
    [TestClass]
    public class CycleDetectionTests
    {
        [TestMethod]
        public void ListWithNoCycleIsHandledCorrectly()
        {
            var list = new ListNode<int>(1)
            {
                Next = new ListNode<int>(2)
                {
                    Next = new ListNode<int>(3)
                }
            };

            var cycle = CycleDetection.FindCycle(list);

            Assert.IsNull(cycle);
        }

        [TestMethod]
        public void SimpleCycleIsDetected()
        {
            var node = new ListNode<int>(1);
            node.Next = node;

            var cycle = CycleDetection.FindCycle(node);

            Assert.AreEqual(node, cycle);
        }

        [TestMethod]
        public void LongerCycleIsDetected()
        {
            var a = new ListNode<int>(1);
            var b = new ListNode<int>(2);
            var c = new ListNode<int>(3);
            var d = new ListNode<int>(4);
            var e = new ListNode<int>(5);
            var f = new ListNode<int>(6);

            a.Next = b;
            b.Next = c;
            c.Next = d;
            d.Next = e;
            e.Next = f;
            f.Next = d;

            var cycle = CycleDetection.FindCycle(a);

            Assert.AreEqual(d, cycle);
        }
    }
}
