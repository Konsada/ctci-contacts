using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node();
            //while (true)
            //{
            //    Console.WriteLine("Name to add: ");
            //    string[] line = { "add hack", "add hackerrank", "find hac", "find hak" };//Console.ReadLine().Split();
            //    string cmd = line[0];
            //    string name = line[1];
            //    switch (cmd)
            //    {
            //        case "add":
            //            Add(root, name);
            //            break;
            //        case "find":
            //            int subsequents = Find(root, name);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            Add(root, "hack");
            Add(root, "hackerrank");
            Add(root, "hacker");
            Console.WriteLine(Find(root, "hac"));
            Console.WriteLine(Find(root, "hak"));
        }

        private static int Find(Node node, string name)
        {
            if (node == null) return 0;
            if(name != "")
            {
                char c = name.ElementAt(0);
                string sub = name.Substring(1, name.Length - 1);
                if (!node.Children.ContainsKey(c)) return 0;
                else { return Find(node.Children[c], sub); }
            }
            else
            {
                if (node.Children.Count == 0) return 1;

                else
                {
                    int x = 0;

                    foreach (Node child in node.Children.Values)
                    {
                        x += Find(child, "");
                    }
                    return x;
                }
            }
        }

        public static void Add(Node node, string name)
        {
            if (node == null)
            {
                return;
            }
            if (name == "")
            {
                node.isWord = true;
                return;
            }

            char c = name.ElementAt(0);
            string sub = name.Substring(1, name.Length - 1);

            if (node.Children.ContainsKey(c))
            {
                Add(node.Children[c], name.Substring(1, name.Length - 1));
            }
            else
            {
                node.Children.Add(c, new Node(c));
                Add(node.Children[c], sub);
            }
        }
        public class Node
        {
            public char data;
            public Dictionary<char, Node> Children = new Dictionary<char, Node>();
            public bool isWord = false;
            public Node()
            {

            }
            public Node(char c)
            {
                data = c;
            }
        }

    }
}
