using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystemV2
{
	public class Library
	{
		private List<LibraryItem> _items = new List<LibraryItem>();
		private List<LibraryMember> _members = new List<LibraryMember>();
		private List<Loan> _activeLoans = new List<Loan>();
		private List<Loan> _loanHistory = new List<Loan>();

		public void AddItem(LibraryItem item) => _items.Add(item);
		public void RegisterMember(LibraryMember member) => _members.Add(member);

		public void BorrowItem(string memberId, string itemId)
		{
			var member = _members.FirstOrDefault(m => m.MemberId == memberId);
			var item = _items.FirstOrDefault(i => i.Id == itemId);

			if (member == null) throw new ArgumentException("Member not found.");
			if (item == null) throw new ArgumentException("Item not found.");

			// Validation: Max items
			int currentLoanCount = _activeLoans.Count(l => l.Member.MemberId == memberId);
			if (currentLoanCount >= member.MaxItems)
				throw new MaxItemsExceededException($"{member.Name} has reached their borrow limit of {member.MaxItems}.");

			// Bonus: Late Return Blocking
			bool hasOverdueItems = _activeLoans
				.Where(l => l.Member.MemberId == memberId)
				.Any(l => l.CalculateFine() > 0);

			if (hasOverdueItems)
				throw new CannotBorrowException("Cannot borrow new items while having overdue loans.");

			// Bonus: Reservation check
			if (item.Status == ItemStatus.Reserved)
			{
				if (item.ReservationQueue.Peek() != member)
					throw new CannotBorrowException("Item is reserved for another member.");
				else
					item.ReservationQueue.Dequeue(); // Member claimed their reservation
			}

			// Perform Borrow
			item.Borrow(); // Updates status to Borrowed
			var loan = new Loan(item, member);
			_activeLoans.Add(loan);
			Console.WriteLine($"SUCCESS: '{item.Title}' borrowed by {member.Name}. Due: {loan.DueDate.ToShortDateString()}");
		}

		public void ReturnItem(string itemId)
		{
			var loan = _activeLoans.FirstOrDefault(l => l.Item.Id == itemId);
			if (loan == null) throw new LibraryException("No active loan found for this item.");

			loan.ReturnDate = DateTime.Now;
			loan.Item.Return(); // Updates status to Available/Reserved

			decimal fine = loan.CalculateFine();

			_activeLoans.Remove(loan);
			_loanHistory.Add(loan);

			Console.WriteLine($"RETURNED: '{loan.Item.Title}'. Fine: ${fine}");
		}

		public void RenewLoan(string itemId)
		{
			var loan = _activeLoans.FirstOrDefault(l => l.Item.Id == itemId);
			if (loan == null) throw new LibraryException("No active loan found to renew.");

			loan.Renew();
			Console.WriteLine($"RENEWED: '{loan.Item.Title}'. New Due Date: {loan.DueDate.ToShortDateString()}");
		}

		public void SearchByCreator(string name)
		{
			Console.WriteLine($"--- Search Results for '{name}' ---");
			var books = _items.OfType<Book>().Where(b => b.Author.Contains(name, StringComparison.OrdinalIgnoreCase));
			var audios = _items.OfType<Audiobook>().Where(a => a.Narrator.Contains(name, StringComparison.OrdinalIgnoreCase));

			foreach (var b in books) Console.WriteLine($"Book: {b.Title} (Status: {b.Status})");
			foreach (var a in audios) Console.WriteLine($"Audio: {a.Title} (Status: {a.Status})");
		}

		public void PrintOverdueReport()
		{
			Console.WriteLine("\n--- OVERDUE REPORT ---");
			foreach (var loan in _activeLoans)
			{
				decimal fine = loan.CalculateFine();
				if (fine > 0)
				{
					var dto = new OverdueLoanInfo(
						loan.Item.Title,
						loan.Member.Name,
						(DateTime.Now - loan.DueDate).Days,
						fine
					);
					Console.WriteLine($"OVERDUE: {dto.Title} (by {dto.MemberName}) - ${dto.CurrentFine} fine.");
				}
			}
		}

		public void PrintStatus()
		{
			Console.WriteLine("\n--- LIBRARY STATUS ---");
			foreach (var item in _items) Console.WriteLine(item);
		}
	}
}