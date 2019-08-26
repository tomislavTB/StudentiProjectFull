using System.Linq;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Requests
{
    public class ExecutorPaginationRequest : AbstractPagingRequest<ExecutorResponse>
    {
        private const string ValidOrderByValues = "description";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string Description { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<ExecutorResponse> GetFilteredQuery(IQueryable<ExecutorResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(Description))
            {
                query = query.Where(i => i.Description.Contains(Description));
            }

            return query;
        }

        public override IQueryable<ExecutorResponse> SetUpSorting(IQueryable<ExecutorResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "description":
                        query = ApplyOrdering(query, dtc => dtc.Description, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}