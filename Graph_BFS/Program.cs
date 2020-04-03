using System;
using System.Linq;
using System.Collections.Generic;

public class Node<T>
{
    public T Value;

    public Node(T val)
    {
        Value = val;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class Graph<T>
{
    //private readonly List<Node<T>> _nodes;
    private readonly Dictionary<Node<T>, List<Node<T>>> _adj;

    public Graph()
    {
        //_nodes = new List<Node<T>>();
        _adj = new Dictionary<Node<T>, List<Node<T>>>();
    }

    public void AddEdge(Node<T> node1, Node<T> node2)
    {
        if (!_adj.ContainsKey(node1))
            _adj[node1] = new List<Node<T>>();
        if (!_adj.ContainsKey(node2))
            _adj[node2] = new List<Node<T>>();
        _adj[node1].Add(node2);
        _adj[node2].Add(node1);
    }

    public Stack<Node<T>> ShortestPath(Node<T> source, Node<T> dest)
    {
        var path = new Dictionary<Node<T>, Node<T>>();
        var distance = new Dictionary<Node<T>, int>();
        foreach (var node in _adj.Keys)
        {
            distance[node] = -1;
        }
        distance[source] = 0;
        var q = new Queue<Node<T>>();
        q.Enqueue(source);
        while (q.Count > 0)
        {
            var node = q.Dequeue();           

           foreach (var adj in _adj[node].Where(n => distance[n] == -1))
                {
                distance[adj] = distance[node] + 1;
                path[adj] = node;
                q.Enqueue(adj);
            }
        }
        var res = new Stack<Node<T>>();
        var cur = dest;
        while (cur != source)
        {
            res.Push(cur);
            cur = path[cur];
        }
        res.Push(source);
        return res;
    }
}

public class Program
{
    public static void Main()
    {
        var g = new Graph<int>();
        var n1 = new Node<int>(1);
        var n2 = new Node<int>(2);
        var n3 = new Node<int>(3);
        var n4 = new Node<int>(4);
        var n5 = new Node<int>(5);
        var n6 = new Node<int>(6);
        var n7 = new Node<int>(7);
        g.AddEdge(n1, n2);
        g.AddEdge(n1, n3);
        g.AddEdge(n1, n4);
        g.AddEdge(n4, n5);
        g.AddEdge(n2, n6);
        g.AddEdge(n4, n7);
        g.AddEdge(n5, n6);
        g.AddEdge(n6, n7);

        Console.WriteLine("Shortest path is: {0}", string.Join("->", g.ShortestPath(n1, n7)));
        Console.ReadKey();
    }
}