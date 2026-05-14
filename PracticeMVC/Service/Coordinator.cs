using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using PracticeMVC.Strategies;
using System.Text;

namespace PracticeMVC.Service
{
    public class Coordinator
    {

        private readonly AppService _service;
        //private readonly Sorting<string> _sorting;

        public Coordinator(AppService service ) ///Sorting<string> sorting
        {
            _service = service;
            //_sorting = sorting;

        }

        public List<KeyValuePair<string, int>> ProccessString(string inputText, string UserSearchChoice, string UserSortChoice)
        {
          
            var items = _service.GetString(inputText);

            var newItems = _service.DecideSearchStrategy(items, UserSearchChoice);

            return _service.DecideSortStrategy(newItems, UserSortChoice);

            //var dictionary = _service.PutTextInDictionary(newItems);


            //return dictionary;

        }


    }
}
