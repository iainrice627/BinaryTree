//using Microsoft.AspNetCore.Components.Forms;
//using System.Xml;
//using static System.Net.Mime.MediaTypeNames;

using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;


namespace PracticeMVC.Models
{
    public class Service
    {
        private readonly BinaryTree<string> _binaryTree;


        public Service(BinaryTree<string> binaryTree)
        {
            _binaryTree = binaryTree;
        }


        public List<KeyValuePair<string, int>> ProccessString(string inputText)
        {

            //overarching service function to return dictionary of words and their count.

            List<string> text = GetString(inputText);
            PutInTree(text);
            var modelList = TraverseTree();
            var dictionary = PutTextInDictionary(modelList);

            return dictionary;

        }
            


        List<string> GetString(string inputText)
        {
            //service - get a workable text and put in a list of strings
            var text = _binaryTree.CleanString(inputText);
            
            return text;

        }

        //public BinaryTree<string> PutInTree(string text)
        void PutInTree(List<string> text)
        {
            //servive - put in tree

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

            //return _binaryTree;


        }

        List<Node<string>> TraverseTree()
        {

            //service - search the tree put in a list in this order
            var modelList = _binaryTree.InOrderTraversal();

            return modelList;
        }

        List<KeyValuePair<string, int>> PutTextInDictionary(List<Node<string>> modelList)
        {

            //sewvice create dictionary put into it items from the nodeslist
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
