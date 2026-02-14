using System;
using LibraryManagementSystemV2;

namespace LibraryManagementSystemV2
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Library lib = new Library();

				// 1. Creating Items
				Console.WriteLine("--- Initializing Library ---");
				lib.AddItem(new Book("B01", "The Great Gatsby", 1925, "F. Scott Fitzgerald", ItemCondition.Good));
				lib.AddItem(new Book("B02", "C# in Depth", 2019, "Jon Skeet", ItemCondition.New));
				lib.AddItem(new Magazine("M01", "National Geographic", 2023, 105, "August", ItemCondition.Good));
				lib.AddItem(new Magazine("M02", "Time", 2024, 45, "January", ItemCondition.Worn));
				lib.AddItem(new Audiobook("A01", "Becoming", 2018, "Michelle Obama", 1140, ItemCondition.New));
				lib.AddItem(new Audiobook("A02", "Atomic Habits", 2018, "James Clear", 330, ItemCondition.Good));

				// 2. Registering Members
				lib.RegisterMember(new RegularMember("R01", "Alice (Regular)"));
				lib.RegisterMember(new RegularMember("R02", "Bob (Regular)"));
				lib.RegisterMember(new PremiumMember("P01", "Charlie (Premium)"));

				// 3. Performing Operations
				Console.WriteLine("\n--- Borrowing Operations ---");

				// Successful borrows
				lib.BorrowItem("R01", "B01"); // Alice borrows Gatsby
				lib.BorrowItem("P01", "A01"); // Charlie borrows Becoming
				lib.BorrowItem("P01", "M01"); // Charlie borrows Nat Geo

				// It should fail: Item already borrowed
				try { lib.BorrowItem("R02", "B01"); }
				catch (Exception ex) { Console.WriteLine($"EXPECTED ERROR: {ex.Message}"); }

				// Renewing item
				lib.RenewLoan("B01");

				// Returning item
				lib.ReturnItem("M01");

				// 4. Reporting
				lib.PrintStatus();
				lib.PrintOverdueReport();
				lib.SearchByCreator("Scott");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"CRITICAL ERROR: {ex.Message}");
			}
		}
	}
}