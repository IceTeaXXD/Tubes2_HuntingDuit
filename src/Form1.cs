using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Windows.Forms;
using GraphSpace;
using NodeSpace;
using static System.Windows.Forms.LinkLabel;

namespace Tubes2_HuntingDuit
{
    public partial class Form1 : Form
    {
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

            MazeGrid.ReadOnly = true; // Set the DataGridView to read-only
            MazeGrid.Enabled = false;
            // Populate the DataGridView with the maze
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    MazeGrid.Rows[i].Cells[j].Value = ""; // Clear any existing text
                    MazeGrid.Rows[i].Cells[j].ReadOnly = true; // Set the cell to read-only
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
            MazeGrid.ColumnCount = row;
            MazeGrid.RowCount = col;

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
            MazeGrid.ReadOnly = true; // Set the DataGridView to read-only
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
                MazeGrid.Rows[x].Cells[y].Value = "Treasure";
                MazeGrid.Rows[x].Cells[y].Style.BackColor = Color.Yellow;
                MazeGrid.Rows[x].Cells[y].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < path.Length; i++)
            {
                await Task.Delay(300);
                MazeGrid.Rows[path[i] / col].Cells[path[i] % col].Style.BackColor = Color.Green;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            MazeReset();
        }

        private void FileInputBox_Enter(object sender, EventArgs e)
        {
            if (FileInputBox.Text == "ex : 'maze1.txt'")
            {
                FileInputBox.Text = "";
                FileInputBox.ForeColor = Color.Black;
            }
        }

        private void FileInputBox_Leave(object sender, EventArgs e)
        {
            if (FileInputBox.Text == "")
            {
                FileInputBox.Text = "ex : 'maze1.txt'";
                FileInputBox.ForeColor = Color.DarkGray;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            MazeReset();
            if (FileInputBox.Text == "ex : 'maze1.txt'")
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
            try
            {
                lines = System.IO.File.ReadAllLines("../../../../test/" + FileInputBox.Text);

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("File not found");
                return;
            }
            Graph map = new Graph();
            map.makeGraph("../../../../test/" + FileInputBox.Text);
            int row = lines.Length;
            int col = lines[0].Split(' ').Length;

            // DFS
            int[] pathresult = new int[map.nodes.Count];
            string pathresultStr = "";
            if (DFSButton.Checked)
            {
                List<int> path = new List<int>();
                for (int i = 0; i < map.nodes.Count; i++)
                {
                    path.Add(0);
                }
                List<Node> res = new List<Node>();
                Stack<Node> simpulE = new Stack<Node>();
                List<Node> hasil = map.dfsres(0, map.nodes[0], path, res, simpulE);

                pathresult = new int[hasil.Count];
                foreach (Node node in hasil)
                {
                    pathresult[hasil.IndexOf(node)] = node.val;
                    pathresultStr += node.val.ToString() + " ";
                }

                // MessageBox.Show("Treasure Path DFS : " + pathresultStr);
                matToGird(pathresult, map.way(), map.treasures(), row, col);
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
                List<Node> hasil2 = map.bfsres(0, map.nodes[0], path2, res2, simpulE2);

                pathresult = new int[hasil2.Count];
                foreach (Node node in hasil2)
                {
                    pathresult[hasil2.IndexOf(node)] = node.val;
                    pathresultStr += node.val.ToString() + " ";
                }

                // map.BFS();
                // Console.Write("Treasure Path BFS : ");
                // Node lastElem = map.path.Last().Key;
                // List<Node> BFSPath = new List<Node>();
                // BFSPath.Add(lastElem);
                // while (true)
                // {
                //     lastElem = map.path.Find(x => x.Key == lastElem).Value;
                //     BFSPath.Add(lastElem);
                //     if (lastElem.isStart)
                //     {
                //         break;
                //     }
                // }

                // BFSPath.Reverse();
                // pathresult = new int[BFSPath.Count];
                // foreach (Node node in BFSPath)
                // {
                //     pathresult[BFSPath.IndexOf(node)] = node.val;
                //     pathresultStr += node.val.ToString() + " ";
                // }
                // MessageBox.Show("Treasure Path BFS : " + pathresultStr);
                matToGird(pathresult, map.way(), map.treasures(), row, col);
            }
        }
    }
}