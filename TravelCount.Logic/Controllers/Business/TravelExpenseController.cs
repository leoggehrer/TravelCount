using CommonBase.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCount.Contracts.Business;
using TravelCount.Logic.Controllers.Persistence;
using TravelCount.Logic.DataContext;
using TravelCount.Logic.Entities.Business;
using TravelCount.Logic.Entities.Persistence;

namespace TravelCount.Logic.Controllers.Business
{
    internal class TravelExpenseController : Controllers.ControllerObject, Contracts.Client.IControllerAccess<Contracts.Business.ITravelExpense>
    {
        private TravelController travelController;
        private ExpenseController expenseController;

        public TravelExpenseController(IContext context)
            : base(context)
        {
            travelController = new TravelController(this);
            expenseController = new ExpenseController(this);
        }

        public Task<int> CountAsync()
        {
            return travelController.CountAsync();
        }

        public Task<ITravelExpense> CreateAsync()
        {
            return Task.Run<ITravelExpense>(() => new TravelExpense());
        }

        public Task<IEnumerable<ITravelExpense>> GetAllAsync()
        {
            return Task.Run<IEnumerable<ITravelExpense>>(async () =>
            {
                List<ITravelExpense> result = new List<ITravelExpense>();

                foreach (var item in (await travelController.GetAllAsync()).ToList())
                {
                    result.Add(await GetByIdAsync(item.Id));
                }
                return result;
            });
        }

        public async Task<ITravelExpense> GetByIdAsync(int id)
        {
            var result = default(TravelExpense);
            var travel = await travelController.GetByIdAsync(id);

            if (travel != null)
            {
                result = new TravelExpense();
                result.Travel.CopyProperties(travel);
                foreach (var item in await expenseController.QueryAsync(e => e.TravelId == id))
                {
                    result.ExpenseEntities.Add(item);
                }
            }
            else
            {
                throw new Exception("Entity can't find!");
            }
            return result;
        }

        public async Task<ITravelExpense> InsertAsync(ITravelExpense entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.Travel.CheckArgument(nameof(entity.Travel));
            entity.Expenses.CheckArgument(nameof(entity.Expenses));

            var result = new TravelExpense();

            result.TravelEntity.CopyProperties(entity.Travel);
            foreach (var item in entity.Expenses)
            {
                var expense = new Expense();

                expense.Travel = result.TravelEntity;
                expense.CopyProperties(item);
                await expenseController.InsertAsync(expense);
                result.ExpenseEntities.Add(expense);
            }
            return result;
        }

        public async Task<ITravelExpense> UpdateAsync(ITravelExpense entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.Travel.CheckArgument(nameof(entity.Travel));
            entity.Expenses.CheckArgument(nameof(entity.Expenses));

            //Delete all costs that are no longer included in the list.
            foreach (var item in await expenseController.QueryAsync(e => e.TravelId == entity.Travel.Id))
            {
                var tmpExpense = entity.Expenses.SingleOrDefault(i => i.Id == item.Id);

                if (tmpExpense == null)
                {
                    await expenseController.DeleteAsync(item.Id);
                }
            }

            var result = new TravelExpense();
            var travel = await travelController.UpdateAsync(entity.Travel);

            result.TravelEntity.CopyProperties(travel);
            foreach (var item in entity.Expenses)
            {
                if (item.Id == 0)
                {
                    item.TravelId = entity.Travel.Id;
                    var insEntity = await expenseController.InsertAsync(item);

                    item.CopyProperties(insEntity);
                }
                else
                {
                    var updEntity = await expenseController.UpdateAsync(item);

                    item.CopyProperties(updEntity);
                }
            }
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                foreach (var item in entity.Expenses)
                {
                    await expenseController.DeleteAsync(item.Id);
                }
                await travelController.DeleteAsync(entity.Travel.Id);
            }
            else
            {
                throw new Exception("Entity can't find!");
            }
        }

        public Task SaveChangesAsync()
        {
            return Context.SaveAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            travelController.Dispose();
            expenseController.Dispose();
        }
    }
}
