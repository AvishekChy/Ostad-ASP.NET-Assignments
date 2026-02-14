namespace LibraryManagementSystemV2
{
	public abstract class LibraryMember
	{
		public string MemberId { get; private set; }
		public string Name { get; private set; }
		public abstract int MaxItems { get; }
		public abstract int LoanGracePeriodExtraDays { get; }

		protected LibraryMember(string memberId, string name)
		{
			MemberId = memberId;
			Name = name;
		}

		public override string ToString() => $"{Name} ({this.GetType().Name})";
	}
}