using System;
using System.IO;
using System.Collections.Generic;
using NodeSpace;
using GraphSpace;
class Program
{
    static void Main(string[] args)
    {
        Graph map = new Graph();
        string filename;
        while (true){
            Console.Write("Enter filename: ");
            filename = Console.ReadLine();
            try {
                string[] lines = System.IO.File.ReadAllLines("../test/" + filename);
                map.makeGraph("../test/" + filename);
                break;
            } catch (System.IO.FileNotFoundException) {
                Console.WriteLine("File not found");
            }
        }
        map.PrintGraph();
        List<int> visited = new List<int>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        Node start = map.nodes.Find(node => node.isStart);

        List<Node> res = new List<Node>();
        Stack<Node> simpulE = new Stack<Node>();
        List<Node> hasil = map.dfsres(0, start, visited, res, simpulE);

        Console.WriteLine(hasil.Count);
        for (int i=0; i<hasil.Count; i++){
            Console.WriteLine("Hasilnya " + hasil[i].val + " ");
        }
    }
}