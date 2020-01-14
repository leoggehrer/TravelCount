//@DomainCode
//MdStart
using System.Collections.Generic;
using TravelCount.Logic.DataContext;

namespace TravelCount.Logic.Controllers.Persistence
{
	internal sealed partial class ExpenseController : TravelCountController<Entities.Persistence.Expense, Contracts.Persistence.IExpense>
	{
		protected override IEnumerable<Entities.Persistence.Expense> Set => TravelCountContext.Expenses;

		public ExpenseController(IContext context)
			: base(context)
		{
		}
		public ExpenseController(ControllerObject controller)
			: base(controller)
		{
		}
	}
}
//MdEnd