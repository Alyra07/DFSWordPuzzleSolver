# Semester Project Report

Course: C# Development SS2025 (4 ECTS, 3 SWS)

Student ID: **cc231033**

BCC Group: **B**

Name: **Mirjam McLachlan**

## Methodology:
My WordPuzzleSolver project was designed to solve the problem of finding words in a grid of characters using the Depth-First Search (DFS) algorithm. The following steps outline the methodology used:

1. **File Management**: 
   - The project is organized into folders and class libraries to ensure modularity and maintainability. The main components are:
     - `Models`: Contains data models such as `Puzzle`, `Position`, and `WordResult`
     - `Services`: Contains loader classes (`GridLoader` & `WordLoader`) for reading input files
     - `Algorithm`: Contains the `DfsSolver` class, which implements the DFS algorithm
     - `App`: Console application that contains the main program logic and user interface

2. **Input Handling**:
   - Two input files (`grid.txt` & `words.txt`) are used:
     - `grid.txt` contains the grid of characters
     - `words.txt` contains the list of words to search for
   - The `GridLoader` & `WordLoader` classes, derived from a generic `LoaderBase<T>` class, handle file reading and preprocessing

3. **Algorithm Implementation**:
   - The DFS algorithm is implemented manually in the `DfsSolver` class (no external libraries used)
   - The algorithm searches for words in all 8 possible directions (N, NE, E, SE, S, SW, W, NW) starting from each cell in the grid.
     - If a word is found, its positions in the grid are recorded

4. **Output**:
   - The results are displayed in the console using the Spectre.Console library for better visualization.
   - The grid is displayed with found words highlighted in different colors
   - A list of found words with their positions and a list of words not found are also displayed.

5. **Object-Oriented Principles**:
   - The project demonstrates abstraction through the use of the `LoaderBase<T>` class and its derived classes.
   - Generics are used in the `LoaderBase<T>` class to make the file loading logic reusable for different data types.

## Discussion/Conclusion:

1. **Inheritance, Polymorphism, and Generics**:
   - While inheritance and polymorphism are not heavily used, my project demonstrates their application where suitable:
     - The `LoaderBase<T>` class uses inheritance and generics to provide a reusable base for file loaders.
     - Polymorphism is demonstrated through the use of the `Load` method, which is overridden in the `GridLoader` and `WordLoader` classes.
   - My justification for not using inheritance or polymorphism more extensively is that my project simply didn't require complex hierarchies or dynamic behavior. The classes are cohesive and serve distinct purposes, making additional abstraction unnecessary in my opinion. Introducing inheritance or polymorphism in other parts of the project would have added complexity without significant benefits to efficiency or maintainability.
     - However, I ensured that the project demonstrates these principles where they are most suitable, such as in the `LoaderBase<T>` class - This approach seemed to balance simplicity with adherence to the project requirements.

2. **Algorithm Implementation**:
   - I implemented a DFS algorithm manually without using external libraries, to fulfill the requirement to write the algorithm independently.
   - My application demonstrates the use of the DFS algorithm by finding and displaying words in a grid.

### Challenges and Solutions:
- **Challenge**: Ensuring that the grid and word list files are correctly formatted
  - **Solution**: Added validation logic in the `GridLoader` & `WordLoader` classes to handle errors such as empty files or inconsistent grid dimensions. Additionally, I unified the output by uppercasing each letter in the words and grid.
- **Challenge**: Implementing the DFS algorithm manually to handle all 8 directions efficiently
  - **Solution**: Used arrays to represent row and column direction offsets, simplifying the implementation
- **Challenge**: Highlighting found words in the grid
  - **Solution**: Used the Spectre.Console library to dynamically color grid cells based on the positions of found words

## Reference: 
- Wikipedia: [DFS Algorithm](https://en.wikipedia.org/wiki/Depth-first_search)
- YouTube, StackOverflow for tutorials
- GitHub Copilot for support & code refinement