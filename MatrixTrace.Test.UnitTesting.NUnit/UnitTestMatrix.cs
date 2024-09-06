using MatrixTraceLib;
using Moq;

namespace MatrixTrace.Test.UnitTesting.NUnit
{
    public class Tests
    {
        public static IEnumerable<(int[,], int, List<int>)> TestCases()
        {
            // 1x1
            yield return
            (
                new int[,] { { 6 } },
                6,
                new List<int> { 6 }
            );
            //3x3
            yield return
            (
                new int[,] { {  1,  2,  3 },
                             {  4,  5,  6 },
                             {  7,  8,  9 } },
                15,
                new List<int> { 1, 2, 3, 6, 9, 8, 7, 4, 5 }
            );
            // 3x5
            yield return
            (
                new int[,] { {  1,  2,  3,  4,  5 },
                             {  6,  7,  8,  9, 10 },
                             { 11, 12, 13, 14, 15 } },
                21,
                new List<int> { 1, 2, 3, 4, 5, 10, 15, 14, 13, 12, 11, 6, 7, 8, 9 }
            );
            // 5x3
            yield return
            (
                new int[,] { {  1,  2,  3 },
                             {  4,  5,  6 },
                             {  7,  8,  9 },
                             { 10, 11, 12 },
                             { 13, 14, 15 } },
                15,
                new List<int> { 1, 2, 3, 6, 9, 12, 15, 14, 13, 10, 7, 4, 5, 8, 11 }
            );
            // 4x6
            yield return
            (
                new int[,] { {  1,  2,  3,  4,  5,  6 },
                             {  7,  8,  9, 10, 11, 12 },
                             { 13, 14, 15, 16, 17, 18 },
                             { 19, 20, 21, 22, 23, 24 } },
                46,
                new List<int> { 1, 2, 3, 4, 5, 6, 12, 18, 24, 23, 22, 21, 20, 19, 13, 7, 8, 9, 10, 11, 17, 16, 15, 14 }
            );
            // 6x4
            yield return
            (
                new int[,] { {  1,  2,  3,  4 },
                             {  5,  6,  7,  8 },
                             {  9, 10, 11, 12 },
                             { 13, 14, 15, 16 },
                             { 17, 18, 19, 20 },
                             { 21, 22, 23, 24 } },
                34,
                new List<int> { 1, 2, 3, 4, 8, 12, 16, 20, 24, 23, 22, 21, 17, 13, 9, 5, 6, 7, 11, 15, 19, 18, 14, 10 }
            );
        }

        [TestCaseSource(nameof(TestCases))]
        public void GetMatrixTrace_Matrix_MatrixTrace((int[,] testData, int expectedTrace, List<int> snail) td)
        {
            var matrixMock = new Mock<Matrix>(1, 1);
            matrixMock.Setup(m => m.GetMatrix()).Returns(td.testData);
            int actualTrace = matrixMock.Object.GetMatrixTrace();
            Assert.AreEqual(td.expectedTrace, actualTrace);
        }

        [TestCaseSource(nameof(TestCases))]
        public void GetSnail_Matrix_Snail((int[,] testData, int expectedTrace, List<int> expectedSnail) td)
        {
            var matrixMock = new Mock<Matrix>(1, 1);
            List<int> actualSnail = new List<int>();
            matrixMock.Setup(m => m.GetMatrix()).Returns(td.testData);
            actualSnail = matrixMock.Object.GetSnail();
            Assert.AreEqual(td.expectedSnail, actualSnail);
        }
    }
}