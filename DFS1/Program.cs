using System;
using System.Collections.Generic;

namespace DFS1
{
    class Graph
    {
        int V = 0;
        private List<int>[] adj;

        Graph(int v)
        {
            V = v;
            adj = new List<int>[v];

            for (int i = 0; i < v; i++)
                adj[i] = new List<int>();
        }

        void addEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        void DFSUtil(int v, bool[] visited)
        {
            Console.WriteLine(v);
            visited[v] = true;

            foreach (int i in adj[v])
            {
                if (!visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }
        void DFS()
        {
            bool[] visited = new bool[V];
            DFSUtil(0, visited);
        }

        void BFS()
        {
            int curr = 0;
            bool[] visited = new bool[V];
            Queue<int> que = new Queue<int>();
            que.Enqueue(0);
            visited[0] = true;
            while (que.Count > 0)
            {
                curr = que.Dequeue();
                Console.WriteLine(curr);
                foreach (int i in adj[curr])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        que.Enqueue(i);
                    }
                }
            }
        }

        static void Main(string[] args)
        {


            int[] count = new int[256];
            count['a']++;
            count['a']++;
            count['b']++;
            Console.WriteLine(count['a'] == 2);

            Graph g = new Graph(5);
            g.addEdge(0, 1);
            g.addEdge(1, 2);
            g.addEdge(1, 3);
            g.addEdge(2, 4);
            g.addEdge(2, 3);

            g.DFS();
            Console.WriteLine("-----");
            g.BFS();
            Console.ReadLine();
        }
    }
}
