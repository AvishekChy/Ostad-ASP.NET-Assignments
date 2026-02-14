using System;

namespace LibraryManagementSystemV2
{
	public class Audiobook : LibraryItem
	{
		public string Narrator { get; private set; }
		public int DurationMinutes { get; private set; }

		public Audiobook(string id, string title, int year, string narrator, int duration, ItemCondition condition)
			: base(id, title, year, condition)
		{
			if (duration <= 0) throw new ArgumentException("Duration must be positive");
			Narrator = narrator;
			DurationMinutes = duration;
		}

		public override int LoanPeriodDays => 14;
	}
}