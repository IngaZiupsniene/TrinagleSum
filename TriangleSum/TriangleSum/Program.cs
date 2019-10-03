using System;

namespace TriangleSum
{
    public class Node
    {
        public int data;
        public Node left, right;


        public Node(int item)
        {
            data = item;
            left = right = null;
        }

        public Node(int[] values) : this(values, 0) { }

        Node(int[] values, int index)
        {
            Load(this, values, index);
        }

        void Load(Node tree, int[] values, int index)
        {
            this.data = values[index];
            if (index * 2 + 1 < values.Length)
            {
                this.left = new Node(values, index * 2 + 1);
            }
            if (index * 2 + 2 < values.Length)
            {
                this.right = new Node(values, index * 2 + 2);
            }
        }
    }

    public class Maximum
    {
        public int max_no = int.MinValue;
    }

    class BinaryTree
    {

        public Node root;
        public Maximum max = new Maximum();
        public Node target_leaf = null;

        public virtual bool printPath(Node node, Node target_leaf)
        {
            if (node == null)
            {
                return false;
            }

            if (node == target_leaf || printPath(node.left, target_leaf)
                || printPath(node.right, target_leaf))
            {
                Console.Write(node.data + " ");
                return true;
            }

            return false;
        }


        public virtual void getTargetLeaf(Node node, Maximum max_sum_ref,
                                          int curr_sum, bool nextMustBeOdd)
        {
            if (node == null)
            {
                return;
            }

            if (isEvenNumber(node.data) == nextMustBeOdd)
            {

                curr_sum = curr_sum + node.data;


                if (node.left == null && node.right == null)
                {
                    if (curr_sum > max_sum_ref.max_no)
                    {
                        max_sum_ref.max_no = curr_sum;
                        target_leaf = node;
                    }
                }

                nextMustBeOdd = !nextMustBeOdd;
            }

            getTargetLeaf(node.left, max_sum_ref, curr_sum, nextMustBeOdd);
            getTargetLeaf(node.right, max_sum_ref, curr_sum, nextMustBeOdd);
        }


        public virtual int maxSumPath()
        {

            if (root == null)
            {
                return 0;
            }


            var isEven = true;
            if (isEvenNumber(root.data))
            {
                isEven = true;
            }
            else
            {
                isEven = false;
            }

            getTargetLeaf(root, max, 0, isEven);
            printPath(root, target_leaf);

            return max.max_no;
        }

        public static bool isEvenNumber(int number)
        {
            bool toReturn = false;

            if (number % 2 == 0)
            {
                toReturn = true;
            }
            else
            {
                toReturn = false;
            }
            return toReturn;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {

            //string input = @"215
            //192 124
            //117 269 442
            //218 836 347 235
            //320 805 522 417 345
            //229 601 728 835 133 124
            //248 202 277 433 207 263 257
            //359 464 504 528 516 716 871 182
            //461 441 426 656 863 560 380 171 923
            //381 348 573 533 448 632 387 176 975 449
            //223 711 445 645 245 543 931 532 937 541 444
            //330 131 333 928 376 733 017 778 839 168 197 197
            //131 171 522 137 217 224 291 413 528 520 227 229 928
            //223 626 034 683 839 052 627 310 713 999 629 817 410 121
            //924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";

            //int[][] triangle2DArray = AddToArray(15, input);

            //BinaryTree tree = new BinaryTree();


            //Node nodes = new Node(triangle2DArray[0][0]);

            //for (int i = 0; i < triangle2DArray.GetLength(0); i++)
            //{

            //    for (int j = 0; j < triangle2DArray[i].Length; j++)
            //    {
            //        nodes.left = new Node(triangle2DArray[i + 1][j]);
            //        nodes.right = new Node(triangle2DArray[i + 1][j + 1]);
            //        tree.root = nodes;
            //        nodes = new Node(triangle2DArray[i][j]);

            //    }
            //}


            BinaryTree tree = new BinaryTree();
            tree.root = new Node(215);
            tree.root.left = new Node(192);
            tree.root.right = new Node(124);

            tree.root.left.left = new Node(117);
            tree.root.left.right = new Node(269);
            tree.root.right.left = new Node(269);
            tree.root.right.right = new Node(442);

            //int[] values = new int[] { 215, 192, 124, 117, 269, 269, 442, 218, 836, 836, 347, 347, 235, 320, 805, 805, 522, 522, 417, 417, 345, 229, 601, 601, 728, 728, 835, 835, 133, 133, 124, 248, 202, 202, 277, 277, 433, 433, 207, 207, 263, 263, 257, 359, 464, 464, 504, 504, 528, 528, 516, 516, 716, 716, 871, 871, 182, 461, 441, 441, 426, 426, 656, 656, 863, 863, 560, 560, 380, 380, 171, 171, 923 };
            //Node node = new Node(values);
            //tree.root = node;

            Console.WriteLine("Following are the nodes "
                              + "on maximum sum path");
            int sum = tree.maxSumPath();
            Console.WriteLine("");
            Console.WriteLine("Sum of nodes is : " + sum);
            Console.Read();
        }


        private static int[][] AddToArray(int n, string input)
        {
            int[][] triangleArray = new int[n][];
            var rowArray = input.Split('\n');

            for (int i = 0; i < rowArray.Length; i++)
            {
                var colArray = rowArray[i].Trim().Split(' ');
                int count = colArray.Length;
                triangleArray[i] = new int[count];


                for (int j = 0; j < triangleArray[i].Length; j++)
                {
                    int number = Convert.ToInt32(colArray[j]);
                    triangleArray[i][j] = number;

                }
            }
            return triangleArray;
        }


    }
}
