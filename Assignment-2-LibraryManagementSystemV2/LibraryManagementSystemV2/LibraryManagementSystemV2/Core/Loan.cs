using System;
using LibraryManagementSystemV2; // Ensures it sees the Item classes

namespace LibraryManagementSystemV2
{
	public class Loan
	{
		public string LoanId { get; private set; }
		public LibraryItem Item { get; private set; }
		public LibraryMember Member { get; private set; }
		public DateTime BorrowDate { get; private set; }
		public DateTime DueDate { get; private set; }
		public DateTime? ReturnDate { get; set; }
		public bool IsRenewed { get; set; } = false;

		public Loan(LibraryItem item, LibraryMember member)
		{
			LoanId = Guid.NewGuid().ToString().Substring(0, 8);
			Item = item;
			Member = member;
			BorrowDate = DateTime.Now;

			// Logic: Base item period + Member bonus days
			DueDate = BorrowDate.AddDays(item.LoanPeriodDays + member.LoanGracePeriodExtraDays);
		}

		public void Renew()
		{
			if (IsRenewed) throw new LibraryException("Loan has already been renewed once.");
			if (DateTime.Now > DueDate) throw new LibraryException("Cannot renew overdue items.");

			DueDate = DueDate.AddDays(7); // Extend by 7 days
			IsRenewed = true;
		}

		public decimal CalculateFine()
		{
			if (ReturnDate == null && DateTime.Now <= DueDate) return 0; // Not returned, but not overdue

			DateTime effectiveReturnDate = ReturnDate ?? DateTime.Now;

			if (effectiveReturnDate > DueDate)
			{
				int overdueDays = (effectiveReturnDate - DueDate).Days;
				return overdueDays * 1.5m; // $1.5 per day
			}
			return 0;
		}
	}

	public record OverdueLoanInfo(string Title, string MemberName, int DaysOverdue, decimal CurrentFine);
}