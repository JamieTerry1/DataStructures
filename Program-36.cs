using System;
using System.Collections.Generic;
using System.Linq;

namespace Week09
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph myGraph1 = new Graph();       //directed graph
            myGraph1.AddVertex(100);
            myGraph1.AddVertex(10);
            myGraph1.AddVertex(20);
            myGraph1.AddVertex(30);
            myGraph1.AddVertex(5);
            myGraph1.AddEdge(20, 5);
            myGraph1.AddEdge(10, 20);
            myGraph1.AddEdge(10, 50);
            myGraph1.AddEdge(50, 30);
            myGraph1.AddEdge(20, 50);
            myGraph1.AddEdge(10, 30);
            myGraph1.DisplayEdges();
            myGraph1.DisplayVertices();

            //Graph myGraph2 = new Graph(true);   //directed graph
            //Graph myGraph3 = new Graph(false);  //undirected graph
            //myGraph3.AddVertex(100);
            //myGraph3.AddVertex(10);
            //myGraph3.AddVertex(20);
            //myGraph3.AddVertex(30);
            //myGraph3.AddEdge(10, 20);
            //myGraph3.AddEdge(10, 50);
            //myGraph3.AddEdge(2020, 2021);
            //myGraph3.RemoveVertex(10);
            //myGraph3.RemoveVertex(2021);
            //myGraph3.DisplayEdges();
            //myGraph3.DisplayVertices();


            myGraph1.Dijkstra(10, 5);
        }
    }
    public class Vertex<T> //just a node
    {
        public T Label { get; set; }
        //public bool WasVisited { get; set; }

        public Vertex(T newLabel)
        {
            Label = newLabel;
        }
    }

    class Graph
    {
        //DATA
        //G = (V, E) graph is a pair, V - set of vertices, E - set of edges, Adjacency List
        List<Vertex<int>> vertices = new List<Vertex<int>>();
        List<List<int>> adjacencyList = new List<List<int>>();
        public bool isDirectedGraph { get; private set; }


       //method to find the minimum distance to the next vertex 
       //RUNTIME: O(n)
       private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            //min is the max value 
            int min = int.MaxValue;
            //the starting position of the min values is 0
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                //for every bool value that is false, and the distance is less than the min value 
                if(shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    //set the minimum value to the value of distance at index v
                    min = distance[v];
                    //set the min Index to the value of v, to move to the next position 
                    minIndex = v;
                }
            }

            //retrns times travelled 
            return minIndex;
        }


        //implementation of the Dijkstra algorithm 
        //RUNTIME: O(n^2)
        public void Dijkstra(int source, int destination)
        {
            //finds the vertices with label of source 
            int sourceIndex = FindIndex(source);

            //array that holds distances 
            int[] distance = new int[vertices.Count];
            //bool array to determine if edge exists 
            bool[] shortestPathTreeSet = new bool[vertices.Count];

            //sets distance values as max value
            //sets all bool values in shortestPathTreeSet to false 
            for (int i = 0; i < vertices.Count; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            //the distance where we are starting is a distance of 0
            distance[sourceIndex] = 0;

            //traversal to find the shortest path 
            for (int count = 0; count < vertices.Count - 1; ++count)
            {
                //int u holds the minimum distance to the destination
                int u = MinimumDistance(distance, shortestPathTreeSet, vertices.Count);
                //the boolean value changes to 0, to indiacte it has been visited 
                shortestPathTreeSet[u] = true;

                //if the shorest path is false (not visited) and the adjaceny list shows an edge from u to v, and the distance is not equal to max value, and the distance of u + 1, is greater than the distance of v
                //change the distance of v to the distance of u + 1
                for (int v = 0; v < vertices.Count; ++v)
                    if (!shortestPathTreeSet[v] && adjacencyList.ElementAt(u).Contains(vertices.ElementAt(v).Label) && distance[u] != int.MaxValue && distance[u] + 1 < distance[v])
                        distance[v] = distance[u] + 1;
            }
                
            //prints if there is a path and the distance 
            if (distance[FindIndex(destination)] < int.MaxValue)
            {
                Console.WriteLine("There is a path from " + source + " to " + destination);
                Console.WriteLine("The distance is " + distance[FindIndex(destination)]);
            }
            else
            {
                Console.WriteLine("There is no path");
            }


            }

        //METHODS - action
        //add a new vertex
        public void AddVertex(int label)
        {
            vertices.Add(new Vertex<int>(label));
            adjacencyList.Add(new List<int>());
        }

        //add a new edge, options: weight=1, directed/undirected graph
        public void AddEdge(int originLabel, int destLabel)
        {
            AddEdge(originLabel, destLabel, isDirectedGraph);
        }
        
        private void AddEdge(int originLabel, int destLabel, bool isDirected)
        {
            //find origin in vertices
            int i = FindIndex(originLabel);

            if (i == -1)
            //throw new Exception($"{originLabel} vertex does not exist yet");
            {
                AddVertex(originLabel);
                i = vertices.Count - 1;
            }

            adjacencyList[i].Add(destLabel);

            int j = FindIndex(destLabel);
            if(j==-1)
                AddVertex(destLabel);

            if (isDirected == false)
            {
                AddEdge(destLabel, originLabel, true);
            }
        }


        //find index of a vertex in a list of vertices given a label
        public int FindIndex(int label)
        {
            for (int i = 0; i < vertices.Count; i++)
                if (vertices[i].Label == label)
                {
                    return i;
                }
            return -1;
        }


        //remove an edge
        public void RemoveEdge(int originLabel, int destLabel)
        {
            RemoveEdge(originLabel, destLabel, isDirectedGraph);
        }

        private void RemoveEdge(int originLabel, int destLabel, bool isDirected)
        {
            //find origin in vertices
            int i = FindIndex(originLabel);

            if (i == -1)
                throw new Exception($"{originLabel} vertex does not exist yet");


            //adjacencyList[i].Add(destLabel);
            if(adjacencyList[i].Remove(destLabel) == false)
                throw new Exception($"{destLabel} was not found in the list"); 

            if (isDirected == false)
            {
                RemoveEdge(destLabel, originLabel, true);
            }
        }
        //remove vertex - long
        public void RemoveVertex(int label)
        {
            int i = FindIndex(label);

            if (i == -1)
                throw new Exception($"{label} vertex does not exist");

            vertices.RemoveAt(i);
            adjacencyList.RemoveAt(i);

            //to do - remove "label" from all the other lists
            foreach(var list in adjacencyList)
            {
                while (list.Remove(label))
                    ;
            }

        }

        //display edges
        public void DisplayEdges()
        {
            Console.WriteLine("Displaying Adjacency List .... ");
            for(int i = 0; i< adjacencyList.Count; i++)
            {
                Console.Write(vertices[i].Label+ ": ");
               

                foreach(var label in adjacencyList[i])
                    Console.Write(label + " ");


                Console.WriteLine();
            }
        }

        //display vertices
        public void DisplayVertices()
        {
            Console.WriteLine("Displaying Vertices .... ");
            foreach(Vertex<int> v in vertices)
                Console.Write(v.Label+" ");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        //CTOR
        public Graph(bool isDirectedGraph = true)
        {
            this.isDirectedGraph = isDirectedGraph;
        }
        //n/a
    }
}
