using TravelCount.Contracts.Business;

namespace TravelCount.Logic.Entities.Business
{
    class Balance : IBalance
    {
        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }
    }
}
