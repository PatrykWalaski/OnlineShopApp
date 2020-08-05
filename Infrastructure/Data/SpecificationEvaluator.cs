using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);  // for example: p => p.ProductTypeId == id
            }

            // aggregate because we can have multiple includes in query
            // example: .Include(p => p.ProductType).Include(p => p.ProductBrand)
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include)); // current is an object with include that is our expression

            return query;
        }
    }
}