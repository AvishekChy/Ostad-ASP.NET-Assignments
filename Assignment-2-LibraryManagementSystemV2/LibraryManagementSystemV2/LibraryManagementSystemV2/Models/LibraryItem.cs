using System;
using System.Collections.Generic;

namespace LibraryManagementSystemV2
{
	public abstract class LibraryItem : ILoanable
	{
		public string Id { get; private set; }
		public string Title { get; private set; }
		public int PublicationYear { get; private set; }
		public ItemStatus Status { get; protected set; }
		public ItemCondition Condition { get; set; }
		public Queue<LibraryMember> ReservationQueue { get; private set; } = new Queue<LibraryMember>();

		protected LibraryItem(string id, string title, int year, ItemCondition condition)
		{
			if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID cannot be empty");
			if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty");
			if (year > DateTime.Now.Year) throw new ArgumentException("Publication year cannot be in the future");

			Id = id;
			Title = title;
			PublicationYear = year;
			Status = ItemStatus.Available;
			Condition = condition;
		}

		public abstract int LoanPeriodDays { get; }

		public virtual void Borrow()
		{
			if (Status != ItemStatus.Available && Status != ItemStatus.Reserved)
				throw new CannotBorrowException($"Item '{Title}' is currently {Status}.");

			Status = ItemStatus.Borrowed;
		}

		public virtual void Return()
		{
			Status = (ReservationQueue.Count > 0) ? ItemStatus.Reserved : ItemStatus.Available;
		}

		public override string ToString()
		{
			return $"[{Id}] {Title} ({PublicationYear}) - {Status} [{Condition}]";
		}
	}
}