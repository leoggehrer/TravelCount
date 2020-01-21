using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCount.Contracts.Persistence
{
    public interface ITravel : IIdentifiable, ICopyable<ITravel>
    {
        new int Id { get; }
        string Designation { get; set; }
        string Description { get; set; }
        string Currency { get; set; }
        string Friends { get; set; }
        string Category { get; set; }
    }
}
