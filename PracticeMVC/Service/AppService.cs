using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using PracticeMVC.Strategies;
using System.Text;


namespace PracticeMVC.Service
{
    public class AppService
    {
       
        private readonly TextContract _textContract;

        public AppService(TextContract textContract) 
        {
            _textContract = textContract;
        }
           

        public List<string> GetString(string inputText)
        {
          
            var items = _textContract.CleanString(inputText);
            
            return items;

        }

        
        public List<KeyValuePair<string, int>> DecideSearchStrategy(List<string> items, string UserSearchChoice)

        {
            if (UserSearchChoice == "BST")

            {

                var BinarySearchTreeMethod = new Searching(new BinarySearchTree());
                
                return BinarySearchTreeMethod.Search(items);


            }

            else if (UserSearchChoice == "FL")


            {
                var ForLoopSearchMethod = new Searching(new ForLoopSearch());

                return ForLoopSearchMethod.Search(items);


            }

            //insert some exception handling if no match
            else
            {
                //need some return if we cant serarch. throw?
                throw new ArgumentException("Invalid search method choice.", nameof(UserSearchChoice));
            }


        }



        public List<KeyValuePair<string, int>> DecideSortStrategy(List<KeyValuePair<string, int>> items, string UserSortChoice)

        {

            if (UserSortChoice == "BS")

            {

                var bubbleSortMethod = new Sorting(new BubbleSort());

                bubbleSortMethod.Sort(items);


            }

            else if (UserSortChoice == "QS")

            {
                var QuickSortMethod = new Sorting(new QuickSort());

                QuickSortMethod.Sort(items);



                }

            //insert some exception handling if no match

            return items;


        }



        
        public List<KeyValuePair<string, int>> PutTextInDictionary(List<KeyValuePair<string, int>> items)
        {

            //create dictionary put into it items from the nodeslist. but its not a dictionary. it s keyvalue list.
            var dictionary = new List<KeyValuePair<string, int>>();

            foreach (var node in items)
            {
                string nodeValue = node.Key;
                int count = node.Value;

                dictionary.Add(new KeyValuePair<string, int>(nodeValue, count));
            }


            return dictionary;
        }








    }
}
