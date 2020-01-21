//@DomainCode
//MdStart
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCount.Contracts.Persistence;
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

		public override async Task<IExpense> CreateAsync()
		{
			var result = await base.CreateAsync();

			((Entities.Persistence.Expense)result).Date = DateTime.Now;
			return result;
		}
	}
}
//MdEnd