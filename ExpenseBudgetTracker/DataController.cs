using System;
using System.IO;
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

        public void SaveTransactions(List<Transaction> transactions, Budget budget)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //writer.WriteLine("[Transactions]");

                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"{transaction.Amount},{transaction.Type},{transaction.Category},{transaction.Note},{transaction.IsRecurring},{transaction.Date}");
                }


                //writer.WriteLine("[Budget]");
                foreach (var kvp in budget.CategoryBudgets)
                {
                    writer.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
        }

        //public List<Transaction> LoadTransactions()
        //List<Transaction> transactions, Budget budget
        public void LoadTransactions(List<Transaction> transactions, Budget budget)
        {
            Console.WriteLine("loading non-categories data");
            //List<Transaction> transactions = new List<Transaction>();
            //Budget budget = new Budget();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    

                    while (!reader.EndOfStream)
                    {
                        
                            string[] parts = reader.ReadLine().Split(',');

                        if (parts.Length == 2 )
                        {
                            // Assume it's budget data if it has 2 parts and the second part is a valid decimal
                            string category = parts[0];
                            //budget.SetBudget(category, budgetAmount);

                            decimal budgetAmount = decimal.Parse(parts[1]);
                            budget.SetBudget(category, budgetAmount);

                        }

                        else {
                            //string transactionID = parts[0];

                            decimal amount = decimal.Parse(parts[0]);
                            TransactionType type = (TransactionType)Enum.Parse(typeof(TransactionType), parts[1]);
                            string category = parts[2];
                            string note = parts[3];
                            bool isRecurring = bool.Parse(parts[4]);

                            DateOnly date = DateOnly.Parse(parts[5]);

                            if (type == TransactionType.Expense)
                            {
                                transactions.Add(new Expense(amount, category, note, isRecurring, date));
                            }
                            else if (type == TransactionType.Income)
                            {
                                transactions.Add(new Income(amount, category, note, isRecurring, date));
                            }
                            

                        }


                        //decimal amount = decimal.Parse(parts[0]);
                        //    TransactionType type = (TransactionType)Enum.Parse(typeof(TransactionType), parts[1]);
                        //    string category = parts[2];
                        //    string note = parts[3];
                        //    bool isRecurring = bool.Parse(parts[4]);

                        //    if (type == TransactionType.Expense)
                        //    {
                        //        transactions.Add(new Expense(amount, category, note, isRecurring));
                        //    }
                        //    else if (type == TransactionType.Income)
                        //    {
                        //        transactions.Add(new Income(amount, category, note, isRecurring));
                        //    }
                        //    else // Assume it's budget data if not a transaction
                        //    {
                        //        decimal budgetAmount = decimal.Parse(parts[1]);
                        //        budget.SetBudget(category, budgetAmount);
                        //    }




                    }
                }
            }
            //return transactions;
            Console.WriteLine("non categories, done");
        }


        public List<Category> LoadCategories()
        {
            Console.WriteLine("loading categories data");

            List<Category> categories = new List<Category>();
            
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    
                    while (!reader.EndOfStream)
                    {
                        string[] parts = reader.ReadLine().Split(',');

                        if (parts.Length != 2)

                        { string category = parts[2];
                          categories.Add(new Category(category));
                        }
                        
                        

                        
                    }
                }
            }
            Console.WriteLine("categories, done");
            return categories;
        }


    }



}

