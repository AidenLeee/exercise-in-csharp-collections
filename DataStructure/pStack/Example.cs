using System.Collections;
using System.Runtime.InteropServices.JavaScript;

namespace DataStructure.pStack; 

public class Example : Printable {
    
    public static void SimpleStack() {
        Stack mySimpleStack = new Stack();
        
        mySimpleStack.Push(1);
        mySimpleStack.Push("Aiden");
        mySimpleStack.Push(new Person(5));
        
        Console.WriteLine( "mySimpleStack" );
        Console.WriteLine( "\tCount:    {0}", mySimpleStack.Count );
        Console.Write( "\tValues:" );
        PrintValues( mySimpleStack );
    }

    public static void GenericStack() {
        Stack<string> gStack1 = new Stack<string>();
        
        gStack1.Push("one");
        gStack1.Push("two");
        gStack1.Push("three");
        gStack1.Push("four");
        gStack1.Push("five");
        gStack1.Push("six");

        foreach (string number in gStack1) {
            Console.WriteLine(number);
        }
        
        
        Console.WriteLine("\nPopping '{0}'", gStack1.Pop());
        Console.WriteLine("Peek at next item to pop: {0}", gStack1.Peek());
        Console.WriteLine("\nPopping '{0}'", gStack1.Pop());

        Stack<string> gStack2 = new Stack<string>(gStack1.ToArray());
        
        Console.WriteLine("-------");

        string[] t = gStack1.ToArray();
        // for (int i = 0; i < t.Length; i++) {
        //     Console.Write(t[i] + "\t");
        // }
        
        PrintValues(t);
        Console.WriteLine("-------");
        
        Console.WriteLine("\nContents of the first copy:");

        foreach (string number in gStack2) {
            Console.WriteLine(number);
        }

        string[] strArray = new string[gStack1.Count * 2];
        gStack1.CopyTo(strArray, gStack1.Count);

        Stack<string> gStack3 = new Stack<string>(strArray);
        Console.WriteLine("Contents of the second copy, with duplicates and nulls:");

        foreach (string number in gStack3) {
            Console.WriteLine(number);
        }
        
        
        Console.WriteLine("\ngStack3.Contains(\"four\") = {0}", gStack3.Contains("four"));
        
        Console.WriteLine("\ngStack3.Clear()");
        gStack3.Clear();
        
        Console.WriteLine("\ngStack3.Count = {0}", gStack3.Count);
    }


}

public class Person {
    public int age;

    public Person(int age) {
        this.age = age;
    }

    public override string ToString() {
        return age + "";
    }
}
