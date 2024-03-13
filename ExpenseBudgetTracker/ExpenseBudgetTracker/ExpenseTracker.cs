using System;
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
            InitializeCategories();
            LoadTransactions();
        }

        private void InitializeCategories()
        {
            categories.Add(new Category("Food"));
            categories.Add(new Category("Rent"));
            categories.Add(new Category("Utilities"));
            // Add more predefined categories as needed
        }

        public void LoadTransactions()
        {
            transactions = DataController.LoadTransactions();
        }

        public void SaveTransactions()
        {
            DataController.SaveTransactions(transactions);
        }

        public void AddTransaction(decimal amount, TransactionType type, string category, string note, bool isRecurring)
        {
            Transaction transaction;
            if (type == TransactionType.Expense)
            {
                transaction = new Expense(amount, category, note, isRecurring);
            }
            else
            {
                transaction = new Income(amount, category, note, isRecurring);
            }

            transactions.Add(transaction);
            SaveTransactions();
        }

        public void EditTransaction(int index, decimal newAmount, string newCategory, string newNote, bool newIsRecurring)
        {
            if (index >= 0 && index < transactions.Count)
            {
                Transaction editedTransaction = transactions[index];
                editedTransaction.Amount = newAmount;
                editedTransaction.Category = newCategory;
                editedTransaction.Note = newNote;
                editedTransaction.IsRecurring = newIsRecurring;
                SaveTransactions();
            }
            else
            {
                Console.WriteLine("Invalid index for editing transaction.");
            }
        }

        public void DeleteTransaction(int index)
        {
            if (index >= 0 && index < transactions.Count)
            {
                transactions.RemoveAt(index);
                SaveTransactions();
            }
            else
            {
                Console.WriteLine("Invalid index for deleting transaction.");
            }
        }

        public void DisplayRecentTransactions()
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.ToString());
            }
        }

        public void DisplayCategories()
        {
            Console.WriteLine("Available Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
            }
        }

        public void SetBudget(string category, decimal amount)
        {
            budget.SetBudget(category, amount);
        }

        public void DisplayBudget()
        {
            Console.WriteLine("Budget for Categories:");
            foreach (var kvp in budget.CategoryBudgets)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
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

