//@DomainCode
//MdStart
using TravelCount.Logic.DataContext;

namespace TravelCount.Logic.Controllers.Persistence
{
    internal abstract partial class TravelCountController<E, I> : GenericController<E, I>
       where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
       where I : Contracts.IIdentifiable
    {
        internal ITravelCountContext TravelCountContext => (ITravelCountContext)Context;

        protected TravelCountController(IContext context)
            : base(context)
        {
        }
        protected TravelCountController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd