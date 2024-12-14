﻿using System.Drawing;

namespace Fiks2;

public class HandleInput {
    private string[] lines;

    public HandleInput(string path) {
        lines = File.ReadAllLines(path);
    }
    
    public Point[] GetPoints(int indexOfInput) {
        // Initialize points
        var numOfPoints = int.Parse(lines[indexOfInput * 3 + 1]);
        var points = new Point[numOfPoints];
        
        // Create all points
        var allX = lines[indexOfInput * 3 + 2].Split(' ');
        var allY = lines[indexOfInput * 3 + 3].Split(' ');
        for (int i = 0; i < numOfPoints; i++) {
            points[i] = new Point(int.Parse(allX[i]) + 1000000000, int.Parse(allY[i]) + 1000000000);
        }

        return points;
    }
}