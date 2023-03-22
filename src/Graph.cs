using System;
using System.Collections.Generic;
using System.IO;
using NodeSpace;

namespace GraphSpace;
class Graph {
    public List<Node> nodes;
    public Dictionary<Node, List<Node>> adjList;
    public List<KeyValuePair<Node,Node>> path = new List<KeyValuePair<Node,Node>>();

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

    public void BFS(){
        Queue<KeyValuePair<Node,Node>> queue = new Queue<KeyValuePair<Node,Node>>();        
        int treasures = 0;

        KeyValuePair<Node,Node> startNode = new KeyValuePair<Node,Node>(nodes.Find(node => node.isStart),null);
        queue.Enqueue(startNode);
        
        
        while (queue.Count > 0) {
            KeyValuePair<Node,Node>queueElem = queue.Dequeue();
            Node node = queueElem.Key;
            if (node.visited) {
                continue;
            }
            node.visited = true;
            // Console.WriteLine(node.val);
            if (node.isTreasure) {
                treasures++;
                
                while(queue.Count != 0) {
                    Node prevNode = queue.Dequeue().Key;
                }
            }
            foreach (Node neighbor in adjList[node]) {
                KeyValuePair<Node,Node> tempNode = new KeyValuePair<Node,Node>(neighbor,node);
                queue.Enqueue(tempNode);
            }
            path.Add(queueElem);
            if (treasureCount == treasures) {
                Console.WriteLine("Found all treasure!");
                return;
            }
        }
        
        
    }


    // public List<Node> dfsres(int ctr, Node awal, List<int> visitedNode, List<Node> res, Stack<Node> simpulE){
    //     res.Add(awal);
    //     visitedNode[awal.val] = 1;
    //     nodedfschecked++;
    //     if(awal.isStart){
    //         for(int i=0; i<adjList[awal].Count; i++){
    //             //push adjacency of the first elemen
    //             simpulE.Push(adjList[awal][i]);
    //         }
    //         return dfsres(ctr, simpulE.Peek(), visitedNode, res, simpulE);
    //     } else {
    //         Node temp = simpulE.Pop();
    //         int count = 0;
    //         bool tai = false, ada = false;
    //         for(int i=0; i<adjList[awal].Count; i++){
    //             // push adjacency of the first elemen
    //             // if it has not visited before
    //             if(visitedNode[adjList[awal][i].val] != 1){
    //                 simpulE.Push(adjList[awal][i]);
    //                 count++;
    //             }
    //             tai = true;
    //         }
    //         if(awal.isTreasure){
    //             ctr++;
    //         }
    //         // gaada lagi yang bisa dikunjungin BACKTRACK
    //         if (count == 0 && tai == true && (ctr != treasureCount)){
    //             int idx = 2;
    //             int size = res.Count;
    //             while(!ada){
    //                 Node hasil = res[size-idx];
    //                 res.Add(hasil);
    //                 for (int j=0; j<adjList[hasil].Count; j++){
    //                     int hai = adjList[hasil][j].val;
    //                     if (visitedNode[hai] == 0){
    //                         ada = true;
    //                         break;
    //                     }
    //                 }
    //                 idx++;
    //             }
    //         }

    //         if(ctr != treasureCount){
    //             return dfsres(ctr, simpulE.Peek(), visitedNode, res, simpulE);
    //         } else {
    //             return res;
    //         }
    //     }
    //     // if(ctr == treasureCount){
    //     //     //basis dan kalau stack blom kosong
    //     //     return res;
    //     // } else{
            
    //     // }
    // }
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
}
