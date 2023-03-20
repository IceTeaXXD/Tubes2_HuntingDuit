using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Diagnostics;
using GraphSpace;
using NodeSpace;
using static System.Windows.Forms.LinkLabel;

namespace Tubes2_HuntingDuit
{
    public partial class Form1 : Form
    {
        public string filename = "";
        public Form1()
        {
            InitializeComponent();
        }

        public void MazeReset()
        {
            MazeGrid.RowHeadersVisible = false;
            MazeGrid.ColumnHeadersVisible = false;
            MazeGrid.AllowUserToAddRows = false;
            MazeGrid.AllowUserToDeleteRows = false;
            MazeGrid.AllowUserToResizeColumns = false;
            MazeGrid.AllowUserToResizeRows = false;
            MazeGrid.DefaultCellStyle.BackColor = Color.Black;
            MazeGrid.ScrollBars = ScrollBars.None;
            MazeGrid.TabStop = false;
            MazeGrid.MultiSelect = false;
            MazeGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Define the maze
            int[,] maze = new int[,]
            {
                {1,1,1,1},
                {1,1,1,1},
                {1,1,1,1},
                {1,1,1,1}
            };
            MazeGrid.ColumnCount = maze.GetLength(1);
            MazeGrid.RowCount = maze.GetLength(0);

            // Set the height of each row to make them fit the grid
            int rowHeight = MazeGrid.ClientSize.Height / MazeGrid.RowCount;
            for (int i = 0; i < MazeGrid.RowCount; i++)
            {
                MazeGrid.Rows[i].Height = rowHeight;
            }

            // Set the DataGridView properties to make the cells square and fit the grid
            MazeGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            MazeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MazeGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            MazeGrid.CurrentCell = null;

            MazeGrid.ReadOnly = true;
            MazeGrid.Enabled = false;

            // Populate the DataGridView with the maze
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    MazeGrid.Rows[i].Cells[j].Value = "";
                    MazeGrid.Rows[i].Cells[j].ReadOnly = true;
                    MazeGrid.Rows[i].Cells[j].Style.BackColor = maze[i, j] == 1 ? Color.Black : Color.White;
                }
            }
        }

        public async void matToGird(int[] path, int[] way, int[] treasures, int row, int col)
        {
            MazeGrid.RowHeadersVisible = false;
            MazeGrid.ColumnHeadersVisible = false;
            MazeGrid.AllowUserToAddRows = false;
            MazeGrid.AllowUserToDeleteRows = false;
            MazeGrid.AllowUserToResizeColumns = false;
            MazeGrid.AllowUserToResizeRows = false;
            MazeGrid.DefaultCellStyle.BackColor = Color.Black;
            MazeGrid.ScrollBars = ScrollBars.None;
            MazeGrid.TabStop = false;
            MazeGrid.MultiSelect = false;
            MazeGrid.ColumnCount = col;
            MazeGrid.RowCount = row;
            MazeGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Set the height of each row to make them fit the grid
            int rowHeight = MazeGrid.ClientSize.Height / MazeGrid.RowCount;
            for (int i = 0; i < MazeGrid.RowCount; i++)
            {
                MazeGrid.Rows[i].Height = rowHeight;
            }

            // Set the DataGridView properties to make the cells square and fit the grid
            MazeGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            MazeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MazeGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            MazeGrid.CurrentCell = null;
            MazeGrid.ReadOnly = true;
            MazeGrid.Enabled = false;

            // Colorizer
            int[,] mat = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mat[i, j] = 1;
                }
            }

            // Way path
            for (int i = 0; i < way.Length; i++)
            {
                int x = way[i] / col;
                int y = way[i] % col;
                mat[x, y] = 0;
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    MazeGrid.Rows[i].Cells[j].Value = "";
                    MazeGrid.Rows[i].Cells[j].ReadOnly = true;
                    if (mat[i, j] == 1) MazeGrid.Rows[i].Cells[j].Style.BackColor = Color.Black;
                    else MazeGrid.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            for (int i = 0; i < treasures.Length; i++)
            {
                int x = treasures[i] / col;
                int y = treasures[i] % col;
                MazeGrid.Rows[x].Cells[y].Value = "T";
                MazeGrid.Rows[x].Cells[y].Style.BackColor = Color.Yellow;
                MazeGrid.Rows[x].Cells[y].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < path.Length; i++)
            {
                await Task.Delay(outputDelay.Value);
                if (MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor == Color.White || MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor == Color.Yellow)
                {
                    MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor = Color.FromArgb(0, 255, 0);
                }
                else
                {
                    int green = MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor.G - 20;
                    if (green < 10) green = 10;
                    else if (green > 255) green = 255;
                    MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor = Color.FromArgb(0, green, 0);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MazeReset();
            delayBox.Text = "0";
            outputDelay.Value = 0;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            MazeReset();
            if (filename == "")
            {
                MessageBox.Show("Please input a filename first!");
                return;
            }
            if (!BFSButton.Checked && !DFSButton.Checked)
            {
                // show error in message box
                MessageBox.Show("Please select a search method");
                return;
            }
            string[] lines;
            lines = System.IO.File.ReadAllLines(filename);
            Graph map = new Graph();
            try
            {
                map.makeGraph(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            int row = lines.Length;
            int col = lines[0].Split(' ').Length;

            // DFS
            int[] pathresult = new int[row];
            string pathresultStr = "";
            Stopwatch stopwatch = new Stopwatch();
            if (DFSButton.Checked)
            {
                List<int> path = new List<int>();
                for (int i = 0; i < map.nodes.Count; i++)
                {
                    path.Add(0);
                }
                List<Node> res = new List<Node>();
                Stack<Node> simpulE = new Stack<Node>();
                Node start = map.nodes.Find(x => x.isStart);
                stopwatch.Start();
                List<Node> hasil = map.dfsres(0, start, path, res, simpulE);
                stopwatch.Stop();

                pathresult = new int[hasil.Count];
                for (int i = 0; i < hasil.Count; i++)
                {
                    pathresult[i] = hasil[i].val;
                }
            }
            else if (BFSButton.Checked)
            {
                List<int> path2 = new List<int>();
                for (int i = 0; i < map.nodes.Count; i++)
                {
                    path2.Add(0);
                }

                List<Node> res2 = new List<Node>();
                Queue<Node> simpulE2 = new Queue<Node>();
                stopwatch.Start();
                List<Node> hasil2 = map.bfsres(0, map.nodes[0], path2, res2, simpulE2);
                stopwatch.Stop();
                pathresult = new int[hasil2.Count];
                for (int i = 0; i < hasil2.Count; i++)
                {
                    pathresult[i] = hasil2[i].val;
                }
            }
            for (int i = 1; i < pathresult.Length; i++)
            {
                if (pathresult[i] - pathresult[i - 1] == 1)
                {
                    pathresultStr += "R ";
                }
                else if (pathresult[i] - pathresult[i - 1] == -1)
                {
                    pathresultStr += "L ";
                }
                else if (pathresult[i] - pathresult[i - 1] == col)
                {
                    pathresultStr += "D ";
                }
                else if (pathresult[i - 1] - pathresult[i] == col)
                {
                    pathresultStr += "U ";
                }
            }
            matToGird(pathresult, map.way(), map.treasures(), row, col);
            Route.Text = "Route  : " + pathresultStr;
            Steps.Text = "Steps  : " + pathresult.Count().ToString();
            HashSet<int> pathHash = new HashSet<int>();
            foreach (int number in pathresult)
            {
                pathHash.Add(number);
            }
            Runtime.Text = "Runtime : " + stopwatch.ElapsedMilliseconds.ToString() + " ms";
            Nodes.Text = "Nodes : " + pathHash.Count().ToString();
            filename = "";
        }

        private void FileChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.Multiselect = false;
            ofd.Filter = "Text Files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                Graph map = new Graph();
                try
                {
                    map.makeGraph(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                string[] lines;
                lines = System.IO.File.ReadAllLines(filename);
                int row = lines.Length;
                int col = lines[0].Split(' ').Length;
                MazeGrid.RowHeadersVisible = false;
                MazeGrid.ColumnHeadersVisible = false;
                MazeGrid.AllowUserToAddRows = false;
                MazeGrid.AllowUserToDeleteRows = false;
                MazeGrid.AllowUserToResizeColumns = false;
                MazeGrid.AllowUserToResizeRows = false;
                MazeGrid.DefaultCellStyle.BackColor = Color.Black;
                MazeGrid.ScrollBars = ScrollBars.None;
                MazeGrid.TabStop = false;
                MazeGrid.MultiSelect = false;
                MazeGrid.ColumnCount = col;
                MazeGrid.RowCount = row;
                MazeGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;

                // Set the height of each row to make them fit the grid
                int rowHeight = MazeGrid.ClientSize.Height / MazeGrid.RowCount;
                for (int i = 0; i < MazeGrid.RowCount; i++)
                {
                    MazeGrid.Rows[i].Height = rowHeight;
                }

                // Set the DataGridView properties to make the cells square and fit the grid
                MazeGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                MazeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                MazeGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                MazeGrid.CurrentCell = null;
                MazeGrid.ReadOnly = true;
                MazeGrid.Enabled = false;

                // Colorizer
                int[,] mat = new int[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        mat[i, j] = 1;
                    }
                }

                int[] way = map.way();
                int[] treasures = map.treasures();
                for (int i = 0; i < way.Length; i++)
                {
                    int x = way[i] / col;
                    int y = way[i] % col;
                    mat[x, y] = 0;
                }

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        MazeGrid.Rows[i].Cells[j].Value = "";
                        MazeGrid.Rows[i].Cells[j].ReadOnly = true;
                        if (mat[i, j] == 1) MazeGrid.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        else MazeGrid.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }

                for (int i = 0; i < treasures.Length; i++)
                {
                    int x = treasures[i] / col;
                    int y = treasures[i] % col;
                    MazeGrid.Rows[x].Cells[y].Value = "T";
                    MazeGrid.Rows[x].Cells[y].Style.BackColor = Color.Yellow;
                    MazeGrid.Rows[x].Cells[y].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
        }

        private void outputDelay_Scroll(object sender, EventArgs e)
        {
            delayBox.Text = outputDelay.Value.ToString();

        }

        private void delayBox_TextChanged(object sender, EventArgs e)
        {
            if (delayBox.Text == "")
            {
                delayBox.Text = "0";
            }
            else if (int.Parse(delayBox.Text) < 0)
            {
                delayBox.Text = "0";
            }
            else if (int.Parse(delayBox.Text) > 1000)
            {
                delayBox.Text = "1000";
            }
            outputDelay.Value = int.Parse(delayBox.Text);
        }
    }
}