using System;
namespace ExpenseBudgetTracker
{
	public class Expense : Transaction
    {
        //Guid transactionID,

        public Expense( decimal amount, string category, string note, bool isRecurring, DateOnly date)
        : base(amount, TransactionType.Expense, category, note, isRecurring, date)
        {

        }

        //public Expense(string transactionID, decimal amount, string category, string note, bool isRecurring, DateOnly date)
        //: base(transactionID, amount, TransactionType.Expense, category, note, isRecurring, date)
        //{

        //}

    }
}

