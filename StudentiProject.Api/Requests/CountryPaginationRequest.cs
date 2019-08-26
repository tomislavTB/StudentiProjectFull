using System.Linq;
using StudentiProject.Responses;
using StudentiProject.Shared.Pagination;

namespace StudentiProject.Requests
{
    public class CountryPaginationRequest : AbstractPagingRequest<CountryResponse>
    {
        private const string ValidOrderByValues = "name";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string Name { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<CountryResponse> GetFilteredQuery(IQueryable<CountryResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(i => i.Name.Contains(Name));
            }

            return query;
        }

        public override IQueryable<CountryResponse> SetUpSorting(IQueryable<CountryResponse> query)
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