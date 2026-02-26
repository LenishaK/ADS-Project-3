using System;
using System.Linq;

namespace ADS-Project-3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Influencer Detection ====");

            string filePath = "data.txt"; 
            bool weighted = false;  

            try
            {
                var graph = GraphLoader.LoadFromEdgeList(filePath, weighted);

                Console.WriteLine($"Graph loaded. Nodes: {graph.NodeCount}");

                var scores = weighted 
                  ? InfluenceCalculator.ComputeInfluenceWeighted(graph)
                  : InfluenceCalculator.ComputeInfluenceUnweighted(graph);

                var top = scores 
                   .OderByDescending(kv => kv.Value)
                   .Take(10);

                Console.WriteLine("\nTop Influencers: ");
                foreach (var kv in top)
                {
                    Console.WriteLine($"Node {kv.key} -> Score: {kv.Value:F4}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: + ex.Message");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}