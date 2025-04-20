namespace CafeApp.Domain.Exceptions
{
    public class WrongNeccasaryFieldException : ApplicationException
    {
        public WrongNeccasaryFieldException() : base("referenced Key is not found")
        {
        }
        public override string ToString()
        {
            return base.Message.ToString();
        }
    }
}
