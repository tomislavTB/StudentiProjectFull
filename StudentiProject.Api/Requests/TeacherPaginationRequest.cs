using System.Linq;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Requests
{
    public class TeacherPaginationRequest : AbstractPagingRequest<TeacherResponse>
    {
        private const string ValidOrderByValues = "LastName";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string LastName { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<TeacherResponse> GetFilteredQuery(IQueryable<TeacherResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(LastName))
            {
                query = query.Where(i => i.LastName.Contains(LastName));
            }

            return query;
        }

        public override IQueryable<TeacherResponse> SetUpSorting(IQueryable<TeacherResponse> query)
        {
            SortInformation sortInformation = ParseOrderBy(OrderBy, ValidOrderByValues);

            if (sortInformation != null)
            {
                switch (sortInformation.PropertyName)
                {
                    case "lastName":
                        query = ApplyOrdering(query, dtc => dtc.LastName, sortInformation.SortDirection);
                        break;
                }
            }

            return query;
        }
    }
}