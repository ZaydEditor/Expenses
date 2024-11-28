using System.ComponentModel.Design;
using System.Text;

internal class Program
{
    
    static void Main(string[] args)
    {
        var path = @"E:\c# .net\expenses.txt";
            var exList = new List<Expenses>();
        while (true)
        {
            var expense = new Expenses();
            Console.Write("Expense name: ");
            expense.expense = Console.ReadLine();
            Console.Write("Amount: ");
            int amount;
            var checkamount = int.TryParse(Console.ReadLine(), out amount);
            while (!checkamount)
            {
                Console.WriteLine("Please,enter number!");
                Console.Write("Amount: ");
                checkamount = int.TryParse(Console.ReadLine(), out amount);
            }
            expense.amount = amount;
            Console.Write("Time: ");
            expense.time = TimeOnly.Parse(Console.ReadLine());
            exList.Add(expense);

            Console.Write("Hit Enter to add expense...");
            var response = Console.ReadLine();
            while (response != string.Empty)
            {
                if (string.Equals(response, "stop", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Program is finished!");
                    WriteFile(exList, path);
                    return;
                }
                Console.Write("Hit Enter to add expense...");
                response = Console.ReadLine();
            }

        }

    }


    static void WriteFile(List<Expenses> exList,string path)
    {
        using(StreamWriter sw = new StreamWriter(path))
        {
            var result = new StringBuilder();
            var linelen = $"\n| {"Expense",-10} | {"Amount",-10} | {"Time",-10} |".Length-1;
            result.Append(' '+new string('-', linelen));
                
                result.AppendFormat($"\n| {"Expense",-10} | {"Amount",-10} | {"Time",-10} |");
            foreach(Expenses ex in exList)
            {
                result.Append("\n "+new string('-', linelen));
              
                result.AppendFormat($"\n| {ex.expense,-10} | {ex.amount,-10} | {ex.time,-10} |");
            }
            
            result.Append("\n "+new string('-', linelen));

            sw.WriteLine(result.ToString());
        }
    }

}

class Expenses
{
    public string expense { get; set; }
    public int amount { get; set; } 
    public TimeOnly time { get; set; }
}
