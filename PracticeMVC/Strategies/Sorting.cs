using PracticeMVC.Models;

namespace PracticeMVC.Strategies
{
    public class Sorting
    {
        private ISortingStrategy _sortingStrategy; 

        public Sorting(ISortingStrategy sortingStrategy) 
        {
            _sortingStrategy = sortingStrategy;
        }



        public void Sort(List<KeyValuePair<string, int>> result)
        {
            _sortingStrategy.Sort(result);  
        }



    }
}
