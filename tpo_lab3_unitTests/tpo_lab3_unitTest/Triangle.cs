using System;

namespace tpo_lab3_unitTest
{
    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            return (a > 0 && b > 0 && c > 0 && (a + b >= c) && (a + c >= b) && (b + c >= a));
        }
    }
}
