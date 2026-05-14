using PracticeMVC.Models;

namespace PracticeMVC.Strategies
{
    public class Searching
    {
        private ISearchingStrategy _searchingStrategy;

        public Searching(ISearchingStrategy searchingStrategy) 
        {
            _searchingStrategy = searchingStrategy;
        }

        public List<KeyValuePair<string, int>> Search(List<string> items)
        {
            return _searchingStrategy.Search(items);  
        }

    }








}
