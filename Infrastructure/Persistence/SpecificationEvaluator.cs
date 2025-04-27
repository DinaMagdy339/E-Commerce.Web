using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    static class SpecificationEvaluator
    {
        // Create Query
        // _dbContext.Products.where(p=>p.id).Include(p=>p.ProductBrand).Include(p=>p.ProductType);
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> InputQuery, ISpecifications<TEntity, TKey> sapcification) where TEntity : BaseEntity<TKey>
        {
            var Query = InputQuery;
            if (sapcification.Criteria is not null)
            {
                Query = Query.Where(sapcification.Criteria);
            }
            if(sapcification.OrderBy is not null)
            {
                Query = Query.OrderBy(sapcification.OrderBy);
            }
            if (sapcification.OrderByDescending is not null)
            {
                Query = Query.OrderByDescending(sapcification.OrderByDescending);
            }
            if (sapcification.IncludeExpressions is not null && sapcification.IncludeExpressions.Count > 0)
            {
                Query = sapcification.IncludeExpressions.Aggregate(Query, (currentQuery, includeExp) => currentQuery.Include(includeExp));
            }
            if (sapcification.IsPaginated)
            {
                Query = Query.Skip(sapcification.Skip).Take(sapcification.Take);
            }
            return Query;
        }
    }
}
