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
