using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;


namespace PracticeMVC.Service
{
    public class AppService
    {
        private readonly BinaryTree<string> _binaryTree;
        private readonly Sorting<string> _sorting;
        private readonly TextContract _textContract;

        public AppService(BinaryTree<string> binaryTree, Sorting<string> sorting, TextContract textContract)
        {
            _binaryTree = binaryTree;
            _sorting = sorting;
            _textContract = textContract;
        }
           

        public List<string> GetString(string inputText)
        {
            // get a workable text and put in a list of strings
            //var text = _binaryTree.CleanString(inputText);
            var text = _textContract.CleanString(inputText);
            
            return text;

        }

        //insert methods to choose sorting and searching strategies returning a list of nodes.

        //these methods get moved into SERVICE.
        public List<Node<string>> DecideSearchStrategy(List<string> text, string UserSearchChoice)

        {
            if (UserSearchChoice == "BST")

            {
                PutInTree(text);
                var modelList = TraverseTree();
                //we have the list of nodes we now need to sort them
                //I HAVE NOT YET CREATED INTERFACE FOR THE SEARCH STRATEGIES. A BINARY TREE HAS BEEN IMPLEMENTED AND I THINK MADE IN MAIN PROGRAM FILE ansd in the SERVICE OBJECT IMPLEMENTATION. plus i made one at 					top of this class. 

                //I NEED TO THINK ABOUT HOW TO GET THE TEXT IN. currently using service methods to do that.

                var BinarySearchTreeMethod = new Searching(new BSTSearch());

                modelList = BinarySearchTreeMethod.Search(modelList);


            }

            else if (UserSearchChoice == "FL")


            {
                var ForLoopSearchMethod = new Searching(new ForLoopSearch());

                modelList = ForLoopSearchMethod.Search(modelList);

                //THIS might be how i use the strategy to do the search. I have not yet implemented the search interface or context search class, but if i did it appears to miss out SERVICE OBJECT. so maybe these 
                //If else statements go into SERVICE and COORDINATOR CALLS THE SERVICE TO DO THESE and return the list of nodes called MOdelList.


            }

            //insert some exception handling if no match

            return modelList;


        }



        public List<Node<string>> DecideSortStrategy(List<Node<string>> modelList, string UserSortChoice)

        {

            if (UserSortChoice == "BS")

            {

                var bubbleSortMethod = new Sorting(new BubbleSort());

                modelList = BubbleSortMethod.Sort(modelList);


            }

            else if (UserSortChoice == "QS")

            {
                var QuickSortMethod = new Sorting(new QuickSort());

                modelList = QuickSortMethod.Sort(modelList)



                }

            //insert some exception handling if no match

            return modelList;


        }








        public void PutInTree(List<string> text)
        {
            // put text in tree

            int size = text.Count();

            for(int i = 0; i < size; ++i)
            {
                string value = text[i];
                _binaryTree.Insert(value);

            }

            foreach (string value in text)
            {
                _binaryTree.Insert(value);
            }

        }

        public List<Node<string>> TraverseTree()
        {

            //search the tree put in a list in this order
            var modelList = _binaryTree.InOrderTraversal();

            return modelList;
        }

        public List<KeyValuePair<string, int>> PutTextInDictionary(List<Node<string>> modelList)
        {

            //create dictionary put into it items from the nodeslist
            var dictionary = new List<KeyValuePair<string, int>>();

            foreach (var node in modelList)
            {
                string nodeValue = node.Value;
                int count = node.ElementCount;

                dictionary.Add(new KeyValuePair<string, int>(nodeValue, count));
            }


            return dictionary;
        }








    }
}
