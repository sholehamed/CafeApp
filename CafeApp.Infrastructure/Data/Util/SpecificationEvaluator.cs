using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Infrastructure.Data.Util
{
    public class SpecificationEvaluator<TEntity> where TEntity : class, IEntityBase
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecifications<TEntity> specifications)
        {

            // Modify the IQueryable
            // Apply filter conditions
            if (specifications.FilterCondition != null)
            {
                for (var i = 0; i < specifications.FilterCondition.Count; i++)
                {
                    query = query.Where(specifications.FilterCondition[i]);
                }

            }

            // Includes
            query = specifications.Includes
                        .Aggregate(query, (current, include) => current.Include(include));

            // Apply ordering
            if (specifications.OrderBy != null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDescending != null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }

            // Apply GroupBy
            if (specifications.GroupBy != null)
            {
                query = query.GroupBy(specifications.GroupBy).SelectMany(x => x);
            }
            return query;
        }
    }
}
