using System;
using System.Collections.Generic;
using System.IO;
using NodeSpace;

namespace GraphSpace;
class Graph {
    public List<Node> nodes;
    public Dictionary<Node, List<Node>> adjList;
    public int treasureCount = 0;
    public int nodedfschecked = 0;
    
    public Graph() {
        nodes = new List<Node>();
        adjList = new Dictionary<Node, List<Node>>();
    }

    public void makeGraph(string filename){
        string[] lines = File.ReadAllLines(filename);
        int numRows = lines.Length;
        int numCols = lines[0].Split(' ').Length;

        // Add nodes to graph
        for (int i = 0; i < numRows; i++) {
            string[] row = lines[i].Split(' ');
            for (int j = 0; j < numCols; j++) {
                string val = row[j];
                bool isStart = (val == "K");
                bool isTreasure = (val == "T");
                if(val == "T") treasureCount++;
                AddNode(i * numCols + j, isStart, isTreasure);
            }
        }

        // Add edges to graph
        for (int i = 0; i < numRows; i++) {
            string[] row = lines[i].Split(' ');
            for (int j = 0; j < numCols; j++) {
                string val = row[j];
                int nodeIndex = i * numCols + j;
                Node node = nodes[nodeIndex];
                if (val == "X") {
                    continue;
                }
                if (j > 0 && row[j-1] != "X") {  // left neighbor
                    Node neighbor = nodes[nodeIndex - 1];
                    AddEdge(node, neighbor);
                }
                if (j < numCols-1 && row[j+1] != "X") {  // right neighbor
                    Node neighbor = nodes[nodeIndex + 1];
                    AddEdge(node, neighbor);
                }
                if (i > 0 && lines[i-1].Split(' ')[j] != "X") {  // top neighbor
                    Node neighbor = nodes[nodeIndex - numCols];
                    AddEdge(node, neighbor);
                }
                if (i < numRows-1 && lines[i+1].Split(' ')[j] != "X") {  // bottom neighbor
                    Node neighbor = nodes[nodeIndex + numCols];
                    AddEdge(node, neighbor);
                }
            }
        }
    }

    public void AddNode(int val, bool isStart=false, bool isTreasure=false) {
        Node node = new Node(val, isStart, isTreasure);
        nodes.Add(node);
        adjList[node] = new List<Node>();
    }
    
    public void AddEdge(Node node1, Node node2) {
        // check if the nodes are already a neighbor
        if (adjList[node1].Contains(node2)) {
            return;
        }
        adjList[node1].Add(node2);
        adjList[node2].Add(node1);
    }

    public void PrintGraph(){
        foreach (KeyValuePair<Node, List<Node>> kvp in adjList) {
            Console.Write(kvp.Key.val + ": ");
            foreach (Node neighbor in kvp.Value) {
                Console.Write(neighbor.val + " ");
            }
            Console.WriteLine();
        }
    }
    public List<int> treasures(){
        List<int> treasure = new List<int>();
        foreach (KeyValuePair<Node, List<Node>> kvp in adjList) {
            if (kvp.Key.isTreasure){
                treasure.Add(kvp.Key.val);
            }
        }

        return treasure;
    }

    public List<int> removeTreasure (List<int> temp, Node n){
        temp.RemoveAll(r => r == n.val);
        return temp;
    }

    public Tuple<List<Node>, List<int>> TSPDFS(int ctr, Node awal, List<int> tc, List<int> visitedNode, List<int> visual, List<Node> res, Stack<Node> simpulE){
        if(awal.isStart){
            res.Add(awal);
            return new Tuple<List<Node>, List<int>> (res, visual);
        } else{
            int count = 0;
            bool tai = false, ada = false;
            for(int i=adjList[awal].Count-1; i>=0; i--){
                // push adjacency of the first elemen
                // if it has not visited before
                if(visitedNode[adjList[awal][i].val] != 1){
                    simpulE.Push(adjList[awal][i]);
                    count++;
                } else{
                }
                tai = true;
            }
            res.Add(awal);
            visual.Add(0);
            visitedNode[awal.val] = 1;
            // gaada lagi yang bisa dikunjungin BACKTRACK
            Node fix = res[res.Count-1];
            if (count == 0 && tai == true){
                int idx = 2;
                int size = res.Count;
                while(!ada){
                    Node hasil = res[size-idx];
                    res.Add(hasil);
                    visual.Add(1);
                    for (int j=0; j<adjList[hasil].Count; j++){
                        int hai = adjList[hasil][j].val;
                        if (visitedNode[hai] == 0){
                            ada = true;
                            fix = adjList[hasil][j];
                            break;
                        }
                    }
                    idx++;
                }
            }
            if (ada){
                return TSPDFS(ctr, fix, tc, visitedNode, visual, res, simpulE);
            } else{
                return TSPDFS(ctr, simpulE.Peek(), tc, visitedNode, visual, res, simpulE);
            }
        }
    }

