using CafeApp.Domain.Common;
using System.Linq.Expressions;

namespace CafeApp.Domain.Interfaces
{
    public interface ISpecifications<T> where T : IEntityBase
    {
        // Filter Conditions
        List<Expression<Func<T, bool>>> FilterCondition { get; }

        // Order By Ascending
        Expression<Func<T, object>> OrderBy { get; }

        // Order By Descending
        Expression<Func<T, object>> OrderByDescending { get; }

        // Include collection to load related data
        List<string> Includes { get; }

        // GroupBy expression
        Expression<Func<T, object>> GroupBy { get; }


    }
}
