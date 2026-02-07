using System;

public class Book
{
	// Req-1: Properties
	public string Title { get; set; }
	public string Author { get; set; }
	public int Pages { get; set; }
	public bool IsAvailable { get; set; }

	// Req-2: Constructor
	public Book(string title, string author, int pages)
	{
		Title = title;
		Author = author;
		Pages = pages;
		IsAvailable = true;
	}

	// Req-3.1: Method -> BorrowBook()
	public void BorrowBook()
	{
		IsAvailable = false;
		Console.WriteLine("Book has been borrowed");
	}

	// Req-3.2: Method -> ReturnBook()
	public void ReturnBook()
	{
		IsAvailable = true;
		Console.WriteLine("Book has been returned");
	}

	// Req-3.3: Method -> DisplayInfo()
	public void DisplayInfo()
	{
		Console.WriteLine($"Title: {Title}, Author: {Author}, Pages: {Pages}, Available: {IsAvailable}");
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		Book book = new Book("Charidike Shotru", "Qazi Anwar Hussain", 327);
		book.DisplayInfo();
		book.BorrowBook();
		book.DisplayInfo();
		book.ReturnBook();
		book.DisplayInfo();
	}
}