using System.Linq;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Requests
{
    public class GradePaginationRequest : AbstractPagingRequest<GradeResponse>
    {
        private const string ValidOrderByValues = "evaluation";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string Evaluation { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<GradeResponse> GetFilteredQuery(IQueryable<GradeResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(Evaluation))
            {
                query = query.Where(i => i.Evaluation == int.Parse(Evaluation));
            }

            return query;
        }

        public override IQueryable<GradeResponse> SetUpSorting(IQueryable<GradeResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "evaluation":
                        query = ApplyOrdering(query, dtc => dtc.Evaluation, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}