using MagicVilla_VillaAPI.models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.repository
{
    public interface IVillaRepository
    {
        object villamodels { get; }

       Task<List<Villamodel>> GetAllAsync(Expression <Func<Villamodel , bool>>filter = null);
        Task<Villamodel> GetAsync(Expression<Func<Villamodel,bool>> filter = null , bool tracked=true);
        Task CreateAsync(Villamodel  entity);
        Task UpdateAsync(Villamodel entity);
        Task RemoveAsync(Villamodel entity); 
        Task SaveAsync();
        Task RemoveAsync();
    }
}
