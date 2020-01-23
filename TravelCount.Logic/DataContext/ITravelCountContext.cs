﻿using System.Collections.Generic;
using System.Linq;
using TravelCount.Logic.Entities.Persistence;

namespace TravelCount.Logic.DataContext
{
    internal interface ITravelCountContext
    {
        IEnumerable<Travel> Travels { get; }
        IEnumerable<Expense> Expenses { get; }
    }
}
