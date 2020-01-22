using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace TravelCount.WebApi.Controllers
{
    public abstract class GenericController<I, M> : ControllerBase
        where I : Contracts.IIdentifiable
        where M : Transfer.TransferObject, I, Contracts.ICopyable<I>, new()
    {
        protected Contracts.Client.IControllerAccess<I> CreateController()
        {
            return Logic.Factory.Create<I>();
        }

        protected async Task<int> CountAsync()
        {
            using var ctrl = CreateController();

            return await ctrl.CountAsync();
        }
        protected async Task<IEnumerable<I>> GetModelsAsync()
        {
            using var ctrl = CreateController();

            return (await ctrl.GetAllAsync()).ToList();
        }
        protected async Task<I> GetModelByIdAsync(int id)
        {
            using var ctrl = CreateController();

            return await ctrl.GetByIdAsync(id);
        }
        protected async Task<I> CreateModelAsync()
        {
            using var ctrl = CreateController();

            return await ctrl.CreateAsync();
        }
        protected async Task<I> InsertModelAsync(M model)
        {
            using var ctrl = CreateController();

            var result = await ctrl.InsertAsync(model);

            await ctrl.SaveChangesAsync();
            return result;
        }
        protected async Task<I> UpdateModelAsync(M model)
        {
            using var ctrl = CreateController();

            var result = await ctrl.UpdateAsync(model);

            await ctrl.SaveChangesAsync();
            return result;
        }
        protected async Task DeleteModelAsync(int id)
        {
            using var ctrl = CreateController();

            await ctrl.DeleteAsync(id);
            await ctrl.SaveChangesAsync();
        }
    }
}
