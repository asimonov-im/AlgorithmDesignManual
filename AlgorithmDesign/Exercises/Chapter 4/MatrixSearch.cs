namespace AlgorithmDesign.Exercises.Chapter4
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class MatrixSearch
    {
        public static (int, int) Optimal(int[,] m, int key)
        {
            int row = m.GetLength(0) - 1;
            int col = 0;
            while (row >= 0 && col < m.GetLength(1))
            {
                int cellValue = m[row, col];
                if (cellValue == key)
                    return (row, col);
                else if (cellValue < key)
                    ++col;
                else
                    --row;
            }

            return (-1, -1);
        }

        public static (int, int) DivideAndConquer(int[,] m, int key)
        {
            return DivideAndConquer(m, key, 0, m.GetLength(0), 0, m.GetLength(1));
        }

        private static (int, int) DivideAndConquer(
            int[,] m, 
            int key,
            int rowLo,
            int rowHi,
            int colLo,
            int colHi)
        {
            if (rowHi < rowLo ||
                rowLo >= m.GetLength(0) ||
                colHi < colLo ||
                colLo >= m.GetLength(1))
            {
                return (-1, -1);
            }

            int rowMid = rowLo + (rowHi - rowLo) / 2;
            int colMid = colLo + (colHi - colLo) / 2;
            int cellValue = m[rowMid, colMid];

            if (cellValue == key)
            {
                return (rowMid, colMid);
            }
            else if (cellValue > key)
            {
                var result = DivideAndConquer(m, key, rowLo, rowHi, colLo, colMid - 1);
                return result != (-1, -1) ?
                    result :
                    DivideAndConquer(m, key, rowLo, rowMid - 1, colMid, colHi);
            }
            else
            {
                var result = DivideAndConquer(m, key, rowLo, rowHi, colMid + 1, colHi);
                return result != (-1, -1) ?
                    result :
                    DivideAndConquer(m, key, rowMid + 1, rowHi, colLo, colMid);
            }
        }
    }
}
