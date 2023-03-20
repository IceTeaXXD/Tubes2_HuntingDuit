namespace Tubes2_HuntingDuit
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            FileChoose = new Button();
            SearchButton = new Button();
            DFSButton = new RadioButton();
            BFSButton = new RadioButton();
            Algorithm = new Label();
            Input_Label = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            MazeGrid = new DataGridView();
            Output_Label = new Label();
            panel4 = new Panel();
            Title = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MazeGrid).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(81, 62, 42);
            panel1.Controls.Add(FileChoose);
            panel1.Controls.Add(SearchButton);
            panel1.Controls.Add(DFSButton);
            panel1.Controls.Add(BFSButton);
            panel1.Controls.Add(Algorithm);
            panel1.Controls.Add(Input_Label);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(375, 908);
            panel1.TabIndex = 0;
            // 
            // FileChoose
            // 
            FileChoose.BackColor = Color.FromArgb(190, 158, 130);
            FileChoose.Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FileChoose.Location = new Point(51, 367);
            FileChoose.Name = "FileChoose";
            FileChoose.Size = new Size(282, 37);
            FileChoose.TabIndex = 12;
            FileChoose.Text = "Choose File...";
            FileChoose.UseVisualStyleBackColor = false;
            FileChoose.Click += FileChoose_Click;
            // 
            // SearchButton
            // 
            SearchButton.BackColor = Color.FromArgb(190, 158, 130);
            SearchButton.Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SearchButton.ForeColor = Color.FromArgb(81, 62, 42);
            SearchButton.Location = new Point(105, 581);
            SearchButton.Margin = new Padding(3, 4, 3, 4);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(173, 47);
            SearchButton.TabIndex = 7;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = false;
            SearchButton.Click += SearchButton_Click;
            // 
            // DFSButton
            // 
            DFSButton.AutoSize = true;
            DFSButton.Font = new Font("Poppins Medium", 11.249999F, FontStyle.Bold, GraphicsUnit.Point);
            DFSButton.ForeColor = Color.FromArgb(230, 211, 179);
            DFSButton.Location = new Point(153, 325);
            DFSButton.Margin = new Padding(3, 4, 3, 4);
            DFSButton.Name = "DFSButton";
            DFSButton.Size = new Size(72, 35);
            DFSButton.TabIndex = 10;
            DFSButton.TabStop = true;
            DFSButton.Text = "DFS";
            DFSButton.UseVisualStyleBackColor = true;
            // 
            // BFSButton
            // 
            BFSButton.AutoSize = true;
            BFSButton.Font = new Font("Poppins Medium", 11.249999F, FontStyle.Bold, GraphicsUnit.Point);
            BFSButton.ForeColor = Color.FromArgb(230, 211, 179);
            BFSButton.Location = new Point(154, 282);
            BFSButton.Margin = new Padding(3, 4, 3, 4);
            BFSButton.Name = "BFSButton";
            BFSButton.Size = new Size(71, 35);
            BFSButton.TabIndex = 9;
            BFSButton.TabStop = true;
            BFSButton.Text = "BFS";
            BFSButton.UseVisualStyleBackColor = true;
            // 
            // Algorithm
            // 
            Algorithm.AutoSize = true;
            Algorithm.Font = new Font("Poppins Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            Algorithm.ForeColor = Color.FromArgb(230, 211, 179);
            Algorithm.Location = new Point(116, 229);
            Algorithm.Name = "Algorithm";
            Algorithm.Size = new Size(145, 40);
            Algorithm.TabIndex = 8;
            Algorithm.Text = "Algorithm";
            // 
            // Input_Label
            // 
            Input_Label.AutoSize = true;
            Input_Label.Font = new Font("Poppins Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            Input_Label.ForeColor = Color.FromArgb(190, 158, 130);
            Input_Label.Location = new Point(3, 72);
            Input_Label.Name = "Input_Label";
            Input_Label.Size = new Size(97, 46);
            Input_Label.TabIndex = 5;
            Input_Label.Text = "Input";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(59, 44, 26);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(416, 69);
            panel3.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(190, 158, 130);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(MazeGrid);
            panel2.Controls.Add(Output_Label);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(375, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1070, 908);
            panel2.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(81, 62, 42);
            label5.Location = new Point(32, 841);
            label5.Name = "label5";
            label5.Size = new Size(265, 44);
            label5.TabIndex = 11;
            label5.Text = "Execution Time : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(81, 62, 42);
            label4.Location = new Point(32, 796);
            label4.Name = "label4";
            label4.Size = new Size(127, 44);
            label4.TabIndex = 10;
            label4.Text = "Nodes :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(81, 62, 42);
            label3.Location = new Point(32, 751);
            label3.Name = "label3";
            label3.Size = new Size(135, 44);
            label3.TabIndex = 9;
            label3.Text = "Steps  : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(81, 62, 42);
            label2.Location = new Point(32, 673);
            label2.Name = "label2";
            label2.Size = new Size(139, 44);
            label2.TabIndex = 8;
            label2.Text = "Route  : ";
            // 
            // MazeGrid
            // 
            MazeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MazeGrid.Location = new Point(303, 161);
            MazeGrid.Margin = new Padding(3, 4, 3, 4);
            MazeGrid.Name = "MazeGrid";
            MazeGrid.RowHeadersWidth = 51;
            MazeGrid.RowTemplate.Height = 25;
            MazeGrid.Size = new Size(400, 467);
            MazeGrid.TabIndex = 7;
            // 
            // Output_Label
            // 
            Output_Label.AutoSize = true;
            Output_Label.Font = new Font("Poppins Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            Output_Label.ForeColor = Color.FromArgb(81, 62, 42);
            Output_Label.Location = new Point(0, 72);
            Output_Label.Name = "Output_Label";
            Output_Label.Size = new Size(123, 46);
            Output_Label.TabIndex = 6;
            Output_Label.Text = "Output";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(59, 44, 26);
            panel4.Controls.Add(Title);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1070, 69);
            panel4.TabIndex = 4;
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.BackColor = Color.Transparent;
            Title.Font = new Font("Poppins Medium", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            Title.ForeColor = Color.FromArgb(230, 211, 179);
            Title.Location = new Point(287, 0);
            Title.Name = "Title";
            Title.Size = new Size(319, 72);
            Title.TabIndex = 2;
            Title.Text = "Hunting Duit";
            Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(237, 61);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(8, 8);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 908);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Hunting Duit";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MazeGrid).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label Title;
        private Panel panel3;
        private Panel panel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label Input_Label;
        private Label Output_Label;
        private RadioButton DFSButton;
        private RadioButton BFSButton;
        private Label Algorithm;
        private Button SearchButton;
        private DataGridView MazeGrid;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button FileChoose;
    }
}