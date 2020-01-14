//@DomainCode
//MdStart
using System.Collections.Generic;
using TravelCount.Logic.DataContext;

namespace TravelCount.Logic.Controllers.Persistence
{
	internal sealed partial class TravelController : TravelCountController<Entities.Persistence.Travel, Contracts.Persistence.ITravel>
	{
		protected override IEnumerable<Entities.Persistence.Travel> Set => TravelCountContext.Travels;

		public TravelController(IContext context)
			: base(context)
		{
		}
		public TravelController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
//MdEnd