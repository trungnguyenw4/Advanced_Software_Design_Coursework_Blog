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
        Console.WriteLine("9.  Edit Budget");
        Console.WriteLine("10. Track Progress");
        Console.WriteLine("11. Track Spending by Category");
        Console.WriteLine("12. Save and Exit");


     
    }


    static void Main()
    {
        Console.WriteLine("Loading data");

        ExpenseTracker expenseTracker = new ExpenseTracker("transactions.txt");

        // Load data from file if available
        Console.WriteLine("Hello");
        // these stuff could be duplicated
        //expenseTracker.LoadTransactions();
        //expenseTracker.LoadCategories();

        bool showingMenu = true;

        while (showingMenu)
        {
            Console.Clear();
            ShowMenu();
            Console.Write("Enter your choice (1-12): ");
            

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    expenseTracker.AddExpense();
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    expenseTracker.AddIncome();
                    Console.ReadKey();

                    break;
                case "3":
                    Console.Clear();
                    expenseTracker.EditTransaction();
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Clear();
                    expenseTracker.DeleteTransaction();
                    Console.ReadKey();
                    break;
                case "5":
                    Console.Clear();
                    expenseTracker.DisplayRecentTransactions();
                    Console.ReadKey();
                    break;
                case "6":
                    Console.Clear();
                    expenseTracker.DisplayCategories();
                    Console.ReadKey();
                    break;
                case "7":
                    Console.Clear();
                    expenseTracker.SetBudget();
                    Console.ReadKey();
                    break;
                case "8":
                    Console.Clear();
                    expenseTracker.DisplayBudget();
                    Console.ReadKey();
                    break;
                case "9":
                    Console.Clear();
                    expenseTracker.EditBudget();
                    Console.ReadKey();
                    break;
                case "10":
                    Console.Clear();
                    expenseTracker.TrackProgress();
                    Console.ReadKey();
                    break;
                case "11":
                    Console.Clear();
                    expenseTracker.TrackSpendingByCategory();
                    Console.ReadKey();
                    break;
                case "12":
                    // Save data before exiting
                    Console.Clear();
                    expenseTracker.SaveTransactions();
                    Console.WriteLine("Data saved. Exiting...");
                    showingMenu = false;
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
        
    }

}

