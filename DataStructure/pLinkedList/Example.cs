using System.Text;

namespace DataStructure.pLinkedList; 

public class Example : Printable {

    public static void GenericLinkedList() {
        
        string[] words =
            { "the", "fox", "jumps", "over", "the", "dog" };
        LinkedList<string> sentence = new LinkedList<string>(words);
        PrintValues(sentence);
        Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
            sentence.Contains("jumps"));

        // add on the beginning of the linked list
        sentence.AddFirst("today");
        PrintValues(sentence);

        // move the first node to be the last
        LinkedListNode<string> mark1 = sentence.First;
        sentence.RemoveFirst();
        sentence.AddLast(mark1);
        sentence.AddLast(".");
        PrintValues(sentence);
        
        //change the last node
        sentence.RemoveLast();
        sentence.RemoveLast();
        sentence.AddLast("yesterday");
        PrintValues(sentence);

        // move the last node to be the first
        mark1 = sentence.Last;
        sentence.RemoveLast();
        sentence.AddFirst(mark1);
        PrintValues(sentence);
        
        // usage of  FindLast()
        sentence.RemoveFirst();
        LinkedListNode<string>? current = sentence.FindLast("the");
        IndicateNode(current, "M: indicate last occurence of 'the': ");
        
        // usage of AddAfter()
        sentence.AddAfter(current, "old");
        sentence.AddAfter(current, new LinkedListNode<string>("lazy"));
        IndicateNode(current, "M: Add 'lazy' and 'old' after 'the':");
        
        // Indicate 'fox' node.
        current = sentence.Find("fox");
        IndicateNode(current, "M: Indicate the 'fox' node:");

        // usage of AddBefore
        sentence.AddBefore(current, "quick");
        sentence.AddBefore(current, new LinkedListNode<string>("brown"));
        IndicateNode(current, "M: Add 'quick' and 'brown' before 'fox':");
        
        // usage of LinkedListNode.Previous
        mark1 = current;
        LinkedListNode<string>? mark2 = current.Previous;
        current = sentence.Find("dog");
        IndicateNode(current, "Test 9: Indicate the 'dog' node:");
        
        // The AddBefore method throws an InvalidOperationException
        // if you try to add a node that already belongs to a list.
        Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
        try
        {
            sentence.AddBefore(current, mark1);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Exception message: {0}", ex.Message);
        }
        
        // Remove the node referred to by mark1, and then add it
        // before the node referred to by current.
        // Indicate the node referred to by current.
        sentence.Remove(mark1);
        sentence.AddBefore(current, mark1);
        IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

        // Remove the node referred to by current.
        sentence.Remove(current);
        IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

        // Add the node after the node referred to by mark2.
        sentence.AddAfter(mark2, current);
        IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

        // The Remove method finds and removes the
        // first node that that has the specified value.
        sentence.AddLast("old");
        // LinkedList.Remove() only delete one node that first find in the list, it just means if the list have
        // more than one node that contains the value, it would only delete the first node
        sentence.Remove("old");
        PrintValues(sentence, "Test 14: Remove node that has the value 'old':");

        // When the linked list is cast to ICollection(Of String),
        // the Add method adds a node to the end of the list.
        sentence.RemoveLast();
        ICollection<string> icoll = sentence;
        icoll.Add("rhinoceros");
        PrintValues(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

        Console.WriteLine("Test 16: Copy the list to an array:");
        // Create an array with the same number of
        // elements as the linked list.
        string[] sArray = new string[sentence.Count];
        sentence.CopyTo(sArray, 0);

        foreach (string s in sArray)
        {
            Console.WriteLine(s);
        }

        // Release all the nodes.
        sentence.Clear();

        Console.WriteLine();
        Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
            sentence.Contains("jumps"));
        
    }
    
    private static void IndicateNode(LinkedListNode<string>? node, string test)
    {
        Console.WriteLine(test);
        if (node.List == null)
        {
            Console.WriteLine("Node '{0}' is not in the list.\n",
                node.Value);
            return;
        }

        StringBuilder result = new StringBuilder("(" + node.Value + ")");
        LinkedListNode<string> nodeP = node.Previous;

        while (nodeP != null)
        {
            result.Insert(0, nodeP.Value + " ");
            nodeP = nodeP.Previous;
        }

        node = node.Next;
        while (node != null)
        {
            result.Append(" " + node.Value);
            node = node.Next;
        }

        Console.WriteLine(result);
        Console.WriteLine();
    }
}