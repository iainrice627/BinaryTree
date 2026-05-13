using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;

namespace PracticeMVC.Service
{
    public class Coordinator
    {

        private readonly AppService _service;
        private readonly Sorting<string> _sorting;

        public Coordinator(AppService service, Sorting<string> sorting) 
        {
            _service = service;
            _sorting = sorting;

        }

        public List<KeyValuePair<string, int>> ProccessString(string inputText)
        {

            //overarching service function to return dictionary of words and their count. this is acting like a coordinator.

            List<string> text = _service.GetString(inputText);
            _service.PutInTree(text);
            var modelList = _service.TraverseTree();
            // call a sort method on the List of Nodes then put this list in the dictionary.
            modelList = _sorting.SortHighToLow(modelList);
            var dictionary = _service.PutTextInDictionary(modelList);

     

            return dictionary;

        }


    }
}
