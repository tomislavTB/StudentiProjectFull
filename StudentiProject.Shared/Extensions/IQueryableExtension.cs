using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentiProject.Shared.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace StudentiProject.Shared.Extensions
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Applies the filter from paging request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="pagingRequest">The paging request.</param>
        /// <returns></returns>
        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, AbstractPagingRequest<T> pagingRequest)
        {
            return pagingRequest.GetFilteredQuery(query);
        }

        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, AbstractPagingRequest<T> pagingRequest)
        {
            if (pagingRequest.PageSize.Value == 0)
            {
                return query;
            }
            int numberOfElementsToSkip = (pagingRequest.Page.Value - 1) * pagingRequest.PageSize.Value;
            return query.Skip(numberOfElementsToSkip).Take(pagingRequest.PageSize.Value);
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, AbstractPagingRequest<T> pagingRequest)
        {
            return pagingRequest.SetUpSorting(query);
        }

        /// <summary>
        /// Gets filtered and paged result
        /// </summary>
        /// <typeparam name="TEntity">The type of the ntity.</typeparam>
        /// <typeparam name="TDto">The type of to.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="pagingRequest">The paging request.</param>
        /// <remarks>
        /// Does two round trips to DB.
        /// </remarks>
        /// <returns></returns>
        public static async Task<PagedResult<TEntity>> ToPagedResultAsync<TEntity>(
            this IQueryable<TEntity> query,
            AbstractPagingRequest<TEntity> pagingRequest,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            query = query.ApplyFilter(pagingRequest);

            int totalResults = await query.CountAsync();

            if (include != null)
            {
                query = include(query);
            }

            IEnumerable<TEntity> data = await query.ApplySorting(pagingRequest)
                .ApplyPagination(pagingRequest)
                .ToListAsync();
            PagedResult<TEntity> pagedResult = new PagedResult<TEntity>
            {
                Count = totalResults,
                Data = data
            };

            if (pagingRequest.PageSize != 0)
            {
                int pageCount = (int)Math.Ceiling(totalResults / (double)pagingRequest.PageSize);
                pagedResult.Count = pageCount;
            }

            return pagedResult;
        }
    }
}