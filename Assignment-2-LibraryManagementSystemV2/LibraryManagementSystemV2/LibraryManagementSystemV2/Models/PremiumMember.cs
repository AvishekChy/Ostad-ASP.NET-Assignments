namespace LibraryManagementSystemV2
{
	public class PremiumMember : LibraryMember
	{
		public PremiumMember(string id, string name) : base(id, name) { }
		public override int MaxItems => 12;
		public override int LoanGracePeriodExtraDays => 7;
	}
}