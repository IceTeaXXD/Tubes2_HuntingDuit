using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Diagnostics;
using GraphSpace;
using NodeSpace;
using static System.Windows.Forms.LinkLabel;
using System.CodeDom.Compiler;

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

        public async void matToGird(int[] path, int[] way, List<int> treasures, int row, int col)
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

            for (int i = 0; i < treasures.Count; i++)
            {
                int x = treasures[i] / col;
                int y = treasures[i] % col;
                MazeGrid.Rows[x].Cells[y].Value = "T";
                MazeGrid.Rows[x].Cells[y].Style.BackColor = Color.Yellow;
                MazeGrid.Rows[x].Cells[y].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            int maxOcc = 0;
            for (int i = 0; i < path.Length; i++)
            {
                int occ = 0;
                for (int j = 0; j < path.Length; j++)
                {
                    if (path[i] == path[j]) occ++;
                }
                if (occ > maxOcc) maxOcc = occ;
            }
            //MessageBox.Show(maxOcc.ToString());
            int dec = (235 / maxOcc) - 10;
            int green = 0;
            for (int i = 0; i < path.Length; i++)
            {
                await Task.Delay(outputDelay.Value);
                if (i == 0)
                {
                    MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor = Color.Blue;
                }
                else
                {
                    if (MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor == Color.White || MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor == Color.Yellow)
                    {
                        MazeGrid.Rows[path[i - 1] / col].Cells[path[i - 1] % col].Style.BackColor = Color.FromArgb(0, 255, 0);
                        if (green != 0)
                        {
                            if (green < 10) green = 10;
                            MazeGrid.Rows[path[i - 1] / col].Cells[path[i - 1] % col].Style.BackColor = Color.FromArgb(0, green, 0);
                        }
                        MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor = Color.Blue;
                        green = 0;
                    }
                    else
                    {
                        MazeGrid.Rows[path[i - 1] / col].Cells[path[i - 1] % col].Style.BackColor = Color.FromArgb(0, 255, 0);
                        if (green != 0)
                        {
                            if (green < 20) green = 20;
                            MazeGrid.Rows[path[i - 1] / col].Cells[path[i - 1] % col].Style.BackColor = Color.FromArgb(0, green, 0);
                        }
                        green = MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor.G - 75;
                        MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor = Color.Blue;
                    }
                }
            }
            await Task.Delay(outputDelay.Value);
            MazeGrid.Rows[path[path.Length - 1] / col].Cells[path[path.Length - 1] % col].Style.BackColor = Color.FromArgb(0, 255, 0);
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
                Node start = map.nodes.Find(x => x.isStart);
                List<int> path = new List<int>();
                for (int i = 0; i < map.nodes.Count; i++)
                {
                    path.Add(0);
                }
                List<Node> res = new List<Node>();
                List<int> visual = new List<int>();
                Stack<Node> simpulE = new Stack<Node>();
                List<int> tc = map.treasures();
                Tuple<List<Node>, List<int>> test = map.DFS(0, start, tc, path, visual, res, simpulE);
                List<Node> hasil = test.Item1;
                List<int> gui = test.Item2;

                if (TSPButton.Checked)
                {
                    List<int> path3 = new List<int>();
                    for (int i = 0; i < map.nodes.Count; i++)
                    {
                        path3.Add(0);
                    }
                    List<Node> res3 = new List<Node>();
                    Stack<Node> simpulE3 = new Stack<Node>();
                    int startDFS = hasil.Count - 1;
                    Tuple<List<Node>, List<int>> test3 = map.TSPDFS(0, res[res.Count - 1], tc, path3, gui, hasil, simpulE3);
                    hasil.RemoveAt(startDFS);
                    List<Node> hasil3 = test3.Item1;
                    List<int> gui3 = test3.Item2;
                }
                pathresult = new int[hasil.Count];
                for (int i = 0; i < hasil.Count; i++)
                {
                    pathresult[i] = hasil[i].val;
                }
            }
            else if (BFSButton.Checked)
            {
                List<Node> res = map.BFS();
                if (TSPButton.Checked)
                {
                    res = map.TSPBFS(res);
                }
                pathresult = new int[res.Count];
                for (int i = 0; i < res.Count; i++)
                {
                    pathresult[i] = res[i].val;
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
                file.Text = "Filename : " + Path.GetFileName(filename);
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
                List<int> treasures = map.treasures();
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

                for (int i = 0; i < treasures.Count; i++)
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