using System;
using System.IO;
using System.Collections.Generic;
using MazeGraphSpace;
class Program
{
    static void Main(string[] args)
    {
        MazeGraph mazeGraph = new MazeGraph();
        string filename;
        while (true){
            Console.Write("Enter filename: ");
            filename = Console.ReadLine();
            try {
                string[] lines = System.IO.File.ReadAllLines("../test/" + filename);
                break;
            } catch (System.IO.FileNotFoundException) {
                Console.WriteLine("File not found");
            }
        }
        mazeGraph.BuildGraphFromFile("../test/" + filename);
        mazeGraph.PrintGraph();
    }
}