using System.Collections;

namespace DataStructure; 

public class Printable {
    protected static void PrintValues( IEnumerable myCollection, string message = "No Message" )  {
        Console.WriteLine(message);
        foreach ( Object obj in myCollection )
            Console.Write( "    {0}", obj );
        Console.WriteLine();
    }
}