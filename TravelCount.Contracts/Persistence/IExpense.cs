using System;

namespace TravelCount.Contracts.Persistence
{
    public interface IExpense : IIdentifiable, ICopyable<IExpense>
    {
        new int Id { get; }
        int TravelId { get; set; }
        DateTime Date { get; }
        string Description { get; set; }
        double Amount { get; set; }
        string Friend { get; set; }
    }
}
