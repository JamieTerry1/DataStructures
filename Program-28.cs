/* Jamie Terry 
 * Partners: Anthony Arellano, JunBo Park
 * 
 * Implement a method that will return the nth largest value in a binary search tree. 
 * 
 */

using System;

namespace DSAHW6_Prob1_JamieTerry
{

    //binary tree node
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }

    public class BinarySearchTree
    {

        //RUNTIME: O(n)
        public static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            /* Creating this tree: 
                        50
                     /      \
                    30      70
                   /  \    /  \
                 20   40  60   80     */

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            for (int i = 1; i <= 7; i++) //for loop to itterate through 1-7 Nth largest nodes 
            {
                tree.NthLargest(i);
                Console.WriteLine();
            }


            tree.NthLargest(5); //can also directly send what Nth number you would like to look for 
        }


        //root of the binary search tree 
        public Node root;


        //constructor
        public BinarySearchTree()
        {
            root = null;
        }

        //RUNTIME: O(1)
        //function to insert nodes
        public virtual void Insert(int data)
        {
            this.root = this.InsertRec(this.root, data);
        }

        //RUNTIME: O(1)
        //a utility function that inserts a new node with a given key in the binary search tree 
        public virtual Node InsertRec(Node node, int data)
        {

            //if the tree is empty, return the new node 
            if (node == null) 
            {
                this.root = new Node(data);
                return this.root;
            }


            //is this is the only node, then return the node 
            if (data == node.data)
                return node;

            //otherwise, recure down the tree 
            if (data < node.data)
                node.left = this.InsertRec(node.left, data);

            else
                node.right = this.InsertRec(node.right, data);

            return node;

        }


        //class to store the value of count 
        public class Count
        {
            private readonly BinarySearchTree outerInstance;

            public Count(BinarySearchTree outerInstance)
            {
                this.outerInstance = outerInstance;
            }

            internal int c = 0;
        }


        //RUNTIME: O(n)
        //utility function to find Nth largest number in a given tree 
        public virtual void NthLargestUtil(Node node, int n, Count C)
        {

            //Base case, the second condition is to avoid unnecesary recursion
            if (node == null || C.c >= n)
                return;


            //Follow reverse in order traversal so that the largest element is visited first
            this.NthLargestUtil(node.right, n, C);

            //increment the count of visited nodes 
            C.c++;


            //if c becomes n, then this is the Nth largest 
            if (C.c == n)
            {
                Console.WriteLine(n + "th largest element is " + node.data);
                return;
            }

            //recur for left subtree 
            this.NthLargestUtil(node.left, n, C);

        }

        //RUNTIME: O(1)
        //method to find the Nth largest number in given binary search tree 
        public virtual void NthLargest(int n)
        {
            Count c = new Count(this);
            this.NthLargestUtil(this.root, n, c);
        }
    }

    
}
