using CommonBase.Extensions;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TravelCount.Contracts;
using TravelCount.Contracts.Business;
using TravelCount.Contracts.Persistence;
using TravelCount.Transfer.Persistence;

namespace TravelCount.Transfer.Business
{
    public class TravelExpense : TransferObject, ITravelExpense, ICopyable<ITravelExpense>
    {
        [JsonPropertyName(nameof(Travel))]
        public Travel TravelEntity { get; set; } = new Travel();
        [JsonIgnore()]
        public ITravel Travel { get => TravelEntity; }
        [JsonPropertyName(nameof(Expenses))]
        public List<Expense> ExpenseEntities { get; set; } = new List<Expense>();
        [JsonIgnore()]
        public IEnumerable<IExpense> Expenses { get => ExpenseEntities; }

        public override int Id { get => TravelEntity.Id; set => TravelEntity.Id = value; }
        public double TotalExpense { get; set; }
        public double FriendPortion { get; set; }
        public int NumberOfFriends { get; set; }
        public string[] Friends { get; set; }
        public double[] FriendAmounts { get; set; }
        public IEnumerable<IBalance> Balances { get; private set; }

        public void CopyProperties(ITravelExpense other)
        {
            other.CheckArgument(nameof(other));
            other.Travel.CheckArgument(nameof(other.Travel));
            other.Expenses.CheckArgument(nameof(other.Expenses));

            TotalExpense = other.TotalExpense;
            FriendPortion = other.FriendPortion;
            NumberOfFriends = other.NumberOfFriends;
            Friends = other.Friends;
            FriendAmounts = other.FriendAmounts;
            Balances = other.Balances;
            TravelEntity.CopyProperties(other.Travel);
            ExpenseEntities.Clear();
            foreach (var item in other.Expenses)
            {
                var expense = new Expense();

                expense.CopyProperties(item);
                ExpenseEntities.Add(expense);
            }
        }

        public void Add(IExpense expense)
        {
            expense.CheckArgument(nameof(expense));

            var newItem = new Expense();

            newItem.CopyProperties(expense);
            ExpenseEntities.Add(newItem);
        }
        public IExpense CreateExpense()
        {
            return new Expense();
        }
        public void Remove(IExpense expense)
        {
            expense.CheckArgument(nameof(expense));

            foreach (var item in ExpenseEntities)
            {
                if (item.Id != 0 && item.Id == expense.Id)
                {
                    ExpenseEntities.Remove(item);
                }
                else if (item.Description != null && item.Description.Equals(expense.Description))
                {
                    ExpenseEntities.Remove(item);
                }
            }
        }
    }
}
