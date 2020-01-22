using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract = TravelCount.Contracts.Persistence.ITravel;
using Model = TravelCount.Transfer.Persistence.Travel;

namespace TravelCount.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelController : GenericController<Contract, Model>
    {
		[HttpGet("/api/[controller]/Count")]
		public Task<int> GetCountAsync()
		{
			return base.CountAsync();
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
		public Task<Model> PostAsync(Model model)
		{
			return InsertModelAsync(model);
		}

		// POST: api/Item/5
		[HttpPut("/api/[controller]")]
		public Task<Model> PutAsync(Model model)
		{
			return UpdateModelAsync(model);
		}

		// POST: api/Item/5
		[HttpDelete("/api/[controller]/{id}")]
		public Task DeleteAsync(int id)
		{
			return DeleteModelAsync(id);
		}
	}
}
