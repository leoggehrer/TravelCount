using System;
using System.Linq;
using System.Threading.Tasks;

namespace TravelCount.ConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            Console.WriteLine("TravelCount!");

            using var ctrlTravelExpense = Logic.Factory.CreateTravelExpenseController();
            var travels = await ctrlTravelExpense.GetAllAsync();

            // Delete all travles
            foreach (var item in travels)
            {
                await ctrlTravelExpense.DeleteAsync(item.Id);
            }
            await ctrlTravelExpense.SaveChangesAsync();

            // Create a Travel
            var friends = new string[] { "Gerhard", "Robert", "Tobias", "Herbert", "Walter" };

            for (int j = 0; j < 5; j++)
            {
                var travelExpense = await ctrlTravelExpense.CreateAsync();

                travelExpense.Travel.Designation = $"Gran Canaria 2019-{j + 1}";
                travelExpense.Travel.Category = "Reisen";
                travelExpense.Travel.Currency = "EUR";
                travelExpense.Travel.Friends = friends.Aggregate((s1, s2) => s1 + ";" + s2);

                for (int i = 0; i < 25; i++)
                {
                    var expense = travelExpense.CreateExpense();
                    expense.Description = $"Essen-{i + 1}";
                    expense.Friend = friends[rnd.Next(0, friends.Length)];
                    expense.Amount = rnd.NextDouble() * 100.0;
                    travelExpense.Add(expense);
                }
                travelExpense = await ctrlTravelExpense.InsertAsync(travelExpense);
                await ctrlTravelExpense.SaveChangesAsync();
            }

            foreach (var item in await ctrlTravelExpense.GetAllAsync())
            {
                var balances = item.Balances;

                Console.WriteLine($"Accounting: {item.Travel.Designation}");
                Console.WriteLine($"\tTotal:   {item.TotalExpense:f}");
                Console.WriteLine($"\tPortion: {item.FriendPortion:f}");

                for (int i = 0; i < item.Friends.Length; i++)
                {
                    Console.WriteLine($"\t\tFriend: {item.Friends[i],-10} {item.FriendAmounts[i]:f}");
                }
                Console.WriteLine("\tBalance:");
                foreach (var balance in item.Balances)
                {
                    Console.WriteLine($"\t\t{balance.From,-10} -> {balance.To,-10}: {balance.Amount:f}");
                }
            }
        }
    }
}
