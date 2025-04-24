using Models;

namespace Services;

// Loads the character grid from /App/Data/grid.txt
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

        for (int i = 0; i < rows; i++)
        {
            if (lines[i].Length != cols)
                throw new InvalidOperationException($"Row {i} does not have the expected {cols} columns!");

            for (int j = 0; j < cols; j++)
                grid[i, j] = char.ToUpper(lines[i][j]); // store uppercase to standardize
        }

        return new Puzzle { Grid = grid }; // returns the grid as Puzzle object
    }
}