using Models;

namespace Services
{
    // This class loads the grid from /App/Data/grid.txt file
    public class GridLoader : LoaderBase<Puzzle>
    {
        public override Puzzle Load(string filePath)
        {
            var lines = ReadLines(filePath); // read all lines and clean them

            // check if file is empty
            if (lines.Count == 0)
                throw new InvalidOperationException("The grid file is empty!");

            // Create a 2D char array (grid) with rows & cols based on the lines
            int rows = lines.Count;
            int cols = lines[0].Length;
            var grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                // check if all rows have the same number of columns
                if (lines[i].Length != cols)
                    throw new InvalidOperationException($"Row {i} does not have the expected {cols} columns!");

                // Fill the grid with characters from the lines
                for (int j = 0; j < cols; j++)
                    grid[i, j] = lines[i][j];
            }

            return new Puzzle { Grid = grid }; // return the grid as Puzzle object
        }
    }
}