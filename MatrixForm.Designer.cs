namespace CASA
{
    partial class MatrixForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.matrixTable = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // matrixTable
            // 
            this.matrixTable.AutoScroll = true;
            this.matrixTable.AutoSize = true;
            this.matrixTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.matrixTable.ColumnCount = 0;
            this.matrixTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.matrixTable.Location = new System.Drawing.Point(1, 2);
            this.matrixTable.Name = "matrixTable";
            this.matrixTable.RowCount = 0;
            this.matrixTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.matrixTable.Size = new System.Drawing.Size(40, 27);
            this.matrixTable.TabIndex = 0;
            // 
            // MatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(279, 133);
            this.Controls.Add(this.matrixTable);
            this.Name = "MatrixForm";
            this.Text = "MatrixForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel matrixTable;
    }
}