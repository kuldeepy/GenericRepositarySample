using BusinessEntities.Search;

namespace BusinessServices.Interfaces
{
    public interface ISearchServices
    {
        SearchResponse Find(SearchCriteria search);
    }
}
