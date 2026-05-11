using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;

namespace PracticeMVC.Models

{
    public class Sorting<T> where T : IComparable<T>
    {  

        // when a list of nodes is made its the result of a traversal method and creates a list of nodes whose order is based on how it was travered.
        // pass in the list of nodes. and return it sorted.
        //each node has two propertys - the Value is name and elementcount (number times appeared.)
        //if we sort alphabetically from A-Z we use Value and can swithc Z-A.
        // if we sort by count from high to loweest we use element count and can swtich low to high.


        public Sorting() { }


        public List<Node<T>> SortHighToLow(List<Node<T>> result)
        {
            


            int sizeOfnodesList = result.Count();

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

        public List<Node<T>> SortLowToHigh(List<Node<T>> result)
        {

            int sizeOfnodesList = result.Count();

            int maxIndex = 0;

            //sorted section
            for (int i = 0; i < sizeOfnodesList - 1; ++i)
            {
                maxIndex = i;
                //identifiys biggest value in unsorted section
                for (int j = i + 1; j < sizeOfnodesList; ++j)
                    if (result[j].ElementCount < result[maxIndex].ElementCount)
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

        public void SortAlphaticallyAZ()
        {


        }

        public void SortAlphaticallyZA()
        {


        }

        public void Swap(Node<T> A, Node<T> B)
        {

            Node<T> Temp = A;
            A = B;
            B = Temp;

            //return Temp;

        }




    }
}
