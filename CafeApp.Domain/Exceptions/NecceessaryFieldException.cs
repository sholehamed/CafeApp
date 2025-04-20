namespace CafeApp.Domain.Exceptions
{
    public class NecceessaryFieldException(string title) : ApplicationException($"{title} is neccessary for operation.")
    {
        public override string ToString()
        {
            return base.Message;
        }
    }
}
