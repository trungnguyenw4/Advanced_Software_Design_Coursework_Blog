using System;
namespace ExpenseBudgetTracker
{
	public abstract class Transaction
    {
        public decimal Amount { get; set; }
        
        public string Category { get; set; }
        public string Note { get; set; }
        public bool IsRecurring { get; set; }

        public TransactionType Type { get; set; }


    public Transaction(decimal amount, TransactionType type, string category, string note, bool isRecurring)
        {
            Amount = amount;
            Type = type;
            Category = category;
            Note = note;
            IsRecurring = isRecurring;
        }

        public override string ToString()
        {
            return $"Amount: {Amount}, Type: {Type}, Category: {Category}, Note: {Note}, Recurring: {IsRecurring}";
        }

    }
}

