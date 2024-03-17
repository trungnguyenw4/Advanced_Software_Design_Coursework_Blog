using System;
namespace ExpenseBudgetTracker
{
	public abstract class Transaction
    {
        //public string TransactionID { get; set; }
        public decimal Amount { get; set; }
        
        public string Category { get; set; }
        public string Note { get; set; }
        public bool IsRecurring { get; set; }
        public DateOnly Date { get; set; }
        public TransactionType Type { get; set; }

        //Guid transactionID,
    public Transaction( decimal amount, TransactionType type, string category, string note, bool isRecurring, DateOnly date)
        {
            //TransactionID = transactionID;
            Amount = amount;
            Type = type;
            Category = category;
            Note = note;
            IsRecurring = isRecurring;
            Date = date;
        }

        //string transactionID = Guid.NewGuid().ToString();

        //public Transaction(string transactionID, decimal amount, TransactionType type, string category, string note, bool isRecurring, DateOnly date)
        //{

        //    TransactionID = transactionID;
        //    Amount = amount;
        //    Type = type;
        //    Category = category;
        //    Note = note;
        //    IsRecurring = isRecurring;
        //    Date = date;
        //}

        public override string ToString()
        {
            return $"Amount: {Amount}, Type: {Type}, Category: {Category}, Note: {Note}, Recurring: {IsRecurring}, Date: {Date}";
        }

    }
}

