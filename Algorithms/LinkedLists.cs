using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Algorithms
{
    public class Node
    {
        public Node Next;
        public int Data;

        public Node()
        {}

        public Node(int data)
        {
            Data = data;
        }
    }

    public class LinkedLists
    {
        public static void RemoveDuplicates(Node head)
        {
            var table = new Dictionary<int, bool>();
            Node previousNode = null;

            while (head != null)
            {
                if (table.ContainsKey(head.Data))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = head.Next;
                    }
                }
                else
                {
                    table.Add(head.Data, true);
                    previousNode = head;
                }

                head = head.Next;
            }

        }

        // Get kth element till end
        public static List<Node> GetKthElement(Node head, int k)
        {
            if (head == null || k == 0)
                return null;

            var counter = 1;
            var NodeList = new List<Node>();

            while (head != null)
            {
                if (counter >= k)
                {
                    NodeList.Add(head);
                }

                counter++;
                head = head.Next;
            }

            return NodeList;
        }

        // Get kth element till end - Recursive
        internal class Result
        {
            public Node Node { get; set; }
            public int Count { get; set; }

            public Result(Node node, int count)
            {
                Node = node;
                Count = count;
            }
        }

        private static Result GetKthElementRecursiveHelper(Node head, int k)
        {
            if (head == null)
                return new Result(null, 0);

            var result = GetKthElementRecursiveHelper(head.Next, k);

            if (result.Node == null)
            {
                result.Count++;

                if (result.Count == k)
                {
                    result.Node = head;
                }
            }

            return result;
        }

        public static Node GetKthElementRecursive(Node head, int k)
        {
            var result = GetKthElementRecursiveHelper(head, k);

            return result.Node;
        }

        // Delete middle node
        public static bool DeleteMiddleNode(Node node)
        {
            if (node?.Next == null)
                return false;

            var next = node.Next;
            node.Data = next.Data;
            node.Next = next;

            return true;
        }

        // Partition
        public static Node PartitionAroundX(Node head, int x)
        {
            if (head == null || x == 0)
                return new Node();

            Node leftPart = null;
            Node rightPart = null;

            Node lastLeftPart = null;
            Node firstRightPart = null;

            while (head != null)
            {
                var next = head.Next;
                head.Next = null;

                if (head.Data < x)
                {
                    if (leftPart == null)
                    {
                        leftPart = head;
                        lastLeftPart = leftPart;
                    }
                    else
                    {
                        lastLeftPart.Next = head;
                        lastLeftPart = head;
                    }
                }
                else
                {
                    if (rightPart == null)
                    {
                        rightPart = head;
                        firstRightPart = rightPart;
                    }
                    else
                    {
                        firstRightPart.Next = head;
                        firstRightPart = head;
                    }
                }

                head = next;
            }

            if (leftPart == null)
                return rightPart;

            lastLeftPart.Next = rightPart;

            return leftPart;
        }

        // Sum linked lists #1
        public static Node SumLists(Node firstNumber, Node secondNumber)
        {
            var first = 0;
            var second = 0;
            var counter = 0;

            while (firstNumber != null)
            {
                first += firstNumber.Data * (int) Math.Pow(10, counter);
                counter++;
                firstNumber = firstNumber.Next;
            }

            counter = 0;
            while (secondNumber != null)
            {
                second += secondNumber.Data * (int) Math.Pow(10, counter);
                counter++;
                secondNumber = secondNumber.Next;
            }

            var result = first + second;

            var resultNode = new Node();
            var resultHead = resultNode;
            while (result != 0)
            {
                resultNode.Data = result % 10;
                resultNode.Next = new Node();
                resultNode = resultNode.Next;

                result /= 10;
            }

            return resultHead;
        }

        // Sum linked lists #2
        public static Node SumLists2(Node firstNumber, Node secondNumber, int carry)
        {
            if (firstNumber == null && secondNumber == null && carry == 0)
                return null;

            if (firstNumber == null && secondNumber == null && carry == 1)
                return new Node(carry);

            var sumNode = new Node();
            int value = carry;

            if (firstNumber != null)
                value += firstNumber.Data;
            if(secondNumber != null)
                value += secondNumber.Data;

            sumNode.Data = value % 10;

            if (firstNumber != null || secondNumber != null)
                sumNode.Next = SumLists2(firstNumber?.Next, secondNumber?.Next, value >= 10 ? 1 : 0);

            return sumNode;
        }

        // Check if linked list is palindrome
        private static Node ReverseAndCloneLinkedList(Node head)
        {
            // we could also add counter so that in 
            // IsLinkedListPalindrome we check just to the middle not 
            // till the end

            Node node = null;
            
            // 1 -> 2 -> 3
            // null <- 1 <- 2 <- 3 

            while(head != null)
            {
                // 1
                Node n = new Node(head.Data);

                // null <- 1
                n.Next = node;

                // node is now on 1
                node = n;

                // shift right
                head = head.Next;
            }

            // return last added node, it is reverted
            return node;
        }

        public static bool IsLinkedListPalindrome(Node head)
        {
            var reverseList = ReverseAndCloneLinkedList(head);

            while(head != null && reverseList != null)
            {
                if (head.Data != reverseList.Data)
                    return false;

                head = head.Next;
                reverseList = reverseList.Next;
            }

            return head == null && reverseList == null;
        }

        /// <summary>
        /// Is linked list palindrome using Stack and Fast / slow runner technique
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsLinkedListPalindromeStack(Node head)
        {
            var stack = new Stack<int>();

            Node fastRunner = head;
            Node slowRunner = head;

            while(fastRunner != null && fastRunner.Next != null)
            {
                stack.Push(slowRunner.Data);
                slowRunner = slowRunner.Next;
                fastRunner = fastRunner.Next.Next;
            }

            if (fastRunner.Next == null)
                slowRunner = slowRunner.Next;

            while (slowRunner != null)
            {
                if (stack.Pop() != slowRunner.Data)
                    return false;

                slowRunner = slowRunner.Next;
            }

            return true;
        }
    }
}
