namespace Services
{
    using Models;

    // Loader class for loading a grid of characters from file (/App/Data/grid.txt)
    public class GridLoader : LoaderBase<Puzzle>
    {
        public override Puzzle Load(string filePath)
        {
            var lines = ReadLines(filePath); // read & clean all lines

            if (lines.Count == 0)
                throw new InvalidOperationException("The grid file is empty!");

            // Check number of rows and columns -> form a 2D grid
            int rows = lines.Count;
            int cols = lines[0].Length;
            var grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                // check if each row has the same number of columns
                if (lines[i].Length != cols)
                    throw new InvalidOperationException($"Row {i} does not have the expected {cols} columns!");

                // Fill the grid with characters from the lines
                for (int j = 0; j < cols; j++)
                    grid[i, j] = lines[i][j];
            }

            return new Puzzle { Grid = grid }; // return populated Puzzle object
        }
    }
}