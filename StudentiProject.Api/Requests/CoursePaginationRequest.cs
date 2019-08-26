using System.Linq;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Requests
{
    public class CoursePaginationRequest : AbstractPagingRequest<CourseResponse>
    {
        private const string ValidOrderByValues = "name";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string Name { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<CourseResponse> GetFilteredQuery(IQueryable<CourseResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(i => i.Name.Contains(Name));
            }

            return query;
        }

        public override IQueryable<CourseResponse> SetUpSorting(IQueryable<CourseResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "name":
                        query = ApplyOrdering(query, dtc => dtc.Name, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}