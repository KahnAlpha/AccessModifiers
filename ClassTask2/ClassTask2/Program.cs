//using System;

//public class Book
//{
//    private string name;
//    private int pageCount;

//    public string Name
//    {
//        get { return name; }
//        set
//        {
//            if (value.Length < 3)
//            {
//                Console.WriteLine("Name must be at least 3 characters.");
//            }
//            name = value;
//        }
//    }

//    public int PageCount
//    {
//        get { return pageCount; }
//        set
//        {
//            if (value < 10)
//            {
//                Console.WriteLine("Page count must be at least 10.");
//            }
//            pageCount = value;
//        }
//    }

//    public Book(string name, int pageCount)
//    {
//        Name = name;
//        PageCount = pageCount;
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Book[] books = new Book[10];
//        int count = 0;
//        while (count < 10)
//        {
//            try
//            {
//                Console.Write("Enter book name: ");
//                string name = Console.ReadLine();
//                Console.Write("Enter page count: ");
//                int pageCount = int.Parse(Console.ReadLine());

//                Book book = new Book(name, pageCount);
//                books[count] = book;
//                count++;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }

//        Console.WriteLine("All books have been added.");
//        Console.ReadKey();
//    }
//}
