namespace CafeApp.Domain.Interfaces
{
    public interface IAuth
    {
        void SetUserId(Guid userId);
        Guid GetUserId();
        
    }
}
