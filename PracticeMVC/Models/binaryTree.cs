using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;

namespace PracticeMVC.Models
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int ElementCount { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
            ElementCount = 1;

        }
      

    }
}


public class BinaryTree<T> where T : IComparable<T>
{

    public Node<T> Root { get; private set; }
    

    public BinaryTree()
    {

        Root = null;

        
    }

  

    public void Insert(T value)
    {

        Root = InsertRecursive(Root, value);


    }

    private Node<T> InsertRecursive(Node<T> node, T value)
    {
        if (node == null)
        {
            return new Node<T>(value);

        }

        else if (value.CompareTo(node.Value) == 0)
        {
            node.ElementCount++;

        }

        else if (value.CompareTo(node.Value) < 0)

        {
            node.Left = InsertRecursive(node.Left, value);
        }

        else if (value.CompareTo(node.Value) > 0)
        {
            node.Right = InsertRecursive(node.Right, value);


        }

        return node;

    }

    public List<Node<T>> InOrderTraversal()
    {
        var result = new List<Node<T>>();
        InOrderRec(Root, result);
        return result;
    }

    private void InOrderRec(Node<T> node, List<Node<T>> result)
    {
        if (node != null)
        {
            InOrderRec(node.Left, result);
            result.Add(node);
            InOrderRec(node.Right, result);
        }
    }

    public List<Node<T>> PreOrderTraversal()
    {
        var result = new List<Node<T>>();
        PreOrderRec(Root, result);
        return result;
    }

    private void PreOrderRec(Node<T> node, List<Node<T>> result)
    {
        if (node != null)
        {
            result.Add(node);
            PreOrderRec(node.Left, result);
            PreOrderRec(node.Right, result);
        }
    }

    public List<Node<T>> PostOrderTraversal()
    {
        var result = new List<Node<T>>();
        PostOrderRec(Root, result);
        return result;
    }

    private void PostOrderRec(Node<T> node, List<Node<T>> result)
    {
        if (node != null)
        {
            PostOrderRec(node.Left, result);
            PostOrderRec(node.Right, result);
            result.Add(node);
        }
    }


    public List<string> CleanString(string inputText) 
    {
        if (string.IsNullOrWhiteSpace(inputText))
            return new List<string>();

        var stringbuilder = new StringBuilder();

        foreach (char c in inputText)
        {
            if (char.IsLetter(c) || c == '&')
            {
                stringbuilder.Append(c);
            }
            else
            {
                stringbuilder.Append(',');
            }

        }

        List<string> textBody = stringbuilder.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim().ToLower()).Where(word => word.Length > 0).ToList();


        return textBody;

        //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split

    }



    public List<Node<T>> SortHighToLow(List<Node<T>> result)
    {
        // when a list of nodes is made its the result of a traversal method and creates a list of nodes whose order is based on how it was travered.
        // pass in the list of nodes. and return it sorted.
        //each node has two propertys - the Value is name and elementcount (number times appeared.)
        //if we sort alphabetically from A-Z we use Value and can swithc Z-A.
        // if we sort by count from high to loweest we use element count and can swtich low to high.


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

    public void SortLowToHigh()
    {


    }

    public void SortAlphatically()
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



