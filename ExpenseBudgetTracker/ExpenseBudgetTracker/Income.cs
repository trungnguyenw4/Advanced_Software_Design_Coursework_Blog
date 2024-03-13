using System;
namespace ExpenseBudgetTracker
{
	public class Income : Transaction
    {
        public Income(decimal amount, string category, string note, bool isRecurring)
        : base(amount, TransactionType.Income, category, note, isRecurring)
        {
        }
    }
}

