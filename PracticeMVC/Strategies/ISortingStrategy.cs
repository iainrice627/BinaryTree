using PracticeMVC.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Text;

namespace PracticeMVC.Strategies
{
    public interface ISortingStrategy
    {

        public void Sort(List<KeyValuePair<string, int>> nodes);
    }

    public class BubbleSort : ISortingStrategy
    {
        public void Sort(List<KeyValuePair<string, int>> nodes)
        {
            int sizeOfnodesList = nodes.Count;

            int maxIndex = 0;

            //sorted section
            for (int i = 0; i < sizeOfnodesList - 1; ++i)
            {
                maxIndex = i;
                //identifiys biggest value in unsorted section
                for (int j = i + 1; j < sizeOfnodesList; ++j)
                    if (nodes[j].Value > nodes[maxIndex].Value)
                    {  // to sort in acending use <.  to sort decending us >  here.
                        maxIndex = j;

                    }
                //Swap(result[maxIndex], result[i]);

                var Temp = nodes[maxIndex]; // not storing nodes but key value pairs now.
                nodes[maxIndex] = nodes[i];
                nodes[i] = Temp;

            }


            //return nodes;


        }

    }


    public class QuickSort : ISortingStrategy
    {
        public void Sort(List<KeyValuePair<string, int>> nodes)
        {

            QuickSortInternal(nodes, 0, nodes.Count - 1);
            
        }


        private static void QuickSortInternal(List<KeyValuePair<string, int>> nodes, int left, int right) {
            //insert the quick sort code.

            if (left >= right)
                return; 

            int pivotIndex = Partition(nodes, left, right);

            // Recursively sort left and right partitions
            QuickSort.QuickSortInternal(nodes, left, pivotIndex - 1);
            QuickSort.QuickSortInternal(nodes, pivotIndex + 1, right);

            //return result;

        }

        private static int Partition(List<KeyValuePair<string, int>> nodes, int left, int right)
        {
    

            int pivotValue = nodes[right].Value; // Choose last element as pivot
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (nodes[j].Value <= pivotValue)
                {
                    i++;
                    Swap(nodes, i, j);
                }
            }

            Swap(nodes, i + 1, right);
            return i + 1;

        }

        private static void Swap(List<KeyValuePair<string, int>> nodes, int indexA, int indexB)
        {

            if (indexA == indexB) return;
            var temp = nodes[indexA];
            nodes[indexA] = nodes[indexB];
            nodes[indexB] = temp;


        }






    }



}
