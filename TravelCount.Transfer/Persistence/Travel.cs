using CommonBase.Extensions;
using TravelCount.Contracts.Persistence;

namespace TravelCount.Transfer.Persistence
{
    public class Travel : TransferObject, ITravel, Contracts.ICopyable<ITravel>
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Friends { get; set; }
        public string Category { get; set; }

        public void CopyProperties(ITravel other)
        {
            other.CheckArgument(nameof(other));

            Id = other.Id;
            Designation = other.Designation;
            Description = other.Description;
            Currency = other.Currency;
            Friends = other.Friends;
            Category = other.Category;
        }
    }
}
