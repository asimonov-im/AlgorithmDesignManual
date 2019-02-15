namespace AlgorithmDesign.Exercises.Chapter5
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlgorithmDesign.DataStructures;

    public static class ExpressionDAG
    {
        public static int Evaluate(GraphNode<string> expression)
        {
            if (expression.Neighbors.Count == 0)
            {
                return int.Parse(expression.Value);
            }
            else
            {
                var op = BinaryOperator(expression.Value);
                int a = Evaluate(expression.Neighbors[0]);
                int b = Evaluate(expression.Neighbors[1]);

                return op(a, b);
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
