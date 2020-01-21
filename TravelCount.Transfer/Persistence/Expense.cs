using CommonBase.Extensions;
using System;
using TravelCount.Contracts.Persistence;

namespace TravelCount.Transfer.Persistence
{
    public class Expense : TransferObject, IExpense, Contracts.ICopyable<IExpense>
    {
        public int TravelId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Friend { get; set; }

        public void CopyProperties(IExpense other)
        {
            other.CheckArgument(nameof(other));

            Id = other.Id;
            TravelId = other.TravelId;
            Date = other.Date;
            Description = other.Description;
            Amount = other.Amount;
            Friend = other.Friend;
        }
    }
}
