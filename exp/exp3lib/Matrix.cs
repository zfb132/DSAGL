using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAGL
{
    public class Matrix
    {
        private int[] items;
        private int rows, cols;
        public Matrix(int nRows, int nCols)
        {
            rows = nRows;
            cols = nCols;
            items = new int[rows * cols];
        }
        public Matrix(int nSize) : this(nSize, nSize) { }
        public Matrix() : this(1) { }
        public Matrix(int nRows, int nCols, int[] mat)
        {
            rows = nRows;
            cols = nCols;
            items = new int[rows * cols];
            Array.Copy(mat, items, mat.Length);
        }
        public int Rows { get { return rows; } }
        public int Columns { get { return cols; } }
        public int this[int i, int j]
        {
            get { return items[i * cols + j]; }
            set { items[i * cols + j] = value; }
        }
        public void Add(Matrix b)
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    items[i * cols + j] += b[i, j];
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return c;
        }
    }
}
