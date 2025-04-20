using System.Diagnostics;

namespace CafeApp.Domain.Exceptions
{
    [DebuggerDisplay("{Message}")]
    public class NotFoundException(string entity, object key) : ApplicationException($"any {entity} with id={key} does not exist.")
    {
        public override string ToString()
        {
            return base.Message;
        }
    }
}
