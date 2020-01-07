using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelCount.Contracts;
using TravelCount.Logic.Entities;

namespace TravelCount.Logic.DataContext
{
    internal interface IContext : IDisposable
    {
        #region Async-Methods
        Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I;

        Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        Task<E> InsertAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        Task<E> UpdateAsync<I, E>(I entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new();

        Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I;

        Task SaveAsync();
        #endregion Async-Methods
    }
}
