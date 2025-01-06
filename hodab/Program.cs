using System;
using System.Collections.Generic;

namespace hodab
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("tree+++tree");
            Atree tree = new Atree();
            tree.Insert(10); 
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(25);
            Console.WriteLine("الشجرة بالشكل التصاعدي ");
            tree.PrintOrder(); 
        }
    }
   
   
    public class Anode
    {
        public int key;
        public Anode left, right;
        public int height;
        public Anode(int key)
        {
            this.key = key;
            height = 1;
        }
    }

    public class Atree
    {
        private Anode root;
        private int Height(Anode node) 
        {
            return node == null ? 0 : node.height; 
        }
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        private Anode RightRot(Anode e) 
        {
            Anode x = e.left;
            Anode l = x.right;
            x.right = e;
            e.left = l;
            e.height = Max(Height(e.left), Height(e.right));
            x.height = Max(Height(x.left), Height(x.right));
            return x;
        }
        private Anode LeftRot(Anode x) 
        {
            Anode e = x.right;
            Anode l = e.left;
            e.left = x;
            x.right = l;
            x.height = Max(Height(x.left), Height(x.right)) + 1; 
            e.height = Max(Height(e.left), Height(e.right)) + 1; 
            return e;
        }
        private int GetBalance(Anode node) 
        {
            if (node == null)
                return 0;
            return Height(node.left) - Height(node.right); 
        }
        public Anode Insert(Anode node, int key) 
        {
            if (node == null)
                return new Anode(key);
            if (key < node.key)
            {
                node.left = Insert(node.left, key); 
            }
            else if (key > node.key)
            {
                node.right = Insert(node.right, key); 
            }
            else
            {
                return node;
            }

            node.height = 1 + Max(Height(node.left), Height(node.right)); 
            int balance = GetBalance(node); 

            if (balance > 1 && key < node.left.key)
            {
                return RightRot(node);
            }

            if (balance < -1 && key > node.right.key)
            {
                return LeftRot(node); 
            }

            if (balance > 1 && key > node.left.key)
            {
                node.left = LeftRot(node.left); 
                return RightRot(node); 
            }

            if (balance < -1 && key < node.right.key)
            {
                node.right = RightRot(node.right); 
                return LeftRot(node); 
            }

            return node;
        }

        public void Insert(int key)
        {
            root = Insert(root, key); 
        }
        public void Inorder(Anode node)
        {
            if (node != null)
            {
                Inorder(node.left); 
                Console.WriteLine(node.key + "===");
                Inorder(node.right);
            }
        }
        public void PrintOrder()
        {
            Inorder(root); 
        }
    }
}
