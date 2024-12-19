using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Fiks2 {
    class Program
    {
        // size of plane is -10^9 to 10^9
        static void Main(string[] args)
        {
            HandleInput handleInput = new HandleInput("input.txt");
            using var sw = new StreamWriter("output.txt");
            var numOfInputs = handleInput.CountOfInputs();
            for (int i = 0; i < numOfInputs; i++) {
                double[] middlePoint = new Double[2];
                Console.WriteLine($"Progress: {i + 1}/{numOfInputs}");
                sw.WriteLine(Solve(handleInput, i, ref middlePoint) ? $"{middlePoint[0]} {middlePoint[1]}" : "ajajaj");
            }

            Console.WriteLine("Done");
        }
        
        static bool Solve(HandleInput handleInput, int indexOfInput, ref double[] middlePointOut) {
            // Get the points
            var points = handleInput.GetPointsInts(indexOfInput);
            
            if (points.Length % 2 == 1) {
                Console.WriteLine("Cannot be symmetric");
                return false;
            }
            
            // Get the middle point
            var middlePoint = GetMiddlePoint(points);
            
            // Get median and check if it is the middle point
            var isTheMiddlePointReal = true;
            var medianX = Median((int[])points[0]);
            var medianY = Median((int[])points[1]);
            if (Math.Abs(medianX - middlePoint[0]) > 0.05 || Math.Abs(medianY - middlePoint[1]) > 0.05) {
                isTheMiddlePointReal = false;
            }

            middlePointOut = middlePoint;
            return isTheMiddlePointReal;
        }
        
        // Get the middle point of an array of points
        static double[] GetMiddlePoint(Point[] points) {
            double middlePointX = 0;
            double middlePointY = 0;
            // Add up all points
            foreach (var point in points) {
                middlePointX += point.X;
                middlePointY += point.Y;
            }
            // Divide by number of points
            middlePointX /= points.Length; middlePointY /= points.Length;
            // middlePointX -= 1000000000; middlePointY -= 1000000000;
            return new double[] {middlePointX, middlePointY};
        }
        static double[] GetMiddlePoint(Array[] points) {
            var xPoints = (int[])points[0];
            var yPoints = (int[])points[1];
            double middlePointX = 0;
            double middlePointY = 0;
            // Add up all points
            for (int i = 0; i < xPoints.Length; i++) {
                middlePointX += xPoints[i];
                middlePointY += yPoints[i];
            }
            // Divide by number of points
            middlePointX /= xPoints.Length; middlePointY /= xPoints.Length;
            // middlePointX -= 1000000000; middlePointY -= 1000000000;
            return new double[] {middlePointX, middlePointY};
        }
        
        /// <summary>
        /// Get Array of dictionaries of points on axis
        /// </summary>
        /// <param name="points"> Points that we want to distribute</param>
        /// <returns>[0] is x-axis; [1] is y-axis</returns>
        static Dictionary<int, int>[] GetPointsOnAxis(Point[] points) {
            Dictionary<int, int>[] pointsOnAxis = new Dictionary<int, int>[2];
            pointsOnAxis[0] = new Dictionary<int, int>();
            pointsOnAxis[1] = new Dictionary<int, int>();
            // Add all points to the dictionary
            foreach (var point in points) {
                // Add point to x-axis
                if (!pointsOnAxis[0].ContainsKey(point.X)) {
                    pointsOnAxis[0][point.X] = 0;
                }
                pointsOnAxis[0][point.X]++;
                // Add point to y-axis
                if (!pointsOnAxis[1].ContainsKey(point.Y)) {
                    pointsOnAxis[1][point.Y] = 0;
                }
                pointsOnAxis[1][point.Y]++;
            }
            return pointsOnAxis;
        }
        
        /// <summary>
        /// Checks if all sides have
        /// </summary>
        /// <param name="axisX"></param>
        /// <param name="axisY"></param>
        /// <param name="middlePoint"></param>
        /// <returns></returns>
        static bool CheckSides(Dictionary<int, int> axisX, Dictionary<int, int> axisY, double[] middlePoint) {
            // Check if middle point is real
            var halvedX = axisX.Count / 2; var halvedY = axisY.Count / 2;
            // Make it so it check also for even and odd numbers    
            if (Math.Abs((axisX.ElementAt(halvedX).Key + axisX.ElementAt(halvedX + 1).Key) / 2 - middlePoint[0]) > 0.05 || Math.Abs((axisY.ElementAt(halvedY).Key + axisY.ElementAt(halvedY + 1).Key) / 2 - middlePoint[1]) > 0.05)
                return false;
            
            return true;
        }

        static double Median(int[] numbers, bool isSorted = false) {
            if (!isSorted)
                Array.Sort(numbers);
            double halfOfCount = numbers.Count() / (double)2;
            if ((halfOfCount % 1) != 0)
            {
                return numbers[(int)Math.Ceiling(halfOfCount)];
            }
            else
            {
                double one = numbers[(int)(halfOfCount - 1)];
                double two = numbers[(int)halfOfCount];
                return (one + two) / 2;
            }
        }
    }
}
