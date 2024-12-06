namespace Fiks2;

class Program
{
    static void Main(string[] args)
    {
        HandleInput handleInput = new HandleInput("input.txt");
        var points = handleInput.GetPoints(0);
        
        // Calculate middle point
        var middlePointX = 0f;
        var middlePointY = 0f;
        // Add up all points
        foreach (var point in points) {
            middlePointX += point.X;
            middlePointY += point.Y;
        }
        // Divide by number of points
        middlePointX /= points.Length; middlePointY /= points.Length;
        Console.WriteLine($"Middle point: ({middlePointX}, {middlePointY})");
        
        
    }
}