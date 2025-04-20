namespace CafeApp.Business.Helpers.Common
{
    public record PagedList<T>(List<T> Items, int TotalItems)
    {

    }
}
