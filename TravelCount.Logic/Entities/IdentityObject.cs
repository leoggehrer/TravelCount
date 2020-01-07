using System;
using System.Collections.Generic;
using System.Text;

namespace TravelCount.Logic.Entities
{
    internal abstract class IdentityObject : Contracts.IIdentifiable
    {
        public int Id { get; set; }
    }
}
