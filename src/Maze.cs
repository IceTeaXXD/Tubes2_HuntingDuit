using System;
using System.Collections.Generic;
using System.IO;

namespace MazeGraphSpace;
public class MazeGraph {
    private Dictionary<string, List<string>> adjacencyList;

    public MazeGraph() {
        adjacencyList = new Dictionary<string, List<string>>();
    }

    public void AddVertex(string vertex) {
        adjacencyList[vertex] = new List<string>();
    }

    public void AddEdge(string vertex1, string vertex2) {
        adjacencyList[vertex1].Add(vertex2);
        adjacencyList[vertex2].Add(vertex1);
    }

    public void BuildGraphFromFile(string filename) {
        string[] lines = File.ReadAllLines(filename);
        int numRows = lines.Length;
        int numCols = lines[0].Split(' ').Length;

        for (int i = 0; i < numRows; i++) {
            string[] row = lines[i].Split(' ');
            for (int j = 0; j < numCols; j++) {
                string currNode = i + "," + j;
                string currSymbol = row[j];
                if (currSymbol == "R" || currSymbol == "K" || currSymbol == "T") {
                    AddVertex(currNode);
                    if (i > 0 && (lines[i-1].Split(' ')[j] == "R" || lines[i-1].Split(' ')[j] == "K" || lines[i-1].Split(' ')[j] == "T")) {
                        AddEdge(currNode, (i-1) + "," + j);
                    }
                    if (j > 0 && (row[j-1] == "R" || row[j-1] == "K" || row[j-1] == "T")) {
                        AddEdge(currNode, i + "," + (j-1));
                    }
                }
            }
        }
    }
    public void PrintGraph() {
        foreach (string vertex in adjacencyList.Keys) {
            Console.Write(vertex + ": ");
            foreach (string neighbor in adjacencyList[vertex]) {
                Console.Write(neighbor + " ");
            }
            Console.WriteLine();
        }
    }
}