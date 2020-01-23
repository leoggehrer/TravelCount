using System;
using CommonBase.Extensions;
using TravelCount.Contracts.Persistence;

namespace TravelCount.Logic.Entities.Persistence
{
    internal class Expense : IdentityObject, IExpense
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

        public Travel Travel { get; set; }
    }
}
