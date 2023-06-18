using System.Collections;

namespace DataStructure.pQueue; 

public class Example : Printable{

    public static void SimpleQueue() {
        
        Queue sQueue = new Queue();
        
        sQueue.Enqueue("Hello");
        sQueue.Enqueue("World");
        sQueue.Enqueue("~~");
        
        Console.WriteLine("sQueue count: {0}", sQueue.Count);
        Console.WriteLine("sQueue values:");
        PrintValues(sQueue);

    }

    public static void GenericQueue() {

        Queue<string> gQueue = new Queue<string>();
        
        gQueue.Enqueue("one");
        gQueue.Enqueue("two");
        gQueue.Enqueue("three");
        gQueue.Enqueue("four");
        gQueue.Enqueue("five");
        
        Console.WriteLine("\nDequeuing '{0}'", gQueue.Dequeue());
        Console.WriteLine("Peek at next item to dequeue: {0}",
            gQueue.Peek());
        Console.WriteLine("Dequeuing '{0}'", gQueue.Dequeue());
        
        
        Queue<string> gQueueCopy = new Queue<string>(gQueue.ToArray());

        Console.WriteLine("\nContents of the first copy:");
        PrintValues(gQueueCopy);
        
        
        string[] array2 = new string[gQueue.Count * 2];
        gQueue.CopyTo(array2, gQueue.Count);

        // Create a second queue, using the constructor that accepts an
        // IEnumerable(Of T).
        Queue<string> gQueueCopy2 = new Queue<string>(array2);

        Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
        PrintValues(gQueueCopy2);
        
        
    }
}