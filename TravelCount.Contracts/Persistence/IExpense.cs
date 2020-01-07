using System;

namespace TravelCount.Contracts.Persistence
{
    public interface IExpense : IIdentifiable, ICopyable<IExpense>
    {
        int TravelId { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
        double Amount { get; set; }
        string Friend { get; set; }
    }
}
