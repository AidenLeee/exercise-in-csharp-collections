namespace DataStructure.pBinarySearch; 

public class Example {

    public static void BinarySearch() {

        int[] intArray = new[] { 3, 2, 8, 9, 7, 6, 4, 3, 5, 9, 8, 7, 12, 836, 27, 8, 9 };

        int target = 836;
        Array.Sort(intArray);
        int pos = Array.BinarySearch(intArray, target);

        Console.WriteLine(pos);
        if (pos >= 0)  
            Console.WriteLine($"Item {intArray[pos].ToString()} found at position {pos + 1}.");  
        else  
            Console.WriteLine("Item not found");  
        Console.ReadKey(); 
    }
}