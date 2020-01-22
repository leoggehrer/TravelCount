using System;
using System.Collections.Generic;
using System.Text;
using TravelCount.Contracts.Business;

namespace TravelCount.Transfer.Business
{
    public class Balance : IBalance
    {
        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }
    }
}
