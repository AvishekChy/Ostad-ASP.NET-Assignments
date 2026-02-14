namespace LibraryManagementSystemV2
{
	public class Magazine : LibraryItem
	{
		public int IssueNumber { get; private set; }
		public string Month { get; private set; }

		public Magazine(string id, string title, int year, int issueNumber, string month, ItemCondition condition)
			: base(id, title, year, condition)
		{
			IssueNumber = issueNumber;
			Month = month;
		}

		public override int LoanPeriodDays => 7;
	}
}