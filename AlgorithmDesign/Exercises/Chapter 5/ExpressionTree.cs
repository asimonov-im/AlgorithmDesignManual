namespace AlgorithmDesign.Exercises.Chapter5
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlgorithmDesign.DataStructures;

    public static class ExpressionTree
    {
        public static int Evaluate(BinaryTreeNode<string> expression)
        {
            // Leaf nodes are always numbers
            if (expression.Left == null && expression.Right == null)
            {
                return int.Parse(expression.Data);
            }
            else
            {
                var op = BinaryOperator(expression.Data);
                var leftResult = Evaluate(expression.Left);
                var rightResult = Evaluate(expression.Right);

                return op(leftResult, rightResult);
            }
        }

        private static Func<int, int, int> BinaryOperator(string op)
        {
            switch (op)
            {
                case "*":
                    return (x, y) => x * y;
                case "/":
                    return (x, y) => x / y;
                case "+":
                    return (x, y) => x + y;
                case "-":
                    return (x, y) => x - y;
                default:
                    throw new ArgumentException("Unrecognized operator");
            }
        }
    }
}