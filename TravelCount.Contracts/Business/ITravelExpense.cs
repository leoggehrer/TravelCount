using System.Collections.Generic;
using TravelCount.Contracts.Persistence;

namespace TravelCount.Contracts.Business
{
    public interface ITravelExpense : IIdentifiable, ICopyable<ITravelExpense>
    {
        ITravel Travel { get; }
        IEnumerable<IExpense> Expenses { get; }

        new int Id { get; }
        double TotalExpense { get; }
        double FriendPortion { get; }
        int NumberOfFriends { get; }

        IExpense CreateExpense();
        void Add(IExpense expense);
        void Remove(IExpense expense);

        string[] GetFriends();
        double GetTotalExpenseBy(string friend);
        IEnumerable<IBalance> CalculateBalance();
    }
}
