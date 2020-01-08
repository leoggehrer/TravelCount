//@BaseCode
//MdStart
namespace TravelCount.Logic.Entities
{
    internal abstract class IdentityObject : Contracts.IIdentifiable
    {
        public int Id { get; set; }
    }
}
//MdEnd