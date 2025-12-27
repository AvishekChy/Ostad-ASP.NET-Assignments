using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
	/// <summary>
	/// Assignment on Module-4 done by Avishek Chowdhury
	/// </summary>
	/// <remarks>
	/// A simple Library Management System demonstrating OOP concepts
	/// </remarks>
	

	// Requirement-1. Base Class: LibraryItem
	public class LibraryItem
	{
		// properties are set
		public string Title { get; set; }
		public int ItemId { get; set; }
		public bool IsAvailable { get; set; }

		// constructor is defined. It runs automatically when I create a new LibraryItem
		public LibraryItem(int itemId, string title)
		{
			ItemId = itemId;
			Title = title;
			IsAvailable = true; // I assumed new items are available by default
		}

		// Virtual method is defined. virtual means child classes are allowed to change this method.
		public virtual void DisplayInfo()
		{
			Console.WriteLine($"ID: {ItemId}, Title: {Title}, Available: {IsAvailable}");
		}
	}

	// Requirement-2. Derived Class: Book
	public class Book : LibraryItem // colon(:) means inherits from. Book is inheriting from LibraryItem
	{
		public string Author { get; set; }

		public Book(int itemId, string title, string author) : base(itemId, title)
		{
			Author = author;
		}

		public override void DisplayInfo()
		{
			Console.WriteLine($"[Book] ID: {ItemId}, Title: {Title}, Author: {Author}, Available: {IsAvailable}");
		}
	}

	// Requirement-2. Derived Class: Magazine 
	public class Magazine : LibraryItem
	{
		public int IssueNumber { get; set; }

		public Magazine(int itemId, string title, int issueNumber) : base(itemId, title)
		{
			IssueNumber = issueNumber;
		}

		public override void DisplayInfo()
		{
			Console.WriteLine($"[Magazine] ID: {ItemId}, Title: {Title}, Issue #: {IssueNumber}, Available: {IsAvailable}");
		}
	}

	// Requirement-3. Main method
	class Program
	{
		static void Main(string[] args)
		{
			// Creating the objects
			// Book(itemid, title, author)
			Book book1 = new Book(1, "The Great Gatsby", "Scott Fitzgerald");
			Book book2 = new Book(2, "Gitanjali", "Rabindranath Tagore");
			// Magazine(itemid, title, issuenumber)
			Magazine mag1 = new Magazine(3, "Time Magazine", 101);

			// Displaying informations
			Console.WriteLine("--- Library Catalog ---");
			book1.DisplayInfo();
			book2.DisplayInfo();
			mag1.DisplayInfo();

			// borrowing
			Console.WriteLine("\n--- Borrowing Item ---");
			Console.WriteLine($"Borrowing '{book2.Title}'...");
			book2.IsAvailable = false;

			// Displaying the updated info
			Console.WriteLine("\n--- Updated Catalog ---");
			book1.DisplayInfo();
			book2.DisplayInfo();
			mag1.DisplayInfo();


			Console.ReadLine();
		}
	}
}