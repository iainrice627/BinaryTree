using PracticeMVC.Models;

namespace PracticeMVC.Strategies
{
    public class Sorting
    {
        private ISortingStrategy _sortingStrategy; // declaring an interface for the sorting abstract class and calling it _sortingMethod.

        public Sorting(ISortingStrategy sortingStrategy) //constructor passes in interface object to construct the _sorting method.
        {
            _sortingStrategy = sortingStrategy;
        }


        //behaviours/methods

        public void Sort(List<KeyValuePair<string, int>> result)
        {
            _sortingStrategy.Sort(result);  // this is a interface object accessing sort() - which coudl be in any one.
        }



    }
}
