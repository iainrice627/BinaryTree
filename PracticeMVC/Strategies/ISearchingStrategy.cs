namespace PracticeMVC.Strategies
{
    public interface ISearchingStrategy
    {
        public List<KeyValuePair<string, int>> Search(List<string> items);


    }




    public class Node<T> 
    {
        public string Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int ElementCount { get; set; }

        public Node(string value)
        {
            Value = value;
            Left = null;
            Right = null;
            ElementCount = 1;

        }


    }


    public class BinarySearchTree : ISearchingStrategy
    {
        public Node<string> Root { get; private set; }


        public BinarySearchTree()
        {

            Root = null;
          

        }


        public List<KeyValuePair<string, int>> Search(List<string> items)
        {
            // this needs to do the work with the list. 
            PutInTree(items);

            var nodes = TraverseTree();

            var keyValueList = new List<KeyValuePair<string, int>>();

            foreach (var node in nodes)
            {
                keyValueList.Add(new KeyValuePair<string, int>(node.Value, node.ElementCount));
            }
            return keyValueList;

        }
        public void PutInTree(List<string> items)
        {
           

            foreach (string value in items)
            {
                Insert(value);
            }



        }

        public List<Node<string>> TraverseTree()
        {

            var itemsList = InOrderTraversal();

            return itemsList;
        }



        



        public void Insert(string value)
        {

            Root = InsertRecursive(Root, value);


        }

        private Node<string> InsertRecursive(Node<string> node, string value)
        {
            if (node == null)
            {
                return new Node<string>(value);

            }

            else if (value.CompareTo(node.Value) == 0)
            {
                node.ElementCount++;

            }

            else if (value.CompareTo(node.Value) < 0)

            {
                node.Left = InsertRecursive(node.Left, value);
            }

            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = InsertRecursive(node.Right, value);


            }

            return node;

        }

        public List<Node<string>> InOrderTraversal()
        {
            var result = new List<Node<string>>();
            InOrderRec(Root, result);
            return result;
        }

        private void InOrderRec(Node<string> node, List<Node<string>> result)
        {
            if (node != null)
            {
                InOrderRec(node.Left, result);
                result.Add(node);
                InOrderRec(node.Right, result);
            }
        }

        public List<Node<string>> PreOrderTraversal()
        {
            var result = new List<Node<string>>();
            PreOrderRec(Root, result);
            return result;
        }

        private void PreOrderRec(Node<string> node, List<Node<string>> result)
        {
            if (node != null)
            {
                result.Add(node);
                PreOrderRec(node.Left, result);
                PreOrderRec(node.Right, result);
            }
        }

        public List<Node<string>> PostOrderTraversal()
        {
            var result = new List<Node<string>>();
            PostOrderRec(Root, result);
            return result;
        }

        private void PostOrderRec(Node<string> node, List<Node<string>> result)
        {
            if (node != null)
            {
                PostOrderRec(node.Left, result);
                PostOrderRec(node.Right, result);
                result.Add(node);
            }
        }


    }

    public class ForLoopSearch : ISearchingStrategy
    {
        public List<KeyValuePair<string, int>> Search(List<string> items)
        {
                var results = new List<KeyValuePair<string, int>>();
                int steps = 0;

                // Outer loop: examine each word
                for (int i = 0; i < items.Count; i++)
                {
                    steps++; // loop iteration
                    string currentWord = items[i];
                    steps++; // access items[i]

                    // Check if this word is already in results (inefficient linear scan)
                    bool alreadyCounted = false;
                    for (int r = 0; r < results.Count; r++)
                    {
                        steps++; // loop iteration
                        if (results[r].Key == currentWord)
                        {
                            steps++; // comparison
                            alreadyCounted = true;
                            break;
                        }
                    }

                    if (alreadyCounted)
                    {
                        steps++; // branch
                        continue;
                    }

                    // Count occurrences by scanning ENTIRE list again
                    int count = 0;
                    for (int j = 0; j < items.Count; j++)
                    {
                        steps++; // loop iteration
                        if (items[j] == currentWord)
                        {
                            steps++; // comparison
                            count++;
                            steps++; // increment
                        }
                    }

                    // Add result (linear-time add if list grows)
                    results.Add(new KeyValuePair<string, int>(currentWord, count));
                    steps++; // add
                }

                //Console.WriteLine($"Least-efficient search steps: {steps}");
                return results;
            }
    }


}
