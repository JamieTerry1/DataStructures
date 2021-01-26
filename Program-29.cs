/* Jamie Terry 
 * Partners: JunBo Park, Anthony Arellano 
 * 
 * Implementation of delete method on a binary search tree 
 * 
 */


using System;

namespace Week06___BST_Problem2_HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            BST myBinarySearchTree = new BST();
            Console.WriteLine(myBinarySearchTree.Count);

            myBinarySearchTree.Insert(13);
            myBinarySearchTree.Insert(-2);
            myBinarySearchTree.Insert(20);
            myBinarySearchTree.Insert(13);
            myBinarySearchTree.Insert(20);
            myBinarySearchTree.Insert(13);
            myBinarySearchTree.Insert(83);
            myBinarySearchTree.Insert(54);
            myBinarySearchTree.Insert(27);
            Console.WriteLine($"Count = {myBinarySearchTree.Count}");//9
            Console.WriteLine($"Min = {myBinarySearchTree.Min()}");//-2
            Console.WriteLine($"Max = {myBinarySearchTree.Max()}");//83
            Console.WriteLine();

            //search for 54
            if (myBinarySearchTree.Find(54) != null)
                Console.WriteLine("54 was found in the list");
            else
                Console.WriteLine("54 was NOT found in the list");

            //search for 57
            if (myBinarySearchTree.Find(57) != null) 
                Console.WriteLine("57 was found in the list");
            else
                Console.WriteLine("57 was NOT found in the list");
            Console.WriteLine();
          
            myBinarySearchTree.InOrderTraversal();
            Console.WriteLine();
           
            Console.WriteLine("Deleting the value -2");
            myBinarySearchTree.Delete(-2);
            myBinarySearchTree.InOrderTraversal();
            Console.WriteLine();
          
            Console.WriteLine("Deleting the value 13");
            myBinarySearchTree.Delete(13);
            myBinarySearchTree.InOrderTraversal();
            Console.WriteLine();
            
            Console.WriteLine("Deleting the value 54");
            myBinarySearchTree.Delete(54);
            myBinarySearchTree.InOrderTraversal();
            
        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T someValue)
        {
            Value = someValue;
            //Left = Right = null;
        }
    }

    class BST
    {
        //data
        public Node<int> Root { get; private set; }
        public int Count { get; private set; }

        //methods
        public void Insert(int someValue)
        {
            //create a new node
            Node<int> newNode = new Node<int>(someValue);

            if (Root == null) //if the tree is empty
            {
                Root = newNode;
            }
            else
            {
                Node<int> finger = Root;
                while (true)
                {
                    if (someValue <= finger.Value)
                    {
                        if (finger.Left != null)
                            finger = finger.Left; //move left
                        else
                        {
                            finger.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        if (finger.Right != null)
                            finger = finger.Right; //move right
                        else //there is no node on the right
                        {
                            finger.Right = newNode;
                            break;
                        }
                    }
                }
            }


            Count++;
        }
        public Node<int> Find(int someValue)
        {
            Node<int> finger = Root;

            while(finger!=null && finger.Value!= someValue)
            {
                if (someValue < finger.Value)
                    finger = finger.Left; //move left
                else
                    finger = finger.Right;//move right
            }

            //you get here if finger reached null, or finger.value == somevalue
            return finger;
        }


        public bool Find2(int someValue)
        {
            Node<int> finger = Root;

            while (finger != null && finger.Value != someValue)
            {
                if (someValue < finger.Value)
                    finger = finger.Left; //move left
                else
                    finger = finger.Right;//move right
            }

            //you get here if finger reached null, or finger.value == somevalue
            return finger!=null;
        }

        //method to find minimum node in subtree, rooted at curr
        public Node<int> MinKey(Node<int> curr)
        {
            while (curr.Left != null)
                curr = curr.Left;

            return curr;
        }

        //3 cases we need to account for 
        // 1. Deleting a nod with no children 
        // 2. deleting a node with 2 children 
        // 3. deleting a node with 1 child 
        //RUNTIME: O(n)
        public Node<int> Delete(int someValue) //this method deletes the first instance of a value sent to the method. 
        {
            //stores parent node of current node 
            Node<int> parent = null;

            //start with root node 
            Node<int> curr = Root;

            //search key in BST and set its parent pointer
            while (curr != null && curr.Value != someValue)
            {
                //update parent node as current node 
                parent = curr;

                //if given key is less than the current node, go to the left subtree
                //else go to right subtree 
                if (someValue < curr.Value)
                    curr = curr.Left;

                else
                    curr = curr.Right;
            }

            //return if key is not found in the tree 
            if (curr == null)
                return Root;


            //Case 1. Node to be delted has NO CHILDREN
            if (curr.Left == null && curr.Right == null)
            {
                //if node to be deleted is not a root node, then set its 
                // parent left/right child to null
                if (curr != Root)
                {
                    if (parent.Left == curr)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }

                //if tree has only root node, delete it and set root to null 
                else
                    Root = null;
            }

            //Case 2: Node to be deleted has TWO CHILDREN
            else if(curr.Left != null && curr.Right != null)
            {
                //find its in-order successor node 
                Node<int> successor = MinKey(curr.Right);

                //store succesor value 
                int val = successor.Value;

                //recursively delete the successor. 
                Delete(successor.Value);

                //copy the value of the successor to current node 
                curr.Value = val;
            }

            //Case 3: Node to be deleted has ONE CHILD
            else
            {
                //find child node 
                Node<int> child = (curr.Left != null) ? curr.Left : curr.Right;

                //if node to be deleted is not a root node, then set its parent to its child 
                if (curr != Root)
                {
                    if (curr == parent.Left)
                        parent.Left = child;
                    else
                        parent.Right = child;
                }

                //if node to be deleted is root node, then set the root to child 
                else
                    Root = child;
            }

            return Root;
        }

        public void PreOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
            Console.WriteLine();
        }


        public void InOrderTraversal(Node<int> N)  //LNR
        {
            if(N != null)
            {
                InOrderTraversal(N.Left); //L subtree
                Console.Write(N.Value + " ");//visit N
                InOrderTraversal(N.Right); //R subtree
         
            }
        }

        public void PostOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public int Min()
        {
            //edge case
            if (Root == null)
                throw new Exception("there is no min in an empty BST");

            //move left as much as possible then return its value
            Node<int> finger = Root;
            while (finger.Left != null) //if there is a node to the left ... move there
                finger = finger.Left;
            return finger.Value;
        }


        public int Max()
        {
            //edge case
            if (Root == null)
                throw new Exception("there is no max in an empty BST");

            //move right as much as possible then return its value
            Node<int> finger = Root;
            while (finger.Right != null) //if there is a node to the right ... move there
                finger = finger.Right;
            return finger.Value;
        }
        //ctor
        public BST()
        {
            Root = null;
            Count = 0;
        }
    }
}
