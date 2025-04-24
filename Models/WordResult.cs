namespace Models

{
    // Class to represent the result of a word search in the Puzzle grid
    public class WordResult
    {
        public string Word { get; set; } = string.Empty; // default empty string
        public List<Position> Positions { get; set; } = new List<Position>(); // list of positions where the word is found
    }
}