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


    





}



