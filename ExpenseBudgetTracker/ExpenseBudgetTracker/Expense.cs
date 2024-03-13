using System;
namespace ExpenseBudgetTracker
{
	public class Expense : Transaction
    {
        public Expense(decimal amount, string category, string note, bool isRecurring)
        : base(amount, TransactionType.Expense, category, note, isRecurring)
        {

        }
    }
}

