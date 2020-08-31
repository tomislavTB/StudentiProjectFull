using System.Linq;
using PubQuiz.Responses;
using PubQuiz.Shared.Pagination;

namespace PubQuiz.Requests
{
    public class UserRequest : AbstractPagingRequest<UserResponse>
    {
        private const string ValidOrderByValues = "name";
        // private const string ValidOrderByValues = "number,someName,etc";
        

        public override IQueryable<UserResponse> GetFilteredQuery(IQueryable<UserResponse> query)
        {

                query = query;
            

            return query;
        }

        public override IQueryable<UserResponse> SetUpSorting(IQueryable<UserResponse> query)
        {

            return query;
        }
    }
}