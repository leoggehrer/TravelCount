using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract = TravelCount.Contracts.Business.ITravelExpense;
using Model = TravelCount.Transfer.Business.TravelExpense;

namespace TravelCount.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelExpenseController : GenericController<Contract, Model>
    {
		[HttpGet("/api/[controller]/Count")]
		public Task<int> GetCountAsync()
		{
			return CountAsync();
		}

		// GET: api/Item
		[HttpGet("/api/[controller]/Get")]
		public Task<IEnumerable<Model>> GetAsync()
		{
			return GetModelsAsync();
		}

		// GET: api/Item/5
		[HttpGet("/api/[controller]/Get/{id}")]
		public Task<Model> GetAsync(int id)
		{
			return GetModelByIdAsync(id);
		}

		// GET: api/Item/5
		[HttpGet("/api/[controller]/create")]
		public Task<Model> GetCreateAsync()
		{
			return CreateModelAsync();
		}

		// POST: api/Item/5
		[HttpPost("/api/[controller]")]
		public Task<Model> Post(Model model)
		{
			return InsertModelAsync(model);
		}

		// POST: api/Item/5
		[HttpPut("/api/[controller]")]
		public Task<Model> Put(Model model)
		{
			return UpdateModelAsync(model);
		}

		// POST: api/Item/5
		[HttpDelete("/api/[controller]/{id}")]
		public Task Delete(int id)
		{
			return DeleteModelAsync(id);
		}
	}
}
