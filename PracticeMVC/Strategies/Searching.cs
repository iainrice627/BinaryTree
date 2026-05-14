using PracticeMVC.Models;

namespace PracticeMVC.Strategies
{
    public class Searching
    {
        private ISearchingStrategy _searchingStrategy;

        public Searching(ISearchingStrategy searchingStrategy) //constructor passes in interface object to construct the _sorting method.
        {
            _searchingStrategy = searchingStrategy;
        }

        public List<KeyValuePair<string, int>> Search(List<string> items)
        {
            return _searchingStrategy.Search(items);  // this is a interface object accessing sort() - which coudl be in any one.
        }

    }








}
