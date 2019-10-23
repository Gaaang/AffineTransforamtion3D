using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AffineTransformationsIn3D.Geometry
{
    public class Matrix
    {
        private double[,] data;

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public Matrix()
        {
            data = new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
        }

        public Matrix(double[,] data)
        {
            Debug.Assert(4 == data.GetLength(0));
            Debug.Assert(4 == data.GetLength(1));
            this.data = data;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            double[,] data = new double[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    data[i, j] = 0;
                    for (int k = 0; k < 4; ++k)
                        data[i, j] += m1[i, k] * m2[k, j];
                }
            return new Matrix(data);
        }

        private static double[,] Exclude(double[,] matrix, int row, int col)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n - 1, n - 1];
            for (int r = 0; r < n; ++r)
            {
                if (r == row) continue;
                int i = r - (r < row ? 0 : 1);
                for (int c = 0; c < n; ++c)
                {
                    if (c == col) continue;
                    int j = c - (c < col ? 0 : 1);
                    result[i, j] = matrix[r, c];
                }
            }
            return result;
        }
    }
}
