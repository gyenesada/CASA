namespace CASA
{
    partial class Form
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.algorithmType = new System.Windows.Forms.Label();
            this.squareOneCheckBox = new System.Windows.Forms.CheckBox();
            this.CasaCheckBox = new System.Windows.Forms.CheckBox();
            this.runButton = new System.Windows.Forms.Button();
            this.menuSav = new System.Windows.Forms.MenuStrip();
            this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.képernyőTörléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráfTisztázásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráfBetöltéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mátrixMegjelenítésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.addGraphConsoleLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.pointLabel = new System.Windows.Forms.Label();
            this.startCheckBox = new System.Windows.Forms.CheckBox();
            this.destCheckBox = new System.Windows.Forms.CheckBox();
            this.edgeDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.shortestPathInfosLabel = new System.Windows.Forms.Label();
            this.arborescenceLabel = new System.Windows.Forms.Label();
            this.deleteEdgeCasaCheckBox = new System.Windows.Forms.CheckBox();
            this.kozvetlenUtButton = new System.Windows.Forms.Button();
            this.arbmeghatButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuSav.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(0, 27);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(896, 507);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // algorithmType
            // 
            this.algorithmType.AutoSize = true;
            this.algorithmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.algorithmType.Location = new System.Drawing.Point(902, 27);
            this.algorithmType.Name = "algorithmType";
            this.algorithmType.Size = new System.Drawing.Size(78, 17);
            this.algorithmType.TabIndex = 1;
            this.algorithmType.Text = "Algoritmus:";
            // 
            // squareOneCheckBox
            // 
            this.squareOneCheckBox.AutoSize = true;
            this.squareOneCheckBox.Location = new System.Drawing.Point(914, 65);
            this.squareOneCheckBox.Name = "squareOneCheckBox";
            this.squareOneCheckBox.Size = new System.Drawing.Size(80, 17);
            this.squareOneCheckBox.TabIndex = 2;
            this.squareOneCheckBox.Text = "SquareOne";
            this.squareOneCheckBox.UseVisualStyleBackColor = true;
            this.squareOneCheckBox.CheckedChanged += new System.EventHandler(this.squareOneCheckBox_CheckedChanged);
            // 
            // CasaCheckBox
            // 
            this.CasaCheckBox.AutoSize = true;
            this.CasaCheckBox.Location = new System.Drawing.Point(914, 88);
            this.CasaCheckBox.Name = "CasaCheckBox";
            this.CasaCheckBox.Size = new System.Drawing.Size(54, 17);
            this.CasaCheckBox.TabIndex = 3;
            this.CasaCheckBox.Text = "CASA";
            this.CasaCheckBox.UseVisualStyleBackColor = true;
            this.CasaCheckBox.CheckedChanged += new System.EventHandler(this.CasaCheckBox_CheckedChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(914, 511);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Futtatás";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // menuSav
            // 
            this.menuSav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem});
            this.menuSav.Location = new System.Drawing.Point(0, 0);
            this.menuSav.Name = "menuSav";
            this.menuSav.Size = new System.Drawing.Size(1123, 24);
            this.menuSav.TabIndex = 8;
            this.menuSav.Text = "menuSav";
            // 
            // fájlToolStripMenuItem
            // 
            this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.képernyőTörléseToolStripMenuItem,
            this.gráfTisztázásaToolStripMenuItem,
            this.gráfBetöltéseToolStripMenuItem,
            this.mátrixMegjelenítésToolStripMenuItem,
            this.kilépésToolStripMenuItem1});
            this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            this.fájlToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fájlToolStripMenuItem.Text = "Fájl";
            // 
            // képernyőTörléseToolStripMenuItem
            // 
            this.képernyőTörléseToolStripMenuItem.Name = "képernyőTörléseToolStripMenuItem";
            this.képernyőTörléseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.képernyőTörléseToolStripMenuItem.Text = "Képernyő törlése";
            this.képernyőTörléseToolStripMenuItem.Click += new System.EventHandler(this.képernyőTörléseToolStripMenuItem_Click);
            // 
            // gráfTisztázásaToolStripMenuItem
            // 
            this.gráfTisztázásaToolStripMenuItem.Name = "gráfTisztázásaToolStripMenuItem";
            this.gráfTisztázásaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gráfTisztázásaToolStripMenuItem.Text = "Gráf tisztázása";
            this.gráfTisztázásaToolStripMenuItem.Click += new System.EventHandler(this.gráfTisztázásaToolStripMenuItem_Click);
            // 
            // gráfBetöltéseToolStripMenuItem
            // 
            this.gráfBetöltéseToolStripMenuItem.Enabled = false;
            this.gráfBetöltéseToolStripMenuItem.Name = "gráfBetöltéseToolStripMenuItem";
            this.gráfBetöltéseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gráfBetöltéseToolStripMenuItem.Text = "Gráf betöltése fájlból";
            this.gráfBetöltéseToolStripMenuItem.Click += new System.EventHandler(this.gráfBetöltéseToolStripMenuItem_Click);
            // 
            // mátrixMegjelenítésToolStripMenuItem
            // 
            this.mátrixMegjelenítésToolStripMenuItem.Name = "mátrixMegjelenítésToolStripMenuItem";
            this.mátrixMegjelenítésToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mátrixMegjelenítésToolStripMenuItem.Text = "Mátrix megjelenítése";
            this.mátrixMegjelenítésToolStripMenuItem.Click += new System.EventHandler(this.mátrixMegjelenítésToolStripMenuItem_Click);
            // 
            // kilépésToolStripMenuItem1
            // 
            this.kilépésToolStripMenuItem1.Name = "kilépésToolStripMenuItem1";
            this.kilépésToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.kilépésToolStripMenuItem1.Text = "Kilépés";
            this.kilépésToolStripMenuItem1.Click += new System.EventHandler(this.kilépésToolStripMenuItem1_Click);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.consoleTextBox.Enabled = false;
            this.consoleTextBox.Location = new System.Drawing.Point(0, 598);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleTextBox.Size = new System.Drawing.Size(1123, 46);
            this.consoleTextBox.TabIndex = 9;
            // 
            // addGraphConsoleLabel
            // 
            this.addGraphConsoleLabel.AutoSize = true;
            this.addGraphConsoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addGraphConsoleLabel.Location = new System.Drawing.Point(-3, 578);
            this.addGraphConsoleLabel.Name = "addGraphConsoleLabel";
            this.addGraphConsoleLabel.Size = new System.Drawing.Size(106, 17);
            this.addGraphConsoleLabel.TabIndex = 10;
            this.addGraphConsoleLabel.Text = "Gráf megadása";
            // 
            // loadButton
            // 
            this.loadButton.Enabled = false;
            this.loadButton.Location = new System.Drawing.Point(1036, 540);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 11;
            this.loadButton.Text = "Betöltés";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // pointLabel
            // 
            this.pointLabel.AutoSize = true;
            this.pointLabel.Location = new System.Drawing.Point(12, 544);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(10, 13);
            this.pointLabel.TabIndex = 12;
            this.pointLabel.Text = " ";
            // 
            // startCheckBox
            // 
            this.startCheckBox.AutoSize = true;
            this.startCheckBox.Location = new System.Drawing.Point(151, 540);
            this.startCheckBox.Name = "startCheckBox";
            this.startCheckBox.Size = new System.Drawing.Size(48, 17);
            this.startCheckBox.TabIndex = 13;
            this.startCheckBox.Text = "Start";
            this.startCheckBox.UseVisualStyleBackColor = true;
            this.startCheckBox.CheckedChanged += new System.EventHandler(this.startCheckBox_CheckedChanged);
            // 
            // destCheckBox
            // 
            this.destCheckBox.AutoSize = true;
            this.destCheckBox.Location = new System.Drawing.Point(236, 540);
            this.destCheckBox.Name = "destCheckBox";
            this.destCheckBox.Size = new System.Drawing.Size(79, 17);
            this.destCheckBox.TabIndex = 14;
            this.destCheckBox.Text = "Destination";
            this.destCheckBox.UseVisualStyleBackColor = true;
            this.destCheckBox.CheckedChanged += new System.EventHandler(this.destCheckBox_CheckedChanged);
            // 
            // edgeDeleteCheckBox
            // 
            this.edgeDeleteCheckBox.AutoSize = true;
            this.edgeDeleteCheckBox.Location = new System.Drawing.Point(790, 540);
            this.edgeDeleteCheckBox.Name = "edgeDeleteCheckBox";
            this.edgeDeleteCheckBox.Size = new System.Drawing.Size(69, 17);
            this.edgeDeleteCheckBox.TabIndex = 16;
            this.edgeDeleteCheckBox.Text = "Él törlése";
            this.edgeDeleteCheckBox.UseVisualStyleBackColor = true;
            this.edgeDeleteCheckBox.Visible = false;
            this.edgeDeleteCheckBox.CheckedChanged += new System.EventHandler(this.edgeDeleteCheckBox_CheckedChanged);
            // 
            // shortestPathInfosLabel
            // 
            this.shortestPathInfosLabel.AutoSize = true;
            this.shortestPathInfosLabel.Location = new System.Drawing.Point(911, 187);
            this.shortestPathInfosLabel.Name = "shortestPathInfosLabel";
            this.shortestPathInfosLabel.Size = new System.Drawing.Size(99, 13);
            this.shortestPathInfosLabel.TabIndex = 17;
            // 
            // arborescenceLabel
            // 
            this.arborescenceLabel.AutoSize = true;
            this.arborescenceLabel.Location = new System.Drawing.Point(911, 161);
            this.arborescenceLabel.Name = "arborescenceLabel";
            this.arborescenceLabel.Size = new System.Drawing.Size(7, 13);
            this.arborescenceLabel.TabIndex = 19;
            this.arborescenceLabel.Text = "\r\n";
            // 
            // deleteEdgeCasaCheckBox
            // 
            this.deleteEdgeCasaCheckBox.AutoSize = true;
            this.deleteEdgeCasaCheckBox.Location = new System.Drawing.Point(790, 540);
            this.deleteEdgeCasaCheckBox.Name = "deleteEdgeCasaCheckBox";
            this.deleteEdgeCasaCheckBox.Size = new System.Drawing.Size(106, 17);
            this.deleteEdgeCasaCheckBox.TabIndex = 20;
            this.deleteEdgeCasaCheckBox.Text = "Él törlése (CASA)";
            this.deleteEdgeCasaCheckBox.UseVisualStyleBackColor = true;
            this.deleteEdgeCasaCheckBox.Visible = false;
            this.deleteEdgeCasaCheckBox.CheckedChanged += new System.EventHandler(this.deleteEdgeCasaCheckBox_CheckedChanged);
            // 
            // kozvetlenUtButton
            // 
            this.kozvetlenUtButton.Location = new System.Drawing.Point(914, 121);
            this.kozvetlenUtButton.Name = "kozvetlenUtButton";
            this.kozvetlenUtButton.Size = new System.Drawing.Size(75, 23);
            this.kozvetlenUtButton.TabIndex = 21;
            this.kozvetlenUtButton.Text = "Közvetlen út";
            this.kozvetlenUtButton.UseVisualStyleBackColor = true;
            this.kozvetlenUtButton.Visible = false;
            this.kozvetlenUtButton.Click += new System.EventHandler(this.kozvetlenUtButton_Click);
            // 
            // arbmeghatButton
            // 
            this.arbmeghatButton.Location = new System.Drawing.Point(1036, 121);
            this.arbmeghatButton.Name = "arbmeghatButton";
            this.arbmeghatButton.Size = new System.Drawing.Size(75, 23);
            this.arbmeghatButton.TabIndex = 22;
            this.arbmeghatButton.Text = "Arb.meghat.";
            this.arbmeghatButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.arbmeghatButton.UseVisualStyleBackColor = true;
            this.arbmeghatButton.Visible = false;
            this.arbmeghatButton.Click += new System.EventHandler(this.arbmeghatButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 644);
            this.Controls.Add(this.arbmeghatButton);
            this.Controls.Add(this.kozvetlenUtButton);
            this.Controls.Add(this.deleteEdgeCasaCheckBox);
            this.Controls.Add(this.arborescenceLabel);
            this.Controls.Add(this.shortestPathInfosLabel);
            this.Controls.Add(this.edgeDeleteCheckBox);
            this.Controls.Add(this.destCheckBox);
            this.Controls.Add(this.startCheckBox);
            this.Controls.Add(this.pointLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.addGraphConsoleLabel);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.CasaCheckBox);
            this.Controls.Add(this.squareOneCheckBox);
            this.Controls.Add(this.algorithmType);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuSav);
            this.MainMenuStrip = this.menuSav;
            this.Name = "Form";
            this.Text = "CASA - Congestion and Stretch Aware Static Fast Rerouting";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuSav.ResumeLayout(false);
            this.menuSav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label algorithmType;
        private System.Windows.Forms.CheckBox squareOneCheckBox;
        private System.Windows.Forms.CheckBox CasaCheckBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.MenuStrip menuSav;
        private System.Windows.Forms.ToolStripMenuItem fájlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gráfBetöltéseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mátrixMegjelenítésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kilépésToolStripMenuItem1;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.Label addGraphConsoleLabel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label pointLabel;
        private System.Windows.Forms.CheckBox startCheckBox;
        private System.Windows.Forms.CheckBox destCheckBox;
        private System.Windows.Forms.ToolStripMenuItem képernyőTörléseToolStripMenuItem;
        private System.Windows.Forms.CheckBox edgeDeleteCheckBox;
        private System.Windows.Forms.ToolStripMenuItem gráfTisztázásaToolStripMenuItem;
        private System.Windows.Forms.Label shortestPathInfosLabel;
        private System.Windows.Forms.Label arborescenceLabel;
        private System.Windows.Forms.CheckBox deleteEdgeCasaCheckBox;
        private System.Windows.Forms.Button kozvetlenUtButton;
        private System.Windows.Forms.Button arbmeghatButton;
    }
}

