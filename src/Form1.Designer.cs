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
            TSP = new Label();
            TSPButton = new Toggle.ToggleButton();
            file = new Label();
            label6 = new Label();
            delayBox = new TextBox();
            label1 = new Label();
            outputDelay = new TrackBar();
            FileChoose = new Button();
            SearchButton = new Button();
            DFSButton = new RadioButton();
            BFSButton = new RadioButton();
            Algorithm = new Label();
            Input_Label = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            Runtime = new Label();
            label5 = new Label();
            Nodes = new Label();
            Steps = new Label();
            Route = new Label();
            MazeGrid = new DataGridView();
            Output_Label = new Label();
            panel4 = new Panel();
            Title = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)outputDelay).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MazeGrid).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(81, 62, 42);
            panel1.Controls.Add(TSP);
            panel1.Controls.Add(TSPButton);
            panel1.Controls.Add(file);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(delayBox);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(outputDelay);
            panel1.Controls.Add(FileChoose);
            panel1.Controls.Add(SearchButton);
            panel1.Controls.Add(DFSButton);
            panel1.Controls.Add(BFSButton);
            panel1.Controls.Add(Algorithm);
            panel1.Controls.Add(Input_Label);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 634);
            panel1.TabIndex = 0;
            // 
            // TSP
            // 
            TSP.AutoSize = true;
            TSP.Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TSP.ForeColor = Color.FromArgb(230, 211, 179);
            TSP.Location = new Point(141, 241);
            TSP.Name = "TSP";
            TSP.Size = new Size(44, 26);
            TSP.TabIndex = 16;
            TSP.Text = "TSP";
            // 
            // TSPButton
            // 
            TSPButton.Location = new Point(102, 241);
            TSPButton.MinimumSize = new Size(22, 22);
            TSPButton.Name = "TSPButton";
            TSPButton.Size = new Size(39, 22);
            TSPButton.TabIndex = 13;
            TSPButton.Text = "toggleButton1";
            TSPButton.UseVisualStyleBackColor = true;
            // 
            // file
            // 
            file.AutoSize = true;
            file.Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point);
            file.ForeColor = Color.FromArgb(230, 211, 179);
            file.Location = new Point(49, 270);
            file.Name = "file";
            file.Size = new Size(112, 26);
            file.TabIndex = 15;
            file.Text = "Filename : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Poppins Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(230, 211, 179);
            label6.Location = new Point(189, 387);
            label6.Name = "label6";
            label6.Size = new Size(46, 31);
            label6.TabIndex = 14;
            label6.Text = "ms";
            // 
            // delayBox
            // 
            delayBox.Font = new Font("Poppins Medium", 11.249999F, FontStyle.Bold, GraphicsUnit.Point);
            delayBox.Location = new Point(92, 388);
            delayBox.Name = "delayBox";
            delayBox.Size = new Size(77, 32);
            delayBox.TabIndex = 12;
            delayBox.TextChanged += delayBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(230, 211, 179);
            label1.Location = new Point(92, 354);
            label1.Name = "label1";
            label1.Size = new Size(152, 31);
            label1.TabIndex = 13;
            label1.Text = "Output Delay";
            // 
            // outputDelay
            // 
            outputDelay.Location = new Point(79, 426);
            outputDelay.Maximum = 1000;
            outputDelay.Name = "outputDelay";
            outputDelay.Size = new Size(173, 45);
            outputDelay.TabIndex = 12;
            outputDelay.Value = 10;
            outputDelay.Scroll += outputDelay_Scroll;
            // 
            // FileChoose
            // 
            FileChoose.BackColor = Color.FromArgb(190, 158, 130);
            FileChoose.Font = new Font("Poppins Medium", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FileChoose.Location = new Point(46, 308);
            FileChoose.Margin = new Padding(3, 2, 3, 2);
            FileChoose.Name = "FileChoose";
            FileChoose.Size = new Size(247, 32);
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
            SearchButton.Location = new Point(92, 473);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(152, 35);
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
            DFSButton.Location = new Point(126, 219);
            DFSButton.Name = "DFSButton";
            DFSButton.Size = new Size(61, 29);
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
            BFSButton.Location = new Point(126, 198);
            BFSButton.Name = "BFSButton";
            BFSButton.Size = new Size(59, 29);
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
            Algorithm.Location = new Point(102, 164);
            Algorithm.Name = "Algorithm";
            Algorithm.Size = new Size(117, 31);
            Algorithm.TabIndex = 8;
            Algorithm.Text = "Algorithm";
            // 
            // Input_Label
            // 
            Input_Label.AutoSize = true;
            Input_Label.Font = new Font("Poppins Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            Input_Label.ForeColor = Color.FromArgb(190, 158, 130);
            Input_Label.Location = new Point(3, 54);
            Input_Label.Name = "Input_Label";
            Input_Label.Size = new Size(79, 37);
            Input_Label.TabIndex = 5;
            Input_Label.Text = "Input";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(59, 44, 26);
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(364, 52);
            panel3.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(190, 158, 130);
            panel2.Controls.Add(Runtime);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(Nodes);
            panel2.Controls.Add(Steps);
            panel2.Controls.Add(Route);
            panel2.Controls.Add(MazeGrid);
            panel2.Controls.Add(Output_Label);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(328, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(936, 634);
            panel2.TabIndex = 1;
            // 
            // Runtime
            // 
            Runtime.AutoSize = true;
            Runtime.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Runtime.ForeColor = Color.FromArgb(81, 62, 42);
            Runtime.Location = new Point(265, 474);
            Runtime.Name = "Runtime";
            Runtime.Size = new Size(133, 34);
            Runtime.TabIndex = 12;
            Runtime.Text = "Runtime : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(81, 62, 42);
            label5.Location = new Point(28, 631);
            label5.Name = "label5";
            label5.Size = new Size(211, 34);
            label5.TabIndex = 11;
            label5.Text = "Execution Time : ";
            // 
            // Nodes
            // 
            Nodes.AutoSize = true;
            Nodes.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Nodes.ForeColor = Color.FromArgb(81, 62, 42);
            Nodes.Location = new Point(28, 597);
            Nodes.Name = "Nodes";
            Nodes.Size = new Size(100, 34);
            Nodes.TabIndex = 10;
            Nodes.Text = "Nodes :";
            // 
            // Steps
            // 
            Steps.AutoSize = true;
            Steps.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Steps.ForeColor = Color.FromArgb(81, 62, 42);
            Steps.Location = new Point(28, 563);
            Steps.Name = "Steps";
            Steps.Size = new Size(107, 34);
            Steps.TabIndex = 9;
            Steps.Text = "Steps  : ";
            // 
            // Route
            // 
            Route.AutoSize = true;
            Route.Font = new Font("Poppins Medium", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Route.ForeColor = Color.FromArgb(81, 62, 42);
            Route.Location = new Point(28, 505);
            Route.Name = "Route";
            Route.Size = new Size(109, 34);
            Route.TabIndex = 8;
            Route.Text = "Route  : ";
            // 
            // MazeGrid
            // 
            MazeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MazeGrid.Location = new Point(265, 121);
            MazeGrid.Name = "MazeGrid";
            MazeGrid.RowHeadersWidth = 51;
            MazeGrid.RowTemplate.Height = 25;
            MazeGrid.Size = new Size(350, 350);
            MazeGrid.TabIndex = 7;
            // 
            // Output_Label
            // 
            Output_Label.AutoSize = true;
            Output_Label.Font = new Font("Poppins Medium", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            Output_Label.ForeColor = Color.FromArgb(81, 62, 42);
            Output_Label.Location = new Point(0, 54);
            Output_Label.Name = "Output_Label";
            Output_Label.Size = new Size(99, 37);
            Output_Label.TabIndex = 6;
            Output_Label.Text = "Output";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(59, 44, 26);
            panel4.Controls.Add(Title);
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(936, 52);
            panel4.TabIndex = 4;
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.BackColor = Color.Transparent;
            Title.Font = new Font("Poppins Medium", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            Title.ForeColor = Color.FromArgb(230, 211, 179);
            Title.Location = new Point(251, 0);
            Title.Name = "Title";
            Title.Size = new Size(258, 57);
            Title.TabIndex = 2;
            Title.Text = "Hunting Duit";
            Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(207, 46);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(7, 6);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 634);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Hunting Duit";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)outputDelay).EndInit();
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
        private Label Route;
        private Label label5;
        private Label Nodes;
        private Label Steps;
        private Button FileChoose;
        private Label label6;
        private TextBox delayBox;
        private Label label1;
        private TrackBar outputDelay;
        private Label Runtime;
        private Label file;
        private Toggle.ToggleButton TSPButton;
        private Label TSP;
    }
}