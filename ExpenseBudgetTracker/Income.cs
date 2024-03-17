using System;
namespace ExpenseBudgetTracker
{
	public class Income : Transaction
    {
        //Guid transactionID,
        public Income( decimal amount, string category, string note, bool isRecurring, DateOnly date)
        : base( amount, TransactionType.Income, category, note, isRecurring, date)
        {
        }

        //public Income(string transactionID, decimal amount, string category, string note, bool isRecurring, DateOnly date)
        //: base(transactionID, amount, TransactionType.Income, category, note, isRecurring, date)
        //{
        //}

    }
}

