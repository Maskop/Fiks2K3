using System.Drawing;
using System.Numerics;
using System.Windows;

namespace Fiks2;

class Program
{
    // size of plane is -10^9 to 10^9
    static void Main(string[] args)
    {
        HandleInput handleInput = new HandleInput("input.txt");
        
        // Get the points
        var points = handleInput.GetPoints(1);
        // Get the middle point
        var middlePoint = GetMiddlePoint(points);
        
        // Create a dictionary for all points on the x and y-axis
        var pointsOnAxis = GetPointsOnAxis(points);
        
        Console.WriteLine($"Middle Point: X = {middlePoint[0]} Y = {middlePoint[1]}");
        
        // Loop through all points on the axis and write counts out
        foreach (var dicts in pointsOnAxis) {
            Console.WriteLine("New Axis");
            foreach (var axis in dicts) {
                Console.WriteLine($"Axis: {axis.Key} - Count: {axis.Value.Count}");
            }
        }
        
        bool isMiddlePoint = true;
        
        double sub = 1000000000;
        if (middlePoint[0] < 1000000000)
            sub = middlePoint[0];
        for (double s = middlePoint[0] - sub, e = middlePoint[0] + sub; s > middlePoint[0] && middlePoint[0] < e && isMiddlePoint ; s++, e--) {
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
        }

        Console.WriteLine(isMiddlePoint ? "YES" : "NO");
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
        middlePointX = middlePointX / points.Length; middlePointY /= points.Length;
        // middlePointX -= 1000000000; middlePointY -= 1000000000;
        return new double[] {middlePointX, middlePointY};
    }
    
    /// <summary>
    /// Get Array of dictionaries of points on axis
    /// </summary>
    /// <param name="points"> Points that we want to distribute</param>
    /// <returns>[0] is x-axis; [1] is y-axis</returns>
    static Dictionary<int, List<Point>>[] GetPointsOnAxis(Point[] points) {
        Dictionary<int, List<Point>>[] pointsOnAxis = new Dictionary<int, List<Point>>[2];
        pointsOnAxis[0] = new Dictionary<int, List<Point>>();
        pointsOnAxis[1] = new Dictionary<int, List<Point>>();
        // Add all points to the dictionary
        foreach (var point in points) {
            // Add point to x-axis
            if (!pointsOnAxis[0].ContainsKey(point.X)) {
                pointsOnAxis[0][point.X] = new List<Point>();
            }
            pointsOnAxis[0][point.X].Add(point);
            // Add point to y-axis
            if (!pointsOnAxis[1].ContainsKey(point.Y)) {
                pointsOnAxis[1][point.Y] = new List<Point>();
            }
            pointsOnAxis[1][point.Y].Add(point);
        }
        return pointsOnAxis;
    }
    
}