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

    //public List<Node> Nodes { get; private set; } 

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

    public List<T> InOrderTraversal()
    {
        var result = new List<T>();
        InOrderRec(Root, result);
        return result;
    }

    private void InOrderRec(Node<T> node, List<T> result)
    {
        if (node != null)
        {
            InOrderRec(node.Left, result);
            result.Add(node.Value);
            InOrderRec(node.Right, result);
        }
    }

    public List<T> PreOrderTraversal()
    {
        var result = new List<T>();
        PreOrderRec(Root, result);
        return result;
    }

    private void PreOrderRec(Node<T> node, List<T> result)
    {
        if (node != null)
        {
            result.Add(node.Value);
            PreOrderRec(node.Left, result);
            PreOrderRec(node.Right, result);
        }
    }

    public List<T> PostOrderTraversal()
    {
        var result = new List<T>();
        PostOrderRec(Root, result);
        return result;
    }

    private void PostOrderRec(Node<T> node, List<T> result)
    {
        if (node != null)
        {
            PostOrderRec(node.Left, result);
            PostOrderRec(node.Right, result);
            result.Add(node.Value);
        }
    }


    //metods to use the traversals

    public List<string> CleanedString(string inputText) 
    {
        if (string.IsNullOrWhiteSpace(inputText))
            return new List<string>();

        var stringbuilder = new StringBuilder();

        foreach (char c in inputText)
        {
            if (char.IsLetterOrDigit(c) || c == '&')
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


    public bool ReadValues(IEnumerable<T> values)
    {

        foreach (var value in values)
        {
            Insert(value);
        }
       

        return true;

    }


    public void PutTextInList()
    {
        //crteate a dictionary

        //use one of the traversals and at each point add node value and element count to the dictionary

        //return Dictionary;
    }


    public void SortHighToLow()
    {


    }

    public void SortLowToHigh()
    {


    }

    public void SortAlphatically()
    {


    }


}



