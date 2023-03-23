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
        List<Node> BFSPath = map.BFS();
        foreach (Node node in BFSPath){
            Console.Write(node.val + " ");
        } 

        // Node start = map.nodes.Find(x => x.isStart);
        // // // DFS
        // List<int> path = new List<int>();
        // for (int i = 0 ; i < map.nodes.Count ; i++){
        //     path.Add(0);
        // }
        // List<Node> res = new List<Node>();
        // List<int> visual = new List<int>();
        // Stack<Node> simpulE = new Stack<Node>();
        // List<int> tc = map.treasures();
        // Tuple<List<Node>, List<int>> test = map.DFS(0, start ,tc, path, visual, res, simpulE);
        // List<Node> hasil = test.Item1;
        // List<int> gui = test.Item2;

        // Console.Write("Treasure Path DFS : ");
        // foreach (Node node in hasil){
        //     Console.Write(node.val + " ");
        // }
        // Console.WriteLine("");
        // Console.Write("Treasure Track DFS : ");
        // foreach (int n in gui){
        //     Console.Write(n + " ");
        // }
        // Console.WriteLine("\nNode yang dicek DFS : " + map.nodedfschecked + "");

        // // // BFS
        // // List<int> path2 = new List<int>();
        // // for (int i = 0 ; i < map.nodes.Count ; i++){
        // //     path2.Add(0);
        // // }
        // // List<Node> res2 = new List<Node>();
        // // Queue<Node> simpulE2 = new Queue<Node>();
        // // List<Node> hasil2 = map.BFS(0,map.nodes[0], path2, res2, simpulE2);

        // // Console.Write("Treasure Path BFS : ");
        // // foreach (Node node in hasil2){
        // //     Console.Write(node.val + " ");
        // // }
        // // Console.WriteLine("\nNode yang dicek BFS : " + map.nodedfschecked + "");

        // // TSP
        // List<int> path3 = new List<int>();
        // for (int i = 0 ; i < map.nodes.Count ; i++){
        //     path3.Add(0);
        // }
        // List<Node> res3 = new List<Node>();
        // Stack<Node> simpulE3 = new Stack<Node>();
        // Tuple<List<Node>, List<int>> test3 = map.TSPDFS(0, res[res.Count-1],tc, path3, gui, hasil, simpulE3);
        // List<Node> hasil3 = test3.Item1;
        // List<int> gui3 = test3.Item2;

        // Console.Write("Treasure Path TSP : ");
        // foreach (Node node in hasil3){
        //     Console.Write(node.val + " ");
        // }
        // Console.WriteLine("");
        // Console.Write("Treasure Track TSP : ");
        // foreach (int n in gui){
        //     Console.Write(n + " ");
        // }
        // Console.WriteLine("\nNode yang dicek TSP : " + map.nodedfschecked + "");
    }
}