    public Tuple<List<Node>, List<int>> DFS(int ctr, Node awal, List<int> tc, List<int> visitedNode, List<int> visual, List<Node> res, Stack<Node> simpulE){
        if(tc.Count == 0){
            //basis dan kalau stack blom kosong
            return new Tuple<List<Node>, List<int>> (res, visual);
        } else{
            res.Add(awal);
            visual.Add(0);
            visitedNode[awal.val] = 1;
            nodedfschecked++;
            if(awal.isStart){
                for(int i=0; i<adjList[awal].Count; i++){
                    //push adjacency of the first elemen
                    simpulE.Push(adjList[awal][i]);
                }
                return DFS(ctr, simpulE.Peek(), tc, visitedNode, visual, res, simpulE);
            } else {
                Node temp = simpulE.Pop();
                int count = 0;
                bool tai = false, ada = false;
                for(int i=0; i<adjList[awal].Count; i++){
                    // push adjacency of the first elemen
                    // if it has not visited before
                    if(visitedNode[adjList[awal][i].val] != 1){
                        simpulE.Push(adjList[awal][i]);
                        count++;
                    }
                    tai = true;
                }
                if(awal.isTreasure){
                    tc = removeTreasure(tc, awal);
                }
                // gaada lagi yang bisa dikunjungin BACKTRACK
                Node fix = res[res.Count-1];
                if (count == 0 && tai == true && (tc.Count != 0)){
                    int idx = 2;
                    int size = res.Count;
                    while(!ada){
                        Node hasil = res[size-idx];
                        res.Add(hasil);
                        visual.Add(1);
                        for (int j=0; j<adjList[hasil].Count; j++){
                            int hai = adjList[hasil][j].val;
                            if (visitedNode[hai] == 0){
                                ada = true;
                                fix = adjList[hasil][j];
                                break;
                            }
                        }
                        idx++;
                    }
                }
                int bt = res.Count;
                if(ada && tc.Count != 0){
                    return DFS(ctr, fix, tc, visitedNode, visual, res, simpulE);
                } else{
                    if(tc.Count != 0){
                        return DFS(ctr, simpulE.Peek(), tc, visitedNode, visual, res, simpulE);
                    } else {
                        return new Tuple<List<Node>, List<int>> (res, visual);
                    }
                }
            }
        }
    }

    public List<Node> BFSHelper(Node start, int goal)
    {
        Queue<List<Node>> path = new Queue<List<Node>>();
        path.Enqueue(new List<Node> { start });

        // while loop until the first element in the queue contains the goal
        while (path.Count > 0)
        {
            // dequeue the first element in the queue
            List<Node> pathTemp = path.Dequeue();
            Node lastNode = pathTemp[pathTemp.Count - 1];

            // if the last node in the path is the goal, return the path
            if (lastNode.val == goal)
            {
                pathTemp.RemoveAt(0);
                return pathTemp;
            }

            // if the last node in the path is not the goal, enqueue all the neighbors of the last node
            foreach (Node neighbor in adjList[lastNode])
            {
                if (!pathTemp.Contains(neighbor))
                {
                    List<Node> newPath = new List<Node>(pathTemp);
                    newPath.Add(neighbor);
                    path.Enqueue(newPath);
                }
            }
        }


        List<Node> result = new List<Node>();
        return result;
    }
    public List<Node> BFS()
    {
        Node start = nodes.Find(x => x.isStart);
        List<int> treasure_list = treasures();
        List<Node> result = new List<Node>();
        List<Node> pathTemp = new List<Node>();
        result.Add(start);
        foreach(int treasure in treasure_list){
            result.AddRange(BFSHelper(start, treasure));
            start = result[result.Count - 1];
        }
        return result;
    }
}
