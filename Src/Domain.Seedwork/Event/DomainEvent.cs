using System.Collections.Generic;
using System.Linq;

namespace Domain.Seedwork.Event
{
    public class DomainEvent
    {
        #region Members
        public IList<object> Results { get; private set; }
        #endregion

        #region  Constructor
        public DomainEvent() { Results = new List<object>(); }
        #endregion

        #region Public Methods
        public T GetTypedResult<T>()
        {
            var filteredResults = GetTypedResults<T>();
            if (filteredResults.Count() > 0)
            {
                return filteredResults[0];
            }
            return default(T);
        }
        public IList<T> GetTypedResults<T>()
        {
            return Results.OfType<T>().ToList();
        }
        #endregion
    }
}
