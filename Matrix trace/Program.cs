using MatrixTraceLib;

namespace MatrixTrace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix parameters");

            Console.Write("Lines: ");
            int lines = int.Parse(Console.ReadLine());
            Console.Write("Columns: ");
            int columns = int.Parse(Console.ReadLine());

            Matrix matrix1 = new Matrix(lines, columns);

            matrix1.FillMatrixRandom();

            matrix1.ShowMatrixTrace();

            Console.WriteLine("Matrix trace = " + matrix1.GetMatrixTrace());

            List<int> snail = new List<int>(matrix1.GetSnail());

            foreach (int i in snail)
            {
                Console.Write($"{i} ");
            }
            Console.ReadLine();
        }
    }
}
