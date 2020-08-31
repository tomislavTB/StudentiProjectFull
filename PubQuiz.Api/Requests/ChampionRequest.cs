using System.Linq;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Requests
{
    public class ChampionRequest : AbstractPagingRequest<ChampionResponse>
    {
        private const string ValidOrderByValues = "name";
        // private const string ValidOrderByValues = "number,someName,etc";
        public string Name { get; set; }

        public string OrderBy { get; set; }

        public override IQueryable<ChampionResponse> GetFilteredQuery(IQueryable<ChampionResponse> query)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(i => i.Name.Contains(Name));
            }

            return query;
        }

        public override IQueryable<ChampionResponse> SetUpSorting(IQueryable<ChampionResponse> query)
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