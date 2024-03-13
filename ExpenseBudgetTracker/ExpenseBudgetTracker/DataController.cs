using System;
using System.Xml;
using Newtonsoft.Json;

namespace ExpenseBudgetTracker
{
	public class DataController
    {
        private readonly string filePath;

        public DataController(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveTransactions(List<Transaction> transactions)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"{transaction.Amount},{transaction.Type},{transaction.Category},{transaction.Note},{transaction.IsRecurring}");
                }
            }
        }

        public  List<Transaction> LoadTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] parts = reader.ReadLine().Split(',');
                        decimal amount = decimal.Parse(parts[0]);
                        TransactionType type = (TransactionType)Enum.Parse(typeof(TransactionType), parts[1]);
                        string category = parts[2];
                        string note = parts[3];
                        bool isRecurring = bool.Parse(parts[4]);

                        if (type == TransactionType.Expense)
                        {
                            transactions.Add(new Expense(amount, category, note, isRecurring));
                        }
                        else if (type == TransactionType.Income)
                        {
                            transactions.Add(new Income(amount, category, note, isRecurring));
                        }
                    }
                }
            }
            return transactions;
        }

    }



}

