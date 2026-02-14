using System;

namespace LibraryManagementSystemV2
{
	public class LibraryException : Exception
	{
		public LibraryException(string message) : base(message) { }
	}

	public class CannotBorrowException : LibraryException
	{
		public CannotBorrowException(string message) : base(message) { }
	}

	public class MaxItemsExceededException : LibraryException
	{
		public MaxItemsExceededException(string message) : base(message) { }
	}
}