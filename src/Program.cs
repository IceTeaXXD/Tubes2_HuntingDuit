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
    }
}