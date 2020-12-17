using System;
using SFML.System;

namespace tempProject.Model
{
    public static class MathModule
    {
        public static Vector2f RotatedBy(this Vector2f vector2, double radians)
        {
            return vector2;
        }

        public static bool BoxIntersected(Tuple<Vector2f, Vector2f> firstBox, Tuple<Vector2f, Vector2f> secondBox)
        {
            var point1 = firstBox.Item1;
            var point2 = firstBox.Item2;
            var point3 = new Vector2f(firstBox.Item1.X, firstBox.Item2.Y);
            var point4 = new Vector2f(firstBox.Item2.X, firstBox.Item1.Y);
            return secondBox.ContainsPoint(point1) || secondBox.ContainsPoint(point2) ||
                   secondBox.ContainsPoint(point3) || secondBox.ContainsPoint(point4);
        }

        private static bool ContainsPoint(this Tuple<Vector2f, Vector2f> box, Vector2f point)
        {
            return (point.X >= box.Item1.X && point.X <= box.Item2.X) && (point.Y >= box.Item1.Y && point.Y <= box.Item2.Y);
        }

        public static float Hypot(Vector2f vect)
        {
            return (float) Math.Sqrt(vect.X * vect.X + vect.Y * vect.Y);
        }
    }
}