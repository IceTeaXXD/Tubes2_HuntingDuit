using System;
using System.Collections.Generic;
using System.IO;
using NodeSpace;

namespace GraphSpace;
class Graph {
    public List<Node> nodes;
    public Dictionary<Node, List<Node>> adjList;
    
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
}