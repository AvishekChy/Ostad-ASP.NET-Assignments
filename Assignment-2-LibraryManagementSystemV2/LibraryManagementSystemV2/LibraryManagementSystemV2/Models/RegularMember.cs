namespace LibraryManagementSystemV2
{
	public class RegularMember : LibraryMember
	{
		public RegularMember(string id, string name) : base(id, name) { }
		public override int MaxItems => 5;
		public override int LoanGracePeriodExtraDays => 0;
	}
}