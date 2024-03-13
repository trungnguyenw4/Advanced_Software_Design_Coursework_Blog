using System;
namespace ExpenseBudgetTracker
{
	public class Budget
	{
        public Dictionary<string, decimal> CategoryBudgets { get; set; }

        public Budget()
        {
            CategoryBudgets = new Dictionary<string, decimal>();
        }

        public void SetBudget(string category, decimal amount)
        {
            if (CategoryBudgets.ContainsKey(category))
            {
                CategoryBudgets[category] = amount;
            }
            else
            {
                CategoryBudgets.Add(category, amount);
            }
        }

        public decimal GetCategoryBudget(string category)
        {
            return CategoryBudgets.ContainsKey(category) ? CategoryBudgets[category] : 0;
        }
    }
}

