using System;

namespace AlgorithmDesign.DataStructures
{
    public struct Point2D
    {
        public float X;
        public float Y;

        public Point2D(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static double Distance(Point2D a, Point2D b)
        {
            double deltaX = a.X - b.X;
            double deltaY = a.Y - b.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static bool operator ==(Point2D p1, Point2D p2) => p1.Equals(p2);

        public static bool operator !=(Point2D p1, Point2D p2) => !p1.Equals(p2);
    }
}
