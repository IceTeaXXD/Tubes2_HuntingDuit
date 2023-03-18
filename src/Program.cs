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

        // DFS
        List<int> path = new List<int>();
        for (int i = 0 ; i < map.nodes.Count ; i++){
            path.Add(0);
        }
        List<Node> res = new List<Node>();
        Stack<Node> simpulE = new Stack<Node>();
        List<Node> hasil = map.dfsres(0,map.nodes[0], path, res,simpulE);

        Console.Write("Treasure Path DFS : ");
        foreach (Node node in hasil){
            Console.Write(node.val + " ");
        }
        Console.WriteLine("\nNode yang dicek DFS : " + map.nodedfschecked + "");

        // BFS
        map.BFS();
        Console.Write("Treasure Path BFS : ");
        Node lastElem = map.path.Last().Key;
        List<Node> BFSPath = new List<Node>();
        BFSPath.Add(lastElem);
        while(true){
            lastElem = map.path.Find(x => x.Key == lastElem).Value;
            BFSPath.Add(lastElem);
            if(lastElem.isStart){
                break;
            }
        }

        BFSPath.Reverse();
        foreach (Node node in BFSPath){
            Console.Write(node.val + " ");
        }
        Console.WriteLine();

        Console.Write("Backtracking Path : ");
        foreach(KeyValuePair<Node,Node> node in map.path){
            Console.Write(node.Key.val + " ");
        }
    }
}