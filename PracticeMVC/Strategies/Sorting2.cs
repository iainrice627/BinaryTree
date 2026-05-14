using PracticeMVC.Models;

namespace PracticeMVC.Strategies
{
    public class Sorting2<T>
    {
        private ISortingStrategy<T> _sortingStrategy; // declaring an interface for the sorting abstract class and calling it _sortingMethod.

        public Sorting2(ISortingStrategy<T> sortingStrategy) //constructor passes in interface object to construct the _sorting method.
        {
            _sortingStrategy = sortingStrategy;
        }


        //behaviours/methods

        public void Sort(List<Node<T>> result)
        {
            _sortingStrategy.Sort(result);  // this is a interface object accessing sort() but which ONE?
        }



    }
}
