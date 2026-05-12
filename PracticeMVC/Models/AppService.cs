using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;


namespace PracticeMVC.Models
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


        public List<KeyValuePair<string, int>> ProccessString(string inputText)
        {

            //overarching service function to return dictionary of words and their count. this is acting like a coordinator.

            List<string> text = GetString(inputText);
            PutInTree(text);
            var modelList = TraverseTree();
            // call a sort method on the List of Nodes then put this list in the dictionary.
           // modelList = _binaryTree.SortHighToLow(modelList);
            modelList = _sorting.SortHighToLow(modelList);
            var dictionary = PutTextInDictionary(modelList);
            
            

            return dictionary;

        }
            


        List<string> GetString(string inputText)
        {
            // get a workable text and put in a list of strings
            //var text = _binaryTree.CleanString(inputText);
            var text = _textContract.CleanString(inputText);
            
            return text;

        }

       
        void PutInTree(List<string> text)
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

        List<Node<string>> TraverseTree()
        {

            //search the tree put in a list in this order
            var modelList = _binaryTree.InOrderTraversal();

            return modelList;
        }

        List<KeyValuePair<string, int>> PutTextInDictionary(List<Node<string>> modelList)
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
