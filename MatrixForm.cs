using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASA
{
    public partial class MatrixForm: System.Windows.Forms.Form
    {

        List<List<int>>[,] Matrix;
        int Msize;
        public MatrixForm(List<List<int>>[,] matrix, int size)
        {
            Matrix = matrix;
            Msize = size;

            InitializeComponent();
            for (int i = 0; i<Msize; i++)
            {
                matrixTable.ColumnCount++;
                matrixTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));

                matrixTable.RowCount++;
                matrixTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));

                for (int j = 0; j<Msize; j++)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach(var v in Matrix[i, j])
                    {
                        sb.Append(String.Join("-", v));
                        sb.Append("; ");
                    }
                    
                    matrixTable.Controls.Add(new Label() { Text = sb.ToString() }, i, j);
                }
            }
        }
        
    }
}
