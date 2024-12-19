using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Fiks2 {
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.txt";
            string outputPath = "output.txt";
            
            // If there are arguments
            for (int i = 0; i < args.Length; i++) {
                switch (args[i]) {
                    case "--input":
                        inputPath = args[i + 1];
                        break;
                    case "--output":
                        outputPath = args[i + 1];
                        break;
                }
            }
            
            // Initialize the input handler and output writer
            HandleInput handleInput = new HandleInput(inputPath);
            using var sw = new StreamWriter(outputPath);
            // Main loop
            var numOfInputs = handleInput.CountOfInputs();
            for (int i = 0; i < numOfInputs; i++) {
                // Initialize the middle point so it doesn't cry
                double[] middlePoint = new Double[2];
                Console.WriteLine($"Progress: {i + 1}/{numOfInputs}");
                // Solve the problem and write the output
                sw.WriteLine(Solve(handleInput, i, ref middlePoint) ? $"{middlePoint[0] - 1000000000} {middlePoint[1] - 1000000000}" : "ajajaj");
            }
            
            // Show that the program is done
            Console.WriteLine("Done");
        }
        
        // Main solving function
        static bool Solve(HandleInput handleInput, int indexOfInput, ref double[] middlePointOut) {
            // Get the points
            var points = handleInput.GetPointsInts(indexOfInput);
            
            // Check if the number of points is even, otherwise the middle point is not real
            if (points[0].Length % 2 == 1) {
                return false;
            }
            
            // Get the middle point
            var middlePoint = GetMiddlePoint(points);
            
            // Get median and check if it is the middle point (average)
            var medianX = Median((int[])points[0]);
            var medianY = Median((int[])points[1]);
            if (Math.Abs(medianX - middlePoint[0]) > 0.05 || Math.Abs(medianY - middlePoint[1]) > 0.05)
                return false; // If not return false
            
            // Return the middle point to the pointer
            middlePointOut = middlePoint;
            return true;
        }
        
        // Get the middle point of an array of points
        static double[] GetMiddlePoint(Array[] points) {
            // Get the x and y points
            var xPoints = (int[])points[0];
            var yPoints = (int[])points[1];
            
            // Initialize the middle point
            double middlePointX = 0;
            double middlePointY = 0;
            
            // Add up all points
            for (int i = 0; i < xPoints.Length; i++) {
                middlePointX += xPoints[i];
                middlePointY += yPoints[i];
            }
            
            // Divide by number of points
            middlePointX /= xPoints.Length; middlePointY /= xPoints.Length;
            
            return new double[] {middlePointX, middlePointY}; // Return the middle point
        }
        // Get the median of an array of numbers
        static double Median(int[] numbers, bool isSorted = false) {
            // Sort the array if it is not sorted
            if (!isSorted)
                Array.Sort(numbers);
            // Get the middle number
            double halfOfCount = numbers.Count() / (double)2;
            // Check if the number of numbers is whole or not
            if ((halfOfCount % 1) != 0) {
                return numbers[(int)Math.Ceiling(halfOfCount)];
            } else {
                double one = numbers[(int)(halfOfCount - 1)];
                double two = numbers[(int)halfOfCount];
                return (one + two) / 2;
            }
        }
    }
}
