namespace Models;

// This class represents a position in a 2D grid with row and column indices
public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }
}