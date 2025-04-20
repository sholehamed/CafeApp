using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;
using System.Linq.Expressions;

namespace CafeApp.Business.Helpers.Specifications
{
    public class BaseSpecification<TEntity> : ISpecifications<TEntity> where TEntity : IEntityBase
    {
        private readonly List<string>? _includeCollection;




        public BaseSpecification()
        {
            FilterCondition = [];
            _includeCollection = [];
        }
        public List<Expression<Func<TEntity, bool>>> FilterCondition { get; private set; }
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        public List<string> Includes
        {
            get
            {
                return _includeCollection ?? throw new Exception();
            }
        }

        public Expression<Func<TEntity, object>>? GroupBy { get; private set; }

        internal  void AddInclude(string includeExpression)
        {
            Includes.Add(includeExpression);
        }

        private protected void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        private protected void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        private protected void SetFilterCondition(Expression<Func<TEntity, bool>> filterExpression)
        {
            FilterCondition.Add(filterExpression);
        }

        private protected void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
    }
}
