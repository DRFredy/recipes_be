using Microsoft.EntityFrameworkCore;
using Recipes.DAL.Repositories.Interfaces;
using Recipes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Recipes.DAL.Repositories
{
  public class MeasureTypesRepository : GenericRepository<MeasureType>, IMeasureTypesRepository
  {
    private readonly AppDbContext _context;

    public MeasureTypesRepository(AppDbContext context)
      : base(context)
    {
      _context = context;
    }

    public async override Task<IEnumerable<MeasureType>> GetAllAsync(
      Expression<Func<MeasureType, bool>> filter = null,
      Func<IQueryable<MeasureType>, IOrderedQueryable<MeasureType>> orderBy = null,
      string includeProperties = "")
    {
      return await base.GetAllAsync(filter, orderBy, includeProperties);
    }

    public async override Task<MeasureType> GetByIDAsync(object id)
    {
      return await _context.MeasureTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(et => et.Id == (int)id);
    }

    public async override Task InsertAsync(MeasureType entity)
    {
      await base.InsertAsync(entity);
    }

    public async override Task<bool> DeleteAsync(object id)
    {
      return await base.DeleteAsync(id);
    }

    public async override Task<bool> DeleteAsync(MeasureType entity)
    {
      return await base.DeleteAsync(entity);
    }

    public async Task<bool> UpdateAsync(MeasureType entity)
    {
      return await Task.Run(() => {
        try
        {
          base.Update(entity);
        }
        catch
        {
          return false;
        }

        return true;
      });
    }
  }
}