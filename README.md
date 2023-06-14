# Sudoku-Solver
A small Unity game, where you can grab tablets with sudoku puzzles on them, and click solve to get a solved sudoku puzzle :<
Why walk around while doing it? Unclear, but why not! 

https://www.youtube.com/watch?v=UVQLtsRR11U

To paste sudoku puzzles from clipboard, you have to match the format below, where 0's indicate an unfilled square. 

0 0 0 7 0 4 0 0 5<br />
0 2 0 0 1 0 0 7 0<br />
0 0 0 0 8 0 0 0 2<br />
0 9 0 0 0 6 2 5 0<br />
6 0 0 0 7 0 0 0 8<br />
0 5 3 2 0 0 0 1 0<br />
4 0 0 0 9 0 0 0 0<br />
0 3 0 0 6 0 0 9 0<br />
2 0 0 4 0 7 0 0 0<br />

# Controls:
Hold mouse and look around
Press space to spawn new tablets

Copy a valid sudoku config you want to spawn
Then press spawn tablet from clip board to spawn it. 

# Sudoku solving
Solving is done via backtracking, a recurssive function that calls itself attempting all the possible configuration of the sudoku puzzle.
If an impossible configuration is found, backtrack to the last valid solution and continue. (Simple, not the most efficent, but gets the job done)

