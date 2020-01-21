using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract = TravelCount.Contracts.Persistence.IExpense;
using Model = TravelCount.Transfer.Persistence.Expense;

namespace TravelCount.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : GenericController<Contract, Model>
    {
		[HttpGet("/api/[controller]/Count")]
		public Task<int> GetCountAsync()
		{
			return base.CountAsync();
		}

		// GET: api/Travel
		[HttpGet("/api/[controller]/Get")]
		public Task<IEnumerable<Contract>> GetAsync()
		{
			return base. GetAllAsync();
		}

		// GET: api/Travel/5
		[HttpGet("/api/[controller]/Get/{id}")]
		public Task<Contract> GetAsync(int id)
		{
			return GetByIdAsync(id);
		}

		// POST: api/Travel/5
		[HttpPost("/api/[controller]")]
		public Task<Contract> Post(Model model)
		{
			return InsertAsync(model);
		}

		// POST: api/Travel/5
		[HttpPut("/api/[controller]")]
		public Task<Contract> Put(Model model)
		{
			return UpdateAsync(model);
		}

		// POST: api/Travel/5
		[HttpDelete("/api/[controller]/{id}")]
		public Task Delete(int id)
		{
			return DeleteAsync(id);
		}
	}
}
