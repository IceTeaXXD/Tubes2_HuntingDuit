using System;
using System.IO;
using System.Collections.Generic;
using NodeSpace;
using GraphSpace;

class Program {
    static void Main(string[] args) {
        Graph graph = new Graph();
        string filename = "../test/maze1.txt";
        graph.makeGraph(filename);

        // Print adjacency list
        graph.PrintGraph();
    }
}