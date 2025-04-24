using Models;

namespace Services;

// Loads the character grid from /App/Data/grid.txt
public static class GridLoader
{
    public static Puzzle LoadGrid(string filePath)
    {
        // Read all lines from the file and store them in a 2D char array
        var lines = File.ReadAllLines(filePath);
        int rows = lines.Length;
        int cols = lines[0].Length;
        var grid = new char[rows, cols]; // initialize grid with correct size

        // Fill the grid with characters from grid.txt
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                grid[i, j] = lines[i][j];

        return new Puzzle { Grid = grid }; // returns the populated Puzzle object
    }
}