Matrix Trace
The program is designed to calculate the sum of the main diagonal of a matrix and output the matrix elements in a spiral order. 
The user inputs the matrix parameters (number of rows and columns), and a matrix with the specified parameters is generated with random elements in the range from 0 to 100. 
As a result, the user receives the matrix with the main diagonal marked, the sum of the main diagonal, and the matrix elements arranged in a spiral, 
starting from the outermost layer and moving inward in a clockwise direction.

...Bug in matrix display...
Matrices with more than 17 columns are displayed incorrectly,
with some elements appearing as three-digit numbers (even though numbers should be in the range of 0-100),
and rows containing these elements are missing a single number at the end of the line. 
It is possible that some pairs of numbers are being merged together when outputting to the console...
