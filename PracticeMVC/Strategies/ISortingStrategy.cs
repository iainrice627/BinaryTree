using PracticeMVC.Models;
using System.Xml.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace PracticeMVC.Strategies
{
    public class ISortingStrategy<T>
    {

        void Sorting(List<Node<T>> result);
    }

    public class BubbleSort<T> : ISortingStrategy<T>
    {
        public List<Node<T>> Sorting(List<Node<T>> result)
        {
            int sizeOfnodesList = result.Count;

            int maxIndex = 0;

            //sorted section
            for (int i = 0; i < sizeOfnodesList - 1; ++i)
            {
                maxIndex = i;
                //identifiys biggest value in unsorted section
                for (int j = i + 1; j < sizeOfnodesList; ++j)
                    if (result[j].ElementCount > result[maxIndex].ElementCount)
                    {  // to sort in acending use <.  to sort decending us >  here.
                        maxIndex = j;

                    }
                //Swap(result[maxIndex], result[i]);

                Node<T> Temp = result[maxIndex];
                result[maxIndex] = result[i];
                result[i] = Temp;

            }


            return result;


        }

    }


    public class QuickSort<T> : ISortingStrategy<T>
    {
        public List<Node<T>> Sorting(List<Node<T>> result)
        {
            //insert the quick sort code.
            int left = 0;
            int right = result.Count - 1;

            if (left >= right) return;

            int pivotIndex = Partition(result, left, right);

            // Recursively sort left and right partitions
            Sorting(result, left, pivotIndex - 1);
            Sorting(result, pivotIndex + 1, right);

            return result;

        }

        private static int Partition(List<Node<T>> nodes, int left, int right)
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

        private static void Swap(List<Node<T>> nodes, int indexA, int indexB)
        {

            if (indexA == indexB) return;
            Node temp = nodes[indexA];
            nodes[indexA] = nodes[indexB];
            nodes[indexB] = temp;


        }






    }



}
