using System.Drawing;
using System.Numerics;

namespace Fiks2;

class Program
{
    // size of plane is -10^9 to 10^9
    static void Main(string[] args)
    {
        HandleInput handleInput = new HandleInput("input.txt");
        
        var points = handleInput.GetPoints(0);
        
        
        
    }
    
    static Vector2 GetMiddlePoint(Vector2[] points) {
        var middlePointX = 0f;
        var middlePointY = 0f;
        // Add up all points
        foreach (var point in points) {
            middlePointX += point.X;
            middlePointY += point.Y;
        }
        // Divide by number of points
        middlePointX /= points.Length; middlePointY /= points.Length;
        return new Vector2(middlePointX, middlePointY);
    }
}