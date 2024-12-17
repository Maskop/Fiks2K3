using System.Drawing;
using System.Diagnostics;

namespace Fiks2;

class Program
{
    // size of plane is -10^9 to 10^9
    static void Main(string[] args)
    {
        HandleInput handleInput = new HandleInput("input.txt");
        
        // Get the points
        var points = handleInput.GetPoints(0);

        if (points.Length % 2 == 1) {
            Console.WriteLine("Cannot be symmetric");
            return;
        }
        
        // Get the middle point
        var middlePoint = GetMiddlePoint(points);
        
        // Create a dictionary for all points on the x and y-axis
        var pointsOnAxis = GetPointsOnAxis(points);
        
        Console.WriteLine($"Middle Point: X = {middlePoint[0]} Y = {middlePoint[1]}");
        
        // Loop through all points on the axis and write counts out
        foreach (var dicts in pointsOnAxis) {
            Console.WriteLine("New Axis");
            foreach (var axis in dicts) {
                Console.WriteLine($"Axis: {axis.Key} - Count: {axis.Value}");
            }
        }
        
        bool isTheMiddlePointReal = true;
        var sortedPointsOnAxisX = from entry in pointsOnAxis[0] orderby entry.Key ascending select entry;
        var sortedPointsOnAxisY = from entry in pointsOnAxis[1] orderby entry.Key ascending select entry;

        Console.WriteLine();
        foreach (var axis in sortedPointsOnAxisX) {
            Console.WriteLine($"Axis: {axis.Key} - Count: {axis.Value}");
        }

        Console.WriteLine();
        foreach (var axis in sortedPointsOnAxisY) {
            Console.WriteLine($"Axis: {axis.Key} - Count: {axis.Value}");
        }
        
        /*
        double sub = 1000000000;
        if (middlePoint[0] < 1000000000)
            sub = middlePoint[0];
        Stopwatch stopwatch = Stopwatch.StartNew();
        stopwatch.Start();
        for (double s = middlePoint[0] - sub, e = middlePoint[0] + sub; s < middlePoint[0] && middlePoint[0] < e && isMiddlePoint ; s++, e--) {
            switch (pointsOnAxis[0]) {
                case var x when x.ContainsKey((int)s):
                    if (!pointsOnAxis[0].ContainsKey((int)e)) {
                        isMiddlePoint = false;
                    }
                    break;
                case var x when x.ContainsKey((int)e):
                    if (!pointsOnAxis[0].ContainsKey((int)s)) { 
                        isMiddlePoint = false;
                    }
                    break;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        sub = 1000000000;
        if (middlePoint[1] < 1000000000)
            sub = middlePoint[1];
        for (double s = middlePoint[1] - sub, e = middlePoint[1] + sub; s > middlePoint[1] && middlePoint[1] < e && isMiddlePoint ; s++, e--) {
            switch (pointsOnAxis[1]) {
                case var y when y.ContainsKey((int)s):
                    if (!pointsOnAxis[1].ContainsKey((int)e)) {
                        isMiddlePoint = false;
                    }
                    break;
                case var y when y.ContainsKey((int)e):
                    if (!pointsOnAxis[1].ContainsKey((int)s)) { 
                        isMiddlePoint = false;
                    }
                    break;
            }
        }*/

        Console.WriteLine(isTheMiddlePointReal ? $"{middlePoint[0]} {middlePoint[1]}" : "NO");
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
}