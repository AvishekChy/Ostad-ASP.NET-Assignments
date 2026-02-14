namespace LibraryManagementSystemV2
{
	public class Book : LibraryItem
	{
		public string Author { get; private set; }

		public Book(string id, string title, int year, string author, ItemCondition condition)
			: base(id, title, year, condition)
		{
			Author = author;
		}

		public override int LoanPeriodDays => 21;
		public override string ToString() => base.ToString() + $" by {Author}";
	}
}