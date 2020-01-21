//@BaseCode
//MdStart
namespace TravelCount.Logic.Entities
{
    internal abstract class IdentityObject : Contracts.IIdentifiable
    {
        public virtual int Id { get; set; }
    }
}
//MdEnd