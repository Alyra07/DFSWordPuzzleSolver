using Models;

namespace Services;

// This class loads the character grid from /App/Data/grid.txt
public static class GridLoader
{
    public static Puzzle LoadGrid(string filePath)
    {
        var lines = File.ReadAllLines(filePath)
                        .Where(line => !string.IsNullOrWhiteSpace(line)) // skip empty lines
                        .Select(line => line.Replace(" ", "")) // remove spaces
                        .ToList();

        int rows = lines.Count; // number of rows
        int cols = lines[0].Length; // number of columns

        var grid = new char[rows, cols];

        // check if all rows have the same number of columns
        for (int i = 0; i < rows; i++)
        {
            if (lines[i].Length != cols)
                throw new InvalidOperationException($"Row {i} does not have the expected {cols} columns!");

            // convert each character to uppercase and store in the grid
            for (int j = 0; j < cols; j++)
                grid[i, j] = char.ToUpper(lines[i][j]);
        }

        return new Puzzle { Grid = grid }; // returns the grid as Puzzle object
    }
}