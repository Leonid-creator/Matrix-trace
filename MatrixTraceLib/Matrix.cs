namespace MatrixTraceLib
{
    public class Matrix
    {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        private int[,] _matrix;

        public Matrix(int lines, int columns)
        {
            Columns = columns;
            Lines = lines;
            _matrix = new int[lines, columns];
        }

        public void FillMatrixRandom()
        {
            Random random = new Random();

            for (int i = 0; i < Lines; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _matrix[i, j] = random.Next(0, 100);
                }
            }
        }

        public virtual int[,] GetMatrix()
        {
            return _matrix;
        }

        public int GetMatrixTrace()
        {
            int[,] matrix = GetMatrix();
            int lines = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int matrixTrace = 0;

            for (int i = 0; i < lines && i < columns; i++)
            {
                matrixTrace += matrix[i, i];
            }
            return matrixTrace;
        }

        public void ShowMatrixTrace()
        {
            int[,] matrix = GetMatrix();
            int lines = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{matrix[i, j]}\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j]}\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public List<int> GetSnail()
        {
            int[,] matrix = GetMatrix();
            int lines = matrix.GetLength(0);
            int columns = matrix.GetLength(1);


            int upLimit = 0;
            int downLimit = lines - 1;
            int leftLimit = 0;
            int rightLimit = columns - 1;

            int currentLine = 0;
            int currentColumn = 0;

            int counterElement = 0;

            List<int> snail = new List<int>();

            while (true)
            {
                //right
                for (int i = leftLimit; i <= rightLimit; i++)
                {
                    currentColumn = i;
                    snail.Add(matrix[currentLine, currentColumn]);
                    counterElement++;
                }
                if (counterElement >= matrix.Length)
                {
                    break;
                }
                upLimit++;

                //down
                for (int i = upLimit; i <= downLimit; i++)
                {
                    currentLine = i;
                    snail.Add(matrix[currentLine, currentColumn]);
                    counterElement++;
                }
                if (counterElement >= matrix.Length)
                {
                    break;
                }
                rightLimit--;

                //left
                for (int i = rightLimit; i >= leftLimit; i--)
                {
                    currentColumn = i;
                    snail.Add(matrix[currentLine, currentColumn]);
                    counterElement++;
                }
                if (counterElement >= matrix.Length)
                {
                    break;
                }
                downLimit--;

                //up
                for (int i = downLimit; i >= upLimit; i--)
                {
                    currentLine = i;
                    snail.Add(matrix[currentLine, currentColumn]);
                    counterElement++;
                }
                if (counterElement >= matrix.Length)
                {
                    break;
                }
                leftLimit++;
            }
            return snail;
        }
    }
}
