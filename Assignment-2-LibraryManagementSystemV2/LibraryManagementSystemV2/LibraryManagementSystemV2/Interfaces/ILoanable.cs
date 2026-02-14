namespace LibraryManagementSystemV2
{
	public interface ILoanable
	{
		int LoanPeriodDays { get; }
		void Borrow();
		void Return();
	}
}