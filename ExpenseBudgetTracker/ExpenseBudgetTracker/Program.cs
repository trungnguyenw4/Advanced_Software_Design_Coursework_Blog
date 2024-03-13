using System.Text.Json;

namespace ExpenseBudgetTracker;

class Program
{
    


    static string dataFilePath = "expense_data.json";

    static void ShowMenu()
    {

        Console.WriteLine("Expense Tracker Menu:");
        Console.WriteLine("1. Add Expense");
        Console.WriteLine("2. Add Income");
        Console.WriteLine("3. Edit Transaction");
        Console.WriteLine("4. Delete Transaction");
        Console.WriteLine("5. Display Recent Transactions");
        Console.WriteLine("6. Display Categories");
        Console.WriteLine("7. Set Budget");
        Console.WriteLine("8. Display Budget");
        Console.WriteLine("9. Track Progress");
        Console.WriteLine("10. Track Spending by Category");
        Console.WriteLine("11. Save and Exit");


     
    }


    static void AddExpense(ExpenseTracker expenseTracker)
    {
        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter note: ");
        string note = Console.ReadLine();

        Console.Write("Is it recurring? (true/false): ");
        bool isRecurring = bool.Parse(Console.ReadLine());

        expenseTracker.AddTransaction(amount, TransactionType.Expense, category, note, isRecurring);
        Console.WriteLine("Expense added successfully.");
    }

    static void AddIncome(ExpenseTracker expenseTracker)
    {
        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Console.Write("Enter note: ");
        string note = Console.ReadLine();

        Console.Write("Is it recurring? (true/false): ");
        bool isRecurring = bool.Parse(Console.ReadLine());

        expenseTracker.AddTransaction(amount, TransactionType.Income, category, note, isRecurring);
        Console.WriteLine("Income added successfully.");
    }

    static void EditTransaction(ExpenseTracker expenseTracker)
    {
        Console.Write("Enter the index of transaction to edit: ");
        int index = int.Parse(Console.ReadLine());

        Console.Write("Enter new amount: ");
        decimal newAmount = decimal.Parse(Console.ReadLine());

        Console.Write("Enter new category: ");
        string newCategory = Console.ReadLine();

        Console.Write("Enter new note: ");
        string newNote = Console.ReadLine();

        Console.Write("Is it recurring? (true/false): ");
        bool newIsRecurring = bool.Parse(Console.ReadLine());

        expenseTracker.EditTransaction(index, newAmount, newCategory, newNote, newIsRecurring);
        Console.WriteLine("Transaction edited successfully.");
    }

    static void DeleteTransaction(ExpenseTracker expenseTracker)
    {
        Console.Write("Enter the index of transaction to delete: ");
        int index = int.Parse(Console.ReadLine());

        expenseTracker.DeleteTransaction(index);
        Console.WriteLine("Transaction deleted successfully.");
    }

    static void SetBudget(ExpenseTracker expenseTracker)
    {
        Console.Write("Enter category to set budget for: ");
        string category = Console.ReadLine();

        Console.Write("Enter budget amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        expenseTracker.SetBudget(category, amount);
        Console.WriteLine("Budget set successfully.");
    }







    static void Main()
    {
        ExpenseTracker expenseTracker = new ExpenseTracker("transactions.txt");



        expenseTracker.LoadTransactions();

        while (true)
        {
            ShowMenu();
            Console.Write("Enter your choice (1-11): ");
            

            switch (Console.ReadLine())
            {
                case "1":
                    AddExpense(expenseTracker);
                    break;
                case "2":
                    AddIncome(expenseTracker);
                    break;
                case "3":
                    EditTransaction(expenseTracker);
                    break;
                case "4":
                    DeleteTransaction(expenseTracker);
                    break;
                case "5":
                    expenseTracker.DisplayRecentTransactions();
                    break;
                case "6":
                    expenseTracker.DisplayCategories();
                    break;
                case "7":
                    SetBudget(expenseTracker);
                    break;
                case "8":
                    expenseTracker.DisplayBudget();
                    break;
                case "9":
                    expenseTracker.TrackProgress();
                    break;
                case "10":
                    expenseTracker.TrackSpendingByCategory();
                    break;
                case "11":
                    // Save data before exiting
                    expenseTracker.SaveTransactions();
                    Console.WriteLine("Data saved. Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
        
    }

}

