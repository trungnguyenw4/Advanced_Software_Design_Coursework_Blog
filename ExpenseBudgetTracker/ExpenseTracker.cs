using System;
using Newtonsoft.Json.Linq;

namespace ExpenseBudgetTracker
{
    public class ExpenseTracker
    {

        private List<Transaction> transactions;
        private List<Category> categories;
        private Budget budget;
        private DataController DataController;

        public ExpenseTracker(string transactionFilePath)
        {
            transactions = new List<Transaction>();
            categories = new List<Category>();
            budget = new Budget();
            DataController = new DataController(transactionFilePath);
            //InitializeCategories();
            LoadTransactions();
            LoadCategories();
        }

        //private void InitializeCategories()
        //{
        //    categories.Add(new Category("Food"));
        //    categories.Add(new Category("Rent"));
        //    categories.Add(new Category("Utilities"));
        //    // Add more predefined categories as needed
        //}


        public void LoadCategories()
        {
            categories = DataController.LoadCategories();
        }

        public void LoadTransactions()
        {
            //transactions = DataController.LoadTransactions();
            DataController.LoadTransactions(transactions, budget);
        }

        public void SaveTransactions()
        {
            //DataController.SaveTransactions(transactions);
            DataController.SaveTransactions(transactions, budget);
        }

        public void AddTransaction(decimal amount, TransactionType type, string category, string note, bool isRecurring, DateOnly date)
        {
            Transaction transaction;
            if (type == TransactionType.Expense)
            {
                transaction = new Expense(amount, category, note, isRecurring, date);
            }
            else
            {
                transaction = new Income( amount, category, note, isRecurring, date);
            }

            transactions.Add(transaction);
            categories.Add(new Category(category));
            SaveTransactions();
        }



        public void AddExpense()
        {
            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter date: ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Console.Write("Enter note: ");
            string note = Console.ReadLine();

            Console.Write("Is it recurring? (true/false): ");
            bool isRecurring = bool.Parse(Console.ReadLine());

            AddTransaction(amount, TransactionType.Expense, category, note, isRecurring, date);
            Console.WriteLine("Expense added successfully.");
        }


        public void AddIncome()
        {
            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter date: ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Console.Write("Enter note: ");
            string note = Console.ReadLine();

            Console.Write("Is it recurring? (true/false): ");
            bool isRecurring = bool.Parse(Console.ReadLine());

            AddTransaction(amount, TransactionType.Income, category, note, isRecurring, date);
            Console.WriteLine("Income added successfully.");
        }

     
        public void EditTransaction()
        {


            Console.Write("Enter the index of transaction to edit: ");
            int index = int.Parse(Console.ReadLine());

            

            if (index >= 0 && index < transactions.Count)
            {

                Console.Write("Enter new amount: ");
                decimal newAmount = decimal.Parse(Console.ReadLine());

                Console.Write("Enter new category: ");
                string newCategory = Console.ReadLine();

                Console.Write("Enter new note: ");
                string newNote = Console.ReadLine();

                Console.Write("Is it recurring? (true/false): ");
                bool newIsRecurring = bool.Parse(Console.ReadLine());

                Transaction editedTransaction = transactions[index];
                editedTransaction.Amount = newAmount;
                editedTransaction.Category = newCategory;
                editedTransaction.Note = newNote;
                editedTransaction.IsRecurring = newIsRecurring;

                SaveTransactions();
                Console.WriteLine("Transaction edited successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index for editing transaction.");
            }

           
        }

        public void DeleteTransaction()
        {

            Console.Write("Enter the index of transaction to delete: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < transactions.Count)
            {
                transactions.RemoveAt(index);
                SaveTransactions();
                Console.WriteLine("Transaction deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index for deleting transaction.");
            }

            Console.ReadKey();
        }

        public void DisplayRecentTransactions()
        {
           

            foreach (var transaction in transactions)
            {
                Console.WriteLine(transactions.IndexOf(transaction)+ "__" + transaction.ToString());
            }

           
        }

        public void DisplayCategories()
        {

            Console.Clear();

            Console.WriteLine("Available Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
            }
            Console.ReadKey();
        }

        public void SetBudget()
        {
            Console.Write("Enter category to set budget for: ");
            string category = Console.ReadLine();

            Console.Write("Enter budget amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            budget.SetBudget(category, amount);

            Console.WriteLine("Budget set successfully.");

            


        }


        public void EditBudget()
        {
            Console.Write("Enter category to edit budget: ");
            string category = Console.ReadLine();

            foreach (var kvp in budget.CategoryBudgets)
            {
                if (kvp.Key == category)
                {
                    Console.Write("Enter new budget for " + category +" :" );
                    decimal newAmount = decimal.Parse(Console.ReadLine());

                    budget.SetBudget(category, newAmount);
                    //budget.Remove(category, newAmount);
                    Console.WriteLine("Budget changed successfully.");
                    break;

                }
                else
                {
                    Console.WriteLine("Invalid Category for editing.");
                    break;
                }

                //Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }


            //Console.Write("Enter budget amount: ");
            //decimal amount = decimal.Parse(Console.ReadLine());

            //budget.SetBudget(category, amount);

            //Console.WriteLine("Budget set successfully.");

            //Console.Write("Enter the index of transaction to delete: ");
            //int index = int.Parse(Console.ReadLine());

            //if (index >= 0 && index < transactions.Count)
            //{
            //    transactions.RemoveAt(index);
            //    SaveTransactions();
            //    Console.WriteLine("Transaction deleted successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid index for deleting transaction.");
            //}



        }

        public void DisplayBudget()
        {
            Console.Clear();

            Console.WriteLine("Budget for Categories:");
            foreach (var kvp in budget.CategoryBudgets)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.ReadKey();
        }

        public void TrackProgress()
        {
        

            Console.WriteLine("Budget vs Spending:");
            foreach (var kvp in budget.CategoryBudgets)
            {
                decimal spending = transactions
                    .Where(t => t.Category == kvp.Key && t.Type == TransactionType.Expense)
                    .Sum(t => t.Amount);

                Console.WriteLine($"{kvp.Key}: Spent {spending}, Budget {kvp.Value}");
            }

            decimal overallSpending = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            Console.WriteLine($"Overall Spending: {overallSpending}");

         
        }

        public void TrackSpendingByCategory()
        {

            Console.WriteLine("Spending by Category:");
            foreach (var category in categories)
            {
                decimal spending = transactions
                    .Where(t => t.Category == category.Name && t.Type == TransactionType.Expense)
                    .Sum(t => t.Amount);

                Console.WriteLine($"{category.Name}: Spent {spending}");
            }

         
        }
    }
}

