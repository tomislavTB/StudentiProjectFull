using System.ComponentModel;

namespace PubQuiz.Shared.Pagination
{
    public class SortInformation
    {
        public string PropertyName { get; set; }

        public ListSortDirection SortDirection { get; set; }
    }
}