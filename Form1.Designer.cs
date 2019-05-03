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
            this.generateErrorLabel = new System.Windows.Forms.Label();
            this.directedErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.randomErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.runButton = new System.Windows.Forms.Button();
            this.menuSav = new System.Windows.Forms.MenuStrip();
            this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.képernyőTörléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gráfBetöltéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kilépésToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mátrixMegjelenítésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.addGraphConsoleLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.pointLabel = new System.Windows.Forms.Label();
            this.startCheckBox = new System.Windows.Forms.CheckBox();
            this.destCheckBox = new System.Windows.Forms.CheckBox();
            this.dijkstraButton = new System.Windows.Forms.Button();
            this.edgeDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.gráfTisztázásaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.canvas.Size = new System.Drawing.Size(472, 310);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // algorithmType
            // 
            this.algorithmType.AutoSize = true;
            this.algorithmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.algorithmType.Location = new System.Drawing.Point(478, 45);
            this.algorithmType.Name = "algorithmType";
            this.algorithmType.Size = new System.Drawing.Size(78, 17);
            this.algorithmType.TabIndex = 1;
            this.algorithmType.Text = "Algoritmus:";
            // 
            // squareOneCheckBox
            // 
            this.squareOneCheckBox.AutoSize = true;
            this.squareOneCheckBox.Location = new System.Drawing.Point(496, 75);
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
            this.CasaCheckBox.Location = new System.Drawing.Point(496, 98);
            this.CasaCheckBox.Name = "CasaCheckBox";
            this.CasaCheckBox.Size = new System.Drawing.Size(54, 17);
            this.CasaCheckBox.TabIndex = 3;
            this.CasaCheckBox.Text = "CASA";
            this.CasaCheckBox.UseVisualStyleBackColor = true;
            this.CasaCheckBox.CheckedChanged += new System.EventHandler(this.CasaCheckBox_CheckedChanged);
            // 
            // generateErrorLabel
            // 
            this.generateErrorLabel.AutoSize = true;
            this.generateErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generateErrorLabel.Location = new System.Drawing.Point(479, 129);
            this.generateErrorLabel.Name = "generateErrorLabel";
            this.generateErrorLabel.Size = new System.Drawing.Size(108, 17);
            this.generateErrorLabel.TabIndex = 4;
            this.generateErrorLabel.Text = "Hiba generálás:";
            // 
            // directedErrorCheckBox
            // 
            this.directedErrorCheckBox.AutoSize = true;
            this.directedErrorCheckBox.Location = new System.Drawing.Point(496, 161);
            this.directedErrorCheckBox.Name = "directedErrorCheckBox";
            this.directedErrorCheckBox.Size = new System.Drawing.Size(81, 17);
            this.directedErrorCheckBox.TabIndex = 5;
            this.directedErrorCheckBox.Text = "Célzott hiba";
            this.directedErrorCheckBox.UseVisualStyleBackColor = true;
            this.directedErrorCheckBox.CheckedChanged += new System.EventHandler(this.directedErrorCheckBox_CheckedChanged);
            // 
            // randomErrorCheckBox
            // 
            this.randomErrorCheckBox.AutoSize = true;
            this.randomErrorCheckBox.Location = new System.Drawing.Point(496, 184);
            this.randomErrorCheckBox.Name = "randomErrorCheckBox";
            this.randomErrorCheckBox.Size = new System.Drawing.Size(89, 17);
            this.randomErrorCheckBox.TabIndex = 6;
            this.randomErrorCheckBox.Text = "Random hiba";
            this.randomErrorCheckBox.UseVisualStyleBackColor = true;
            this.randomErrorCheckBox.CheckedChanged += new System.EventHandler(this.randomErrorCheckBox_CheckedChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(600, 207);
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
            this.menuSav.Size = new System.Drawing.Size(692, 24);
            this.menuSav.TabIndex = 8;
            this.menuSav.Text = "menuSav";
            // 
            // fájlToolStripMenuItem
            // 
            this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.képernyőTörléseToolStripMenuItem,
            this.gráfTisztázásaToolStripMenuItem,
            this.gráfBetöltéseToolStripMenuItem,
            this.kilépésToolStripMenuItem1,
            this.mátrixMegjelenítésToolStripMenuItem});
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
            // gráfBetöltéseToolStripMenuItem
            // 
            this.gráfBetöltéseToolStripMenuItem.Enabled = false;
            this.gráfBetöltéseToolStripMenuItem.Name = "gráfBetöltéseToolStripMenuItem";
            this.gráfBetöltéseToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gráfBetöltéseToolStripMenuItem.Text = "Gráf betöltése fájlból";
            this.gráfBetöltéseToolStripMenuItem.Click += new System.EventHandler(this.gráfBetöltéseToolStripMenuItem_Click);
            // 
            // kilépésToolStripMenuItem1
            // 
            this.kilépésToolStripMenuItem1.Name = "kilépésToolStripMenuItem1";
            this.kilépésToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.kilépésToolStripMenuItem1.Text = "Kilépés";
            this.kilépésToolStripMenuItem1.Click += new System.EventHandler(this.kilépésToolStripMenuItem1_Click);
            // 
            // mátrixMegjelenítésToolStripMenuItem
            // 
            this.mátrixMegjelenítésToolStripMenuItem.Name = "mátrixMegjelenítésToolStripMenuItem";
            this.mátrixMegjelenítésToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.mátrixMegjelenítésToolStripMenuItem.Text = "Mátrix megjelenítése";
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.consoleTextBox.Location = new System.Drawing.Point(0, 391);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleTextBox.Size = new System.Drawing.Size(692, 46);
            this.consoleTextBox.TabIndex = 9;
            // 
            // addGraphConsoleLabel
            // 
            this.addGraphConsoleLabel.AutoSize = true;
            this.addGraphConsoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addGraphConsoleLabel.Location = new System.Drawing.Point(-3, 365);
            this.addGraphConsoleLabel.Name = "addGraphConsoleLabel";
            this.addGraphConsoleLabel.Size = new System.Drawing.Size(106, 17);
            this.addGraphConsoleLabel.TabIndex = 10;
            this.addGraphConsoleLabel.Text = "Gráf megadása";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(605, 362);
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
            this.pointLabel.Location = new System.Drawing.Point(0, 344);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(10, 13);
            this.pointLabel.TabIndex = 12;
            this.pointLabel.Text = " ";
            // 
            // startCheckBox
            // 
            this.startCheckBox.AutoSize = true;
            this.startCheckBox.Location = new System.Drawing.Point(159, 344);
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
            this.destCheckBox.Location = new System.Drawing.Point(224, 344);
            this.destCheckBox.Name = "destCheckBox";
            this.destCheckBox.Size = new System.Drawing.Size(79, 17);
            this.destCheckBox.TabIndex = 14;
            this.destCheckBox.Text = "Destination";
            this.destCheckBox.UseVisualStyleBackColor = true;
            this.destCheckBox.CheckedChanged += new System.EventHandler(this.destCheckBox_CheckedChanged);
            // 
            // dijkstraButton
            // 
            this.dijkstraButton.Location = new System.Drawing.Point(496, 280);
            this.dijkstraButton.Name = "dijkstraButton";
            this.dijkstraButton.Size = new System.Drawing.Size(75, 23);
            this.dijkstraButton.TabIndex = 15;
            this.dijkstraButton.Text = "Dijkstra";
            this.dijkstraButton.UseVisualStyleBackColor = true;
            this.dijkstraButton.Click += new System.EventHandler(this.dijkstraButton_Click);
            // 
            // edgeDeleteCheckBox
            // 
            this.edgeDeleteCheckBox.AutoSize = true;
            this.edgeDeleteCheckBox.Location = new System.Drawing.Point(392, 344);
            this.edgeDeleteCheckBox.Name = "edgeDeleteCheckBox";
            this.edgeDeleteCheckBox.Size = new System.Drawing.Size(69, 17);
            this.edgeDeleteCheckBox.TabIndex = 16;
            this.edgeDeleteCheckBox.Text = "Él törlése";
            this.edgeDeleteCheckBox.UseVisualStyleBackColor = true;
            this.edgeDeleteCheckBox.CheckedChanged += new System.EventHandler(this.edgeDeleteCheckBox_CheckedChanged);
            // 
            // gráfTisztázásaToolStripMenuItem
            // 
            this.gráfTisztázásaToolStripMenuItem.Name = "gráfTisztázásaToolStripMenuItem";
            this.gráfTisztázásaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.gráfTisztázásaToolStripMenuItem.Text = "Gráf tisztázása";
            this.gráfTisztázásaToolStripMenuItem.Click += new System.EventHandler(this.gráfTisztázásaToolStripMenuItem_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 437);
            this.Controls.Add(this.edgeDeleteCheckBox);
            this.Controls.Add(this.dijkstraButton);
            this.Controls.Add(this.destCheckBox);
            this.Controls.Add(this.startCheckBox);
            this.Controls.Add(this.pointLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.addGraphConsoleLabel);
            this.Controls.Add(this.consoleTextBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.randomErrorCheckBox);
            this.Controls.Add(this.directedErrorCheckBox);
            this.Controls.Add(this.generateErrorLabel);
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
        private System.Windows.Forms.Label generateErrorLabel;
        private System.Windows.Forms.CheckBox directedErrorCheckBox;
        private System.Windows.Forms.CheckBox randomErrorCheckBox;
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
        private System.Windows.Forms.Button dijkstraButton;
        private System.Windows.Forms.CheckBox edgeDeleteCheckBox;
        private System.Windows.Forms.ToolStripMenuItem gráfTisztázásaToolStripMenuItem;
    }
}

