using System;

public class Book
{
    private string name;
    private int pageCount;

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3)
            {
                Console.WriteLine("Name must be at least 3 characters long.");
            }
            name = value;
        }
    }

    public int PageCount
    {
        get { return pageCount; }
        set
        {
            if (value < 10)
            {
                Console.WriteLine("Page count must be at least 10.");
            }
            pageCount = value;
        }
    }

    public Book(string name, int pageCount)
    {
        Name = name;
        PageCount = pageCount;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[10];
        int count = 0;

        while (count < 10)
        {
            Console.WriteLine("Enter book name:");
            string name = Console.ReadLine();

            bool nameExists = false;

            for (int i = 0; i < count; i++)
            {
                if (books[i].Name.Equals(name))
                {
                    nameExists = true;
                    Console.WriteLine("A book with the same name already exists.");
                    break;
                }
            }

            while (nameExists || name.Length < 3)
            {
                if (nameExists)
                {
                    Console.WriteLine("Enter a different book name:");
                }
                else
                {
                    Console.WriteLine("Name must be at least 3 characters long. Enter book name:");
                }

                name = Console.ReadLine();

                nameExists = false;
                for (int i = 0; i < count; i++)
                {
                    if (books[i].Name.Equals(name))
                    {
                        nameExists = true;
                        Console.WriteLine("A book with the same name already exists.");
                        break;
                    }
                }
            }

            Console.WriteLine("Enter page count:");
            int pageCount = int.Parse(Console.ReadLine());

            while (pageCount < 10)
            {
                Console.WriteLine("Page count must be at least 10. Enter page count:");
                pageCount = int.Parse(Console.ReadLine());
            }

            try
            {
                Book book = new Book(name, pageCount);
                books[count] = book;
                count++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        Console.WriteLine("You have entered the following books:");
        for (int i = 0; i < books.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + books[i].Name + " - " + books[i].PageCount + " pages");
        }

        Console.ReadLine();
    }
}
