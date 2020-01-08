using System;
using System.Threading.Tasks;

namespace TravelCount.ConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello TravelCount!");

            using var ctrlTravel = Logic.Factory.CreateTravelController();

            var travel = await ctrlTravel.CreateAsync();

            travel.Designation = "Manchester 2020";
            travel.Category = "Reisen";
            travel.Currency = "EUR";
            travel.Friends = "Gerhard;Robert";
            travel = await ctrlTravel.InsertAsync(travel);
            await ctrlTravel.SaveChangesAsync();
        }
    }
}
