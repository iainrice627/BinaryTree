using PracticeMVC.Models;

namespace PracticeMVC.Models
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }


        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;

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

        if (value.CompareTo(node.Value) < 0)

        {
            node.Left = InsertRecursive(node.Left, value);
        }

        else if(value.CompareTo(node.Value) >0)
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

    public bool ReadString(string inputText)
    {




        return true;

    }


}